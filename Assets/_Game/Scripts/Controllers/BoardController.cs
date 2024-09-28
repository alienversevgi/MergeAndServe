using System;
using DG.Tweening;
using MergeAndServe.Data;
using UnityEngine;
using MergeAndServe.Signals;
using MergeAndServe.UI;
using Unity.VisualScripting;
using Zenject;

namespace MergeAndServe.Game
{
    public class BoardController : MonoBehaviour, IDisposable
    {
        #region Fields

        [Inject] private GridManager _gridManager;
        [Inject] private SignalBus _signalBus;
        [Inject] private ItemManager _itemManager;

        #endregion

        #region Public Methods

        public void Initialize()
        {
            SubscribeEvents();
        }

        public void CreateItemToClosetPoint(Cell cell, string shortCode)
        {
            var emptyCell = _gridManager.GetClosetEmptyCell(cell);

            if (emptyCell is null)
            {
                Debug.Log("Board is full!");
                _signalBus.Fire(new GameSignals.BoardFull());
            }
            else
            {
                var item = _gridManager.CreateItem(shortCode);
                item.transform.position = cell.transform.position;
                ThrowToCell(emptyCell, item);

                _signalBus.Fire(new GameSignals.ItemProduced()
                                {
                                    Item = item
                                }
                );
            }
        }

        public void Dispose()
        {
            _signalBus.TryUnsubscribe<GameSignals.ItemDragReleased>(OnItemDragReleased);
        }

        #endregion

        #region Private Methods

        private void SubscribeEvents()
        {
            _signalBus.Subscribe<GameSignals.ItemDragReleased>(OnItemDragReleased);
        }

        private void OnItemDragReleased(GameSignals.ItemDragReleased signalData)
        {
            ExecuteIntersectOperation(signalData.Current, signalData.Triggered);
        }

        private void ExecuteIntersectOperation(Cell from, Cell to)
        {
            if (to == null || from.Equals(to))
            {
                ReturnToCell(from);
                return;
            }

            switch (to.Type)
            {
                case Enums.CellType.Empty:
                    MoveToCell(to, from.HoldingBaseItem);
                    break;
                case Enums.CellType.Filled:
                    if (IsMergeable(from, to))
                    {
                        MergeCell(from, to);
                    }
                    else
                    {
                        SwapToCell(from, to);
                    }

                    break;
                case Enums.CellType.Locked:
                    ReturnToCell(from);
                    break;
            }
        }

        private void ThrowToCell
        (
            Cell cell,
            BaseItem item,
            bool isResetFromCell = true
        )
        {
            _gridManager.PutToCell(cell, item, isResetFromCell);

            var sequence = DOTween.Sequence();
            sequence.Append(item.transform.DOLocalMove(Vector3.zero, .4f));
            sequence.Join(item.transform.DOScale(Vector3.one * 1.5f, .15f));
            sequence.Append(item.transform.DOScale(Vector3.one, .15f));
            sequence.Play();
        }

        private void MoveToCell
        (
            Cell cell,
            BaseItem item,
            bool isResetFromCell = true
        )
        {
            _gridManager.PutToCell(cell, item, isResetFromCell);
            cell.PullItem();
        }

        private void SwapToCell(Cell from, Cell to)
        {
            var fromItem = from.HoldingBaseItem;
            var toItem = to.HoldingBaseItem;

            MoveToCell(from, toItem, false);
            MoveToCell(to, fromItem, false);
        }

        private void ReturnToCell(Cell cell)
        {
            cell.PullItem();
        }

        public void Serve(Cell cell, OrderView view)
        {
            var item = _gridManager.CreateItem(cell.HoldingBaseItem.BaseData.ShortCode);
            item.transform.position = cell.HoldingBaseItem.transform.position;
            item.Mark();

            _gridManager.DisposeCellItem(cell);
            var target = view.GetItemTargetRect(item.BaseData.ShortCode);
            item.transform.DOMove(target.position, .5f)
                .SetEase(Ease.InOutQuad)
                .OnComplete(() =>
                    {
                        view.CompleteServeItem(item.BaseData.ShortCode);
                        item.Dispose();
                    }
                );
        }

        private void MergeCell(Cell from, Cell to)
        {
            var fromItem = from.HoldingBaseItem;
            var nextItem = _itemManager.GetNextItemData(fromItem.BaseData.ShortCode);

            _gridManager.DisposeCellItem(from);
            _gridManager.DisposeCellItem(to);

            var item = _gridManager.CreateItem(nextItem.ShortCode);
            _gridManager.SetToCellCenter(to, item);
            to.ExecuteMergeCompleteOperations();

            _signalBus.Fire(new GameSignals.ItemProduced()
                            {
                                Item = item
                            }
            );
        }

        private bool IsMergeable(Cell from, Cell to)
        {
            var fromData = from.HoldingBaseItem.BaseData;
            var toData = to.HoldingBaseItem.BaseData;
            bool isSameItem = fromData.ShortCode == toData.ShortCode;
            var nextItem = _itemManager.GetNextItemData(fromData.ShortCode);
            bool isReachedToMaxLevel = nextItem is null;

            return isSameItem && !isReachedToMaxLevel;
        }

        #endregion
    }
}