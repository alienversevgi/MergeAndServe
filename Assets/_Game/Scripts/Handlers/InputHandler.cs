using MergeAndServe.Data;
using MergeAndServe.Signals;
using UnityEngine;
using Zenject;

namespace MergeAndServe.Game
{
    public class InputHandler : MonoBehaviour
    {
        #region Fields

        [Inject] private SignalBus _signalBus;
        [Inject] private Camera _camera;

        private BaseItem _draggingItem;
        private Cell _detectedCell;
        private Cell _selectedCell;
        private Cell _tappedCell;

        private Vector2 _firstTouchPoint;
        private Vector2 _mousePosition;
        private bool _isDraggingPossible;
        private int _selectCount;

        private LayerMask _cellLayerMask => LayerMask.GetMask("Cell");

        #endregion

        #region Unity Methods

        private void Update()
        {
            HandleMouseDown();
            HandleMouseDrag();
            HandleMouseUp();
        }

        #endregion

        #region Private Methods

        private void HandleMouseDown()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                _firstTouchPoint = _mousePosition;

                var cell = FireRaycast();

                if (cell is null || cell.Type == Enums.CellType.Empty)
                {
                    Deselect();
                    return;
                }

                _draggingItem = cell.HoldingBaseItem;
                _detectedCell = null;
                Select(cell);
            }
        }

        private void HandleMouseDrag()
        {
            if (Input.GetMouseButton(0))
            {
                _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                _isDraggingPossible = (_firstTouchPoint - _mousePosition).magnitude > Const.DRAG_THRESHOLD;

                if (_draggingItem is null || !_isDraggingPossible)
                    return;

                _selectedCell?.Deselect();
                DetectCell();
                _draggingItem.Drag(_mousePosition);
            }
        }

        private void HandleMouseUp()
        {
            if (Input.GetMouseButtonUp(0))
            {
                HandleTap();

                if (CompleteSelection())
                    return;

                CompleteDrag();
            }
        }

        private void CompleteDrag()
        {
            _signalBus.Fire(new GameSignals.ItemDragReleased
            {
                Current = _draggingItem.CurrentCell,
                Triggered = _detectedCell
            });

            _draggingItem.Release();
            _draggingItem = null;
            _isDraggingPossible = false;
        }

        private bool CompleteSelection()
        {
            if (_draggingItem is null || !_isDraggingPossible)
            {
                _selectedCell?.SelectionCompleted();
                return true;
            }

            var tempCell = _selectedCell;
            _selectedCell = _detectedCell;
            if (tempCell == _detectedCell)
            {
                _selectedCell?.SelectionCompleted();
            }

            return false;
        }

        private void HandleTap()
        {
            if (_selectCount < 2 || _isDraggingPossible || _selectedCell is null)
                return;

            var cell = FireRaycast();
            if (cell is null || cell != _selectedCell)
                return;

            _tappedCell = cell;
            _selectedCell.Select();
            _tappedCell.Tap();
        }

        private void Select(Cell cell)
        {
            if (_selectedCell != null && _selectedCell != cell)
            {
                Deselect();
            }

            _selectedCell = cell;
            _selectedCell.Select();
            _selectCount++;
        }

        private void Deselect()
        {
            if (_selectedCell is null)
                return;

            _selectCount = 0;
            _selectedCell?.Deselect();
            _selectedCell = null;
        }

        private void DetectCell()
        {
            var cell = FireRaycast();
            _detectedCell = cell;
        }

        private Cell FireRaycast()
        {
            _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(_mousePosition, Vector2.zero, 1.0f, _cellLayerMask);
            if (hit.collider is null)
            {
                return null;
            }

            if (hit.collider.TryGetComponent(out Cell cell))
            {
                return cell;
            }

            return null;
        }

        #endregion
    }
}