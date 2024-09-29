using System.Collections.Generic;
using MergeAndServe.Data;
using MergeAndServe.Enums;
using MergeAndServe.Factorys;
using UnityEngine;
using MergeAndServe.Settings;
using MergeAndServe.Signals;
using Zenject;
using Random = UnityEngine.Random;

namespace MergeAndServe.Game
{
    public class GridManager : MonoBehaviour
    {
        #region Fields

        [Inject] private PrefabSettings _prefabSettings;
        [Inject] private DiContainer _diContainer;
        [Inject] private ItemFactory _itemFactory;
        [Inject] private SignalBus _signalBus;

        private int _rows;
        private int _columns;
        private float _cellSize;
        private List<Cell> _cells;
        private List<Cell> _closedCells;
        private List<Cell> _visitedCells;
        private Cell _cellPrefab;
        private Cell[,] _grid;
        private GridData _gridData;

        #endregion

        #region Public Methods

        public void Initialize(GridData gridData)
        {
            _gridData = gridData;
            _rows = Const.Grid.SIZE_X;
            _columns = Const.Grid.SIZE_Y;
            _cellPrefab = _prefabSettings.Cell;
            _cellSize = _cellPrefab.GetSize();

            SetupGrid();
        }

        public BaseItem CreateItem(string shortCode)
        {
            var item = _itemFactory.SpawnItem(shortCode);

            return item;
        }

        public Cell GetCell(int x, int y)
        {
            return _grid[x, y];
        }

        public Cell GetRandomCellOnGrid()
        {
            List<Cell> emptyCells = GetAvailableCells();
            int randomIndex = Random.Range(0, emptyCells.Count);
            Cell randomCell = emptyCells[randomIndex];

            return randomCell;
        }

        public Cell GetClosetEmptyCell(Cell currentCell)
        {
            Cell findingCell = null;
            int order = 1;

            List<Cell> neighbourCells = GetNeighbourCells(currentCell, order);

            while (neighbourCells.Count > 0 && order <= _columns)
            {
                for (int i = 0; i < neighbourCells.Count; i++)
                {
                    var cell = neighbourCells[i];
                    if (cell.Type == Enums.CellType.Empty)
                    {
                        findingCell = neighbourCells[i];
                        break;
                    }
                }

                if (findingCell is not null)
                    break;

                order++;
                neighbourCells = GetNeighbourCells(currentCell, order);
            }

            return findingCell;
        }

        public List<Cell> GetNeighbourCells(Cell currentCell, int order)
        {
            List<Cell> neighbours = new List<Cell>();

            for (int x = -order; x <= order; x++)
            {
                for (int y = order; y >= -order; y--)
                {
                    if (Mathf.Abs(x) < order && Mathf.Abs(y) < order)
                        continue;

                    var neighbourPosition = new Vector2Int(x, y);
                    neighbourPosition += currentCell.Position;

                    bool isInGridRange = (neighbourPosition.x < _rows && neighbourPosition.x >= 0) &&
                        (neighbourPosition.y < _columns && neighbourPosition.y >= 0);

                    if (!isInGridRange)
                        continue;

                    var neighbourCell = GetCell(neighbourPosition.x, neighbourPosition.y);
                    neighbours.Add(neighbourCell);
                }
            }

            return neighbours;
        }

        public void SetToCellCenter(Cell cell, BaseItem item)
        {
            PutToCell(cell, item);
            item.SetCenterToCell();
        }

        public void PutToCell
        (
            Cell cell,
            BaseItem item,
            bool isResetFromCell = true
        )
        {
            if (isResetFromCell)
                item.CurrentCell?.SetEmpty();

            cell.SetHoldingItem(item);
        }

        public void DisposeCellItem(Cell cell)
        {
            _signalBus.Fire(new GameSignals.ItemDestroyed()
                            {
                                Item = cell.HoldingBaseItem
                            }
            );

            cell.DisposeItem();
        }

        public BaseItem GetItem(string shortCode)
        {
            BaseItem item = null;
            for (int i = 0; i < _cells.Count; i++)
            {
                if (_cells[i].Type == CellType.Empty)
                    continue;

                if (_cells[i].HoldingBaseItem.BaseData.ShortCode == shortCode)
                {
                    item = _cells[i].HoldingBaseItem;
                    break;
                }
            }

            return item;
        }

        public List<BaseItem> GetAllItem(string shortCode)
        {
            List<BaseItem> items = new List<BaseItem>();
            for (int i = 0; i < _cells.Count; i++)
            {
                if (_cells[i].Type == CellType.Empty)
                    continue;

                if (_cells[i].HoldingBaseItem.BaseData.ShortCode == shortCode)
                {
                    items.Add(_cells[i].HoldingBaseItem);
                }
            }

            return items;
        }

        public List<BaseItem> GetAllItems(params string[] shortCodes)
        {
            List<BaseItem> items = new List<BaseItem>();
            for (int i = 0; i < _cells.Count; i++)
            {
                if (_cells[i].Type == CellType.Empty)
                    continue;

                for (int j = 0; j < shortCodes.Length; j++)
                {
                    var itemShortCode = _cells[i].HoldingBaseItem.BaseData.ShortCode;
                    if (itemShortCode.Equals(shortCodes[j]))
                    {
                        items.Add(_cells[i].HoldingBaseItem);
                    }
                }
            }

            return items;
        }

        public List<BaseItem> GetUniqueItems()
        {
            List<BaseItem> uniqueItems = new List<BaseItem>();
            for (int i = 0; i < _cells.Count; i++)
            {
                var cell = _cells[i];
                if (cell.Type != CellType.Filled)
                    continue;

                bool isFounded = false;
                for (int j = 0; j < uniqueItems.Count; j++)
                {
                    var uniqueItem = uniqueItems[j];
                    var currentShortCode = cell.HoldingBaseItem.BaseData.ShortCode;
                    var uniqueShortCode = uniqueItem.BaseData.ShortCode;

                    if (string.Equals(uniqueShortCode, currentShortCode))
                    {
                        isFounded = true;
                        break;
                    }
                }

                if (!isFounded)
                    uniqueItems.Add(cell.HoldingBaseItem);
            }

            return uniqueItems;
        }

        public List<Cell> GetAllCells()
        {
            return _cells;
        }

        #endregion

        #region Private Methods

        private void SetupGrid()
        {
            _cells = new List<Cell>();
            _grid = new Cell[_columns, _rows];

            CreateGrid();
            InitializeCells();

            void CreateGrid()
            {
                for (int y = 0; y < _columns; y++)
                {
                    for (int x = 0; x < _rows; x++)
                    {
                        var cell = InstantiateCell(x, y);
                        _grid[x, y] = cell;
                    }
                }
            }

            void InitializeCells()
            {
                for (int i = 0; i < _gridData.Cells.Count; i++)
                {
                    var cellData = _gridData.Cells[i];
                    var cell = GetCell(cellData.Position.x, cellData.Position.y);
                    cell.Initialize(cellData);
                    switch (cellData.Type)
                    {
                        case CellType.Empty:
                            break;
                        case CellType.Filled:
                            var item = CreateItem(cellData.ItemShortCode);
                            SetToCellCenter(cell, item);

                            _signalBus.Fire(new GameSignals.ItemProduced()
                                            {
                                                Item = item
                                            }
                            );
                            break;
                        case CellType.Locked:
                            break;
                    }
                }

            }

            Cell InstantiateCell(int x, int y)
            {
                var cell = _diContainer.InstantiatePrefabForComponent<Cell>(_cellPrefab, this.transform);
                cell.transform.position = GetPosition(x, y);
                cell.name = x + "-" + y;
                _cells.Add(cell);

                return cell;
            }
        }

        private Vector2 GetPosition(int x, int y)
        {
            float width = _rows * _cellSize;
            float height = _columns * _cellSize;

            float currentX = -width * 0.5f + (x * _cellSize + _cellSize * 0.5f);
            float currentY = -height * 0.5f + (y * _cellSize + _cellSize * 0.5f);

            Vector2 newPosition = new Vector2(currentX, currentY);

            return newPosition;
        }

        private List<Cell> GetAvailableCells()
        {
            List<Cell> result = new List<Cell>();
            for (int i = 0; i < _cells.Count; i++)
            {
                if (_cells[i].Type == Enums.CellType.Empty)
                {
                    result.Add(_cells[i]);
                }
            }

            return result;
        }

        #endregion
    }
}