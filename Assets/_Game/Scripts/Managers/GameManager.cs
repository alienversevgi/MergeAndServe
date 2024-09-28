using System;
using Cysharp.Threading.Tasks;
using MergeAndServe.UI;
using UnityEngine;
using Zenject;

namespace MergeAndServe.Game
{
    public class GameManager : MonoBehaviour
    {
        #region Fields

        [Inject] private GridManager _gridManager;
        [Inject] private DataManager _dataManager;
        [Inject] private ItemManager _itemManager;
        [Inject] private BoardController _boardController;
        [Inject] private TaskController _taskController;
        [Inject] private UIController _uiController;

        #endregion

        #region Unity Methods

        public void Start()
        {
            StartGame().Forget();
        }

        #endregion

        #region Private Methods

        private async UniTask StartGame()
        {
            _dataManager.Initialize();
            await _itemManager.Initialize(_dataManager.GridData.Collections);

            _gridManager.Initialize(_dataManager.GridData);
            _boardController.Initialize();
            _taskController.Initialize(_dataManager.TaskData);
            _uiController.Initialize();
            
        }

        #endregion
    }
}