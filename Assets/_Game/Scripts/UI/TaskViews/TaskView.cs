using System;
using System.Collections.Generic;
using MergeAndServe.Data;
using MergeAndServe.Game;
using MergeAndServe.Signals;
using UnityEngine;
using Zenject;

namespace MergeAndServe.UI
{
    public class TaskView : BaseUIView, IDisposable
    {
        #region Fields

        [SerializeField] private OrderView prefab;
        [SerializeField] private Transform container;

        [Inject] private TaskController _taskController;
        [Inject] private DiContainer _diContainer;

        private List<OrderData> _orders;
        private Dictionary<int, OrderView> _orderViews;

        #endregion

        #region Public Methods

        public void Initialize()
        {
            _orders = _taskController.GetAllOrder();
            SetupUI();
            SignalBus.Subscribe<GameSignals.ItemMarked>(OnItemMarked);
            SignalBus.Subscribe<GameSignals.ItemUnmarked>(OnItemUnmarked);
            SignalBus.Subscribe<GameSignals.OrderItemsServed>(OnOrderItemsServed);

            _taskController.MarkOrderItems();
        }
        
        public void Dispose()
        {
            SignalBus.TryUnsubscribe<GameSignals.ItemMarked>(OnItemMarked);
            SignalBus.TryUnsubscribe<GameSignals.ItemUnmarked>(OnItemUnmarked);
        }
        
        #endregion

        #region Private Methods

        private void OnOrderItemsServed(GameSignals.OrderItemsServed signalData)
        {
            _orderViews[signalData.Id].CompleteServe();
            _orderViews.Remove(signalData.Id);
        }

        private void OnItemUnmarked(GameSignals.ItemUnmarked signalData)
        {
            OrderView view;
            if (_orderViews.TryGetValue(signalData.OrderId, out view))
            {
                view.UnmarkItem(signalData.ItemShortCode);
            }
        }

        private void OnItemMarked(GameSignals.ItemMarked signalData)
        {
            OrderView view;
            if (_orderViews.TryGetValue(signalData.OrderId, out view))
            {
                view.MarkItem(signalData.ItemShortCode);
            }
        }

        private void SetupUI()
        {
            _orderViews = new Dictionary<int, OrderView>();
            for (int i = 0; i < _orders.Count; i++)
            {
                var data = _orders[i];
                var orderView = _diContainer.InstantiatePrefabForComponent<OrderView>(prefab, container);
                orderView.Initialize(data);

                _orderViews.Add(data.Id, orderView);
            }
        }

        #endregion
    }
}