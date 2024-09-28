using MergeAndServe.Data;
using UnityEngine;

namespace MergeAndServe.Settings
{
    [CreateAssetMenu(fileName = nameof(GameSettings), menuName = Const.SOPath.SO_SETTINGS_MENU_PATH + nameof(GameSettings), order = 1)]
    public class GameSettings : ScriptableObject
    {
        public GridData StarterGrid;
        public TaskData StarterTaskData;
    }
}