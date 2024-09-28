namespace MergeAndServe.Data
{
    public static class Const
    {
        public const float DRAG_THRESHOLD = 0.5f;
        
        public static class SOPath
        {
            public const string SO_DATA_MENU_PATH = "Game/Data/SO/";
            public const string SO_INSTALLER_MENU_PATH = "Game/Data/Installers";
            public const string SO_SETTINGS_MENU_PATH = "Game/Data/Settings/";
        }

        public static class PoolSizes
        {
            public const int PRODUCT_SIZE = 10;
            public const int GENERATOR_SIZE = 10;
        }

        public static class DataPrefKey
        {
            public const string GRID_DATA = "GridData";
            public const string TASK_DATA = "TaskData";
        }
    }
}