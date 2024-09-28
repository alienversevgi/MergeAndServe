using System;
using DG.Tweening;
using MergeAndServe.Data;
using MergeAndServe.Interfaces;
using MergeAndServe.Signals;
using UnityEngine;
using Zenject;

namespace MergeAndServe.Game
{
    public class Cell : MonoBehaviour, ISelectable, ITappable, IClaimable
    {
        #region Fields

        [SerializeField] private BoxCollider2D boxCollider;

        [Inject] private SignalBus _signalBus;

        public Enums.CellType Type
        {
            get => _cellData.Type;
            set => _cellData.Type = value;
        }
        public Vector2Int Position => _cellData.Position;
        public BaseItem HoldingBaseItem => _holdingBaseItem;

        private BaseItem _holdingBaseItem;
        private CellData _cellData;

        #endregion

        #region Public Methods

        public virtual void Initialize(CellData cellData)
        {
            _cellData = cellData;
        }

        public void SetHoldingItem(BaseItem baseItem)
        {
            Type = Enums.CellType.Filled;
            _holdingBaseItem = baseItem;
            _holdingBaseItem.SetCurrentCell(this);
            _cellData.ItemShortCode = _holdingBaseItem.BaseData.ShortCode;

            _holdingBaseItem.transform.SetParent(this.transform);
        }

        public void SetEmpty()
        {
            _holdingBaseItem = null;
            _cellData.ItemShortCode = String.Empty;
            Type = Enums.CellType.Empty;
        }

        public void DisposeItem()
        {
            _holdingBaseItem.Dispose();
            SetEmpty();
        }

        public float GetSize()
        {
            return boxCollider.size.x;
        }

        public void Select()
        {
        }

        public void SelectionCompleted()
        {
            PlaySelectionAnimation();
        }

        public void Deselect()
        {
        }

        public void Tap()
        {
            _holdingBaseItem?.Tap();
        }

        public void Mark()
        {
            _holdingBaseItem?.Mark();
        }

        public void Unmark()
        {
            _holdingBaseItem?.Unmark();
        }

        public void ExecuteMergeCompleteOperations()
        {
            PlaySelectionAnimation();
        }

        public void PullItem()
        {
            _holdingBaseItem.transform.DOLocalMove(Vector3.zero, .2f).SetEase(Ease.Linear);
        }

        #endregion

        #region Private Methods

        private void PlaySelectionAnimation()
        {
            if (_holdingBaseItem == null)
                return;

            var sequence = DOTween.Sequence();
            sequence.Append(_holdingBaseItem.transform.DOPunchScale(Vector3.one * .2f, .3f, 8, 0).SetEase(Ease.InOutElastic));
            sequence.Append(_holdingBaseItem.transform.DOPunchScale(Vector3.one * .1f, .2f, 2, 0).SetEase(Ease.InOutElastic));
            sequence.OnStart(() => _holdingBaseItem.transform.localScale = Vector3.one);
            sequence.Play();
        }

        #endregion
    }
}