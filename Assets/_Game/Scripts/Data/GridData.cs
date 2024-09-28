using System.Collections.Generic;
using UnityEngine;

namespace MergeAndServe.Data
{
    [CreateAssetMenu(fileName = nameof(GridData), menuName = Const.SOPath.SO_DATA_MENU_PATH + nameof(GridData))]
    public class GridData : ScriptableObject
    {
        public List<CellData> Cells;
        public int SizeX;
        public int SizeY;

        public List<string> Collections;
    }
}