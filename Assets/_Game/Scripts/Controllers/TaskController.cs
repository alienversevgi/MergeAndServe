using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MergeAndServe.Data;
using MergeAndServe.Signals;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace MergeAndServe.Game
{
    public class TaskController : IDisposable
    {
        #region Fields

        [Inject] private SignalBus _signalBus;
        [Inject] private GridManager _gridManager;
        [Inject] private BoardController _boardController;
        [Inject] private ItemManager _itemManager;

        private TaskData _data;

        #endregion

        #region Public Methods

        public void Initialize(TaskData data)
        {
            _data = data;

            _signalBus.Subscribe<GameSignals.ItemProduced>(OnItemProduced);
            _signalBus.Subscribe<GameSignals.ItemDestroyed>(OnItemDestroyed);
            _signalBus.Subscribe<GameSignals.ServeRequested>(OnServeRequested);
            _signalBus.Subscribe<GameSignals.OrderItemsServed>(OnOrderItemsServed);
        }

        public List<OrderData> GetAllOrder()
        {
            return _data.Orders;
        }

        public List<OrderData> GetOrders(string shortCode)
        {
            List<OrderData> result = new List<OrderData>();
            for (int i = 0; i < _data.Orders.Count; i++)
            {
                var order = _data.Orders[i];
                for (int j = 0; j < order.Items.Count; j++)
                {
                    var items = order.Items;
                    if (items[j] == shortCode)
                    {
                        result.Add(order);
                    }
                }
            }

            return result;
        }

        public void MarkOrderItems()
        {
            var uniqueItems = _gridManager.GetUniqueItems();

            for (int i = 0; i < uniqueItems.Count; i++)
            {
                var item = uniqueItems[i];
                MarkItems(item.BaseData.ShortCode);
            }
        }

        public void Dispose()
        {
            _signalBus.TryUnsubscribe<GameSignals.ItemProduced>(OnItemProduced);
            _signalBus.TryUnsubscribe<GameSignals.ItemDestroyed>(OnItemDestroyed);
            _signalBus.TryUnsubscribe<GameSignals.ServeRequested>(OnServeRequested);
            _signalBus.TryUnsubscribe<GameSignals.OrderItemsServed>(OnOrderItemsServed);
        }

        #endregion

        #region Private Methods

        private TaskResult IsMarkable(string shortCode)
        {
            var orders = GetOrders(shortCode);
            var sameItems = _gridManager.GetAllItem(shortCode);

            return new TaskResult()
            {
                Result = orders.Count > 0,
                FoundedOrders = orders,
                SameItems = sameItems
            };
        }

        private TaskResult IsUnmarkable(string shortCode)
        {
            var orders = GetOrders(shortCode);
            var sameItems = _gridManager.GetAllItem(shortCode);

            return new TaskResult()
            {
                Result = orders.Count == 0,
                FoundedOrders = orders,
                SameItems = sameItems
            };
        }

        private void MarkItems(string shortCode)
        {
            var result = IsMarkable(shortCode);
            for (int i = 0; i < result.FoundedOrders.Count; i++)
            {
                _signalBus.Fire(new GameSignals.ItemMarked()
                    {
                        OrderId = result.FoundedOrders[i].Id,
                        ItemShortCode = shortCode
                    }
                );
            }

            if (!result.Result)
                return;

            var sameItems = result.SameItems;
            for (int i = 0; i < sameItems.Count; i++)
            {
                sameItems[i].CurrentCell.Mark();
            }
        }

        private void UnmarkItems(string shortCode)
        {
            var result = IsUnmarkable(shortCode);
            var sameItems = result.SameItems;
            bool haveOrder = result.FoundedOrders.Count > 0;
            bool haveItems = result.SameItems.Count > 1;

            if (haveOrder && !haveItems)
            {
                _signalBus.Fire(new GameSignals.ItemUnmarked()
                    {
                        OrderId = result.FoundedOrders[0].Id,
                        ItemShortCode = shortCode
                    }
                );
            }

            if (!result.Result)
                return;

            for (int i = 0; i < sameItems.Count; i++)
            {
                sameItems[i].Unmark();
            }
        }

        private List<OrderData> RandomOrderGenerate(int count, int minItemCount = 0, int maxItemCount = 2)
        {
            var orders = new List<OrderData>();

            for (int i = 0; i < count; i++)
            {
                var orderData = ScriptableObject.CreateInstance<OrderData>();
                orderData.Id = Guid.NewGuid().ToString();
                orderData.Items = new List<string>();
                int randomItemCount = Random.Range(minItemCount, maxItemCount);

                for (int j = 0; j <= randomItemCount; j++)
                {
                    var randomItem = _itemManager.GetRandomProductData();
                    orderData.Items.Add(randomItem.ShortCode);
                }

                orders.Add(orderData);
            }

            return orders;
        }

        private void OnServeRequested(GameSignals.ServeRequested signalData)
        {
            var orderData = signalData.OrderData;
            _data.Orders.Remove(orderData);
            for (int i = 0; i < orderData.Items.Count; i++)
            {
                var itemShortCode = orderData.Items[i];
                var item = _gridManager.GetItem(itemShortCode);
                _boardController.Serve(item.CurrentCell, signalData.View);
            }
        }

        private void OnOrderItemsServed(GameSignals.OrderItemsServed signalData)
        {
            if (GetAllOrder().Count > 0)
                return;

            RefillNewOrders().Forget();
        }

        public async UniTask RefillNewOrders()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(.5f));
            var orders = RandomOrderGenerate(4);
            _data.Orders = orders;

            _signalBus.Fire(new GameSignals.OrdersRefilled());
        }

        private void OnItemProduced(GameSignals.ItemProduced signalData)
        {
            MarkItems(signalData.Item.BaseData.ShortCode);
        }

        private void OnItemDestroyed(GameSignals.ItemDestroyed signalData)
        {
            UnmarkItems(signalData.Item.BaseData.ShortCode);
        }

        #endregion

        public struct TaskResult
        {
            public bool Result;
            public List<BaseItem> SameItems;
            public List<OrderData> FoundedOrders;
        }
    }
}