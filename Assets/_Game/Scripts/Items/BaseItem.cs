using System;
using Cysharp.Threading.Tasks;
using MergeAndServe.Data;
using MergeAndServe.Factorys;
using MergeAndServe.Interfaces;
using MergeAndServe.Services;
using UnityEngine;
using UnityEngine.Rendering;
using Zenject;

namespace MergeAndServe.Game
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(SortingGroup))]
    public abstract class BaseItem : MonoBehaviour, IDraggable, IDisposable, ITappable, IClaimable
    {
        #region Fields

        [SerializeField] private GameObject checkObject;
        
        [Inject] private OGAddressableService _addressableService;
        [Inject] private ItemFactory _itemFactory;

        public Cell CurrentCell { get; private set; }
        public Cell TriggeredCell { get; private set; }
        public ItemData BaseData { get; private set; }
        
        private SpriteRenderer _renderer;
        private SortingGroup _sortingGroup;
        private bool _isDragging;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            _sortingGroup = this.GetComponent<SortingGroup>();
            _renderer = this.GetComponent<SpriteRenderer>();
            _renderer.enabled = false;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (!_isDragging)
                return;

            TriggeredCell = null;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (!_isDragging)
                return;

            TriggeredCell = collision.GetComponent<Cell>();
        }

        #endregion

        #region Public Methods

        public virtual void Initialize(ItemData itemData)
        {
            BaseData = itemData;
            SetupView();
        }

        public void SetCurrentCell(Cell cell)
        {
            CurrentCell = cell;
        }

        public virtual void Drag(Vector2 position)
        {
            _sortingGroup.sortingOrder = 999;
            _isDragging = true;
            this.transform.position = position;
        }

        public virtual void Release()
        {
            ResetDrag();
        }

        public virtual void Tap()
        {
        }
        
        public void Mark()
        {
            checkObject.gameObject.SetActive(true);
        }

        public void Unmark()
        {
            checkObject.gameObject.SetActive(false);
        }

        public void SetCenterToCell()
        {
            this.transform.localPosition = Vector3.zero;
        }

        public void Dispose()
        {
            Unmark();
            CurrentCell = null;
            ResetDrag();
            _itemFactory.DisposeItem(this);
        }

        #endregion

        #region Protected Methods

        protected virtual void SetupView()
        {
            _addressableService.LoadItemSprite(BaseData.ShortCode,
                                               handle =>
                                               {
                                                   _renderer.sprite = handle.Result;
                                                   _renderer.enabled = true;
                                               }
                )
                .Forget();
        }

        #endregion

        #region Private Methods

        private void ResetDrag()
        {
            _isDragging = false;
            TriggeredCell = null;
            _sortingGroup.sortingOrder = 1;
        }

        #endregion
    }
}