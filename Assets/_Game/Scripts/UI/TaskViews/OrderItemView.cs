using Cysharp.Threading.Tasks;
using MergeAndServe.Interfaces;
using MergeAndServe.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MergeAndServe.UI
{
    public class OrderItemView : BaseUIView,IClaimable
    {
        #region Fields

        [SerializeField] private Image image;
        [SerializeField] private GameObject tick;
        
        [Inject] private OGAddressableService _addressableService;

        public bool IsMarked { get; private set; }
        public string ItemShortCode { get; private set; }
        
        public bool IsServed { get; private set; }
        public RectTransform FlyTarget => image.rectTransform;

        #endregion

        #region Public Methods

        public void Initialize(string itemShortCode)
        {
            ItemShortCode = itemShortCode;
            IsServed = false;
            SetupUI();
        }
        
        public void Mark()
        {
            IsMarked = true;
            SetReadyState(true);
        }

        public void Unmark()
        {
            IsMarked = false;
            SetReadyState(false);
        }
        
        public void CompleteServe()
        {
            IsServed = true;
        }
        
        #endregion

        #region Private Methods

        private void SetupUI()
        {
            _addressableService.LoadItemSprite(ItemShortCode,
                                               (handle) =>
                                               {
                                                   image.sprite = handle.Result;
                                               }
                )
                .Forget();
        }
        
        private void SetReadyState(bool isReady)
        {
            tick.SetActive(isReady);
        }

        #endregion
    }
}