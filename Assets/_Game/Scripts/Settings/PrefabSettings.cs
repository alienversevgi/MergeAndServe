using MergeAndServe.Data;
using MergeAndServe.Game;
using UnityEngine;

namespace MergeAndServe.Settings
{
    [CreateAssetMenu(fileName = nameof(PrefabSettings), menuName = Const.SOPath.SO_SETTINGS_MENU_PATH + nameof(PrefabSettings), order = 1)]
    public class PrefabSettings : ScriptableObject
    {
        public Product Product;
        public Generator Generator;
        public Cell Cell;
    }
}