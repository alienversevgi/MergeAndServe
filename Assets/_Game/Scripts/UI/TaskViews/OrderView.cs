using System;
using System.Collections.Generic;
using MergeAndServe.Data;
using MergeAndServe.Game;
using MergeAndServe.Services;
using MergeAndServe.Signals;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MergeAndServe.UI
{
    public class OrderView : BaseUIView, IDisposable
    {
        #region Fields

        [SerializeField] private OrderItemView itemViewPrefab;
        [SerializeField] private Transform container;

        [SerializeField] private Button confirmButton;

        [Inject] private OGAddressableService _addressableService;
        [Inject] private DiContainer _diContainer;
        [Inject] private TaskController _taskController;

        private OrderData _orderData;
        private List<OrderItemView> _orderItemViews;

        #endregion

        #region Public Methods

        public void Initialize(OrderData orderData)
        {
            _orderData = orderData;
            SetupUI();
            confirmButton.onClick.RemoveAllListeners();
            confirmButton.onClick.AddListener(OnServeButtonClicked);
        }

        public void MarkItem(string shortCode)
        {
            GetOrder(shortCode).Mark();
            SetReadyState(IsServeActive());
        }

        public void UnmarkItem(string shortCode)
        {
            GetOrder(shortCode).Unmark();
            SetReadyState(IsServeActive());
        }

        public RectTransform GetItemTargetRect(string shortCode)
        {
            return GetOrder(shortCode).FlyTarget;
        }

        public void CompleteServeItem(string shortCode)
        {
            GetOrder(shortCode).CompleteServe();

            if (IsAllItemServed())
            {
                SignalBus.Fire(new GameSignals.OrderItemsServed()
                               {
                                   Id = _orderData.Id
                               }
                );
            }
        }

        public void CompleteServe()
        {
            Dispose();
        }

        public void Dispose()
        {
            Destroy(this.gameObject);
        }

        #endregion

        #region Private Methods

        private void SetupUI()
        {
            _orderItemViews = new List<OrderItemView>();

            for (int i = 0; i < _orderData.Items.Count; i++)
            {
                var shortCode = _orderData.Items[i];
                var itemView = _diContainer.InstantiatePrefabForComponent<OrderItemView>(itemViewPrefab, container);
                itemView.Initialize(shortCode);
                _orderItemViews.Add(itemView);
            }
        }

        private void OnServeButtonClicked()
        {
            confirmButton.gameObject.SetActive(false);
            SignalBus.Fire(new GameSignals.ServeRequested()
                           {
                               OrderData = _orderData,
                               View = this
                           }
            );
        }

        private OrderItemView GetOrder(string shortCode)
        {
            OrderItemView result = null;
            for (int i = 0; i < _orderItemViews.Count; i++)
            {
                if (_orderItemViews[i].ItemShortCode.Equals(shortCode))
                {
                    result = _orderItemViews[i];
                    break;
                }
            }

            return result;
        }

        private void SetReadyState(bool isReady)
        {
            confirmButton.gameObject.SetActive(isReady);
        }

        private bool IsServeActive()
        {
            bool result = true;
            for (int i = 0; i < _orderItemViews.Count; i++)
            {
                if (!_orderItemViews[i].IsMarked)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        private bool IsAllItemServed()
        {
            bool result = true;
            for (int i = 0; i < _orderItemViews.Count; i++)
            {
                if (!_orderItemViews[i].IsServed)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        #endregion
    }
}