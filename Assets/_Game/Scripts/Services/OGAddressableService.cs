using System;
using Cysharp.Threading.Tasks;
using MergeAndServe.Data;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace MergeAndServe.Services
{
    public class OGAddressableService : AddressableService
    {
        public async UniTask LoadItemSprite
        (
            string shortCode,
            Action<AsyncOperationHandle<Sprite>> onAssetLoaded
        )
        {
            string key = $"Sprites/{shortCode}";
            await LoadSprite(key, onAssetLoaded);
        }

        public async UniTask<T> LoadItemData<T>(string shortCode) where T : ItemData
        {
            string key = $"Items/{shortCode}";
            return await LoadScriptableObject<T>(key);
        }

        public async UniTask<ItemCollection> LoadItemCollectionData(string shortCode)
        {
            string key = $"{shortCode}_Collection";
            return await LoadScriptableObject<ItemCollection>(key);
        }
    }
}