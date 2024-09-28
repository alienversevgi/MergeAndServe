using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace MergeAndServe.Services
{
    public class AddressableService
    {
        public async UniTask LoadSprite(string key, Action<AsyncOperationHandle<Sprite>> onAssetLoaded)
        {
            var operationHandle = Addressables.LoadAssetAsync<Sprite>($"{key}.png");
            await operationHandle;

            if (operationHandle.Status == AsyncOperationStatus.Succeeded)
            {
                onAssetLoaded.Invoke(operationHandle);
            }
        }

        public async UniTask LoadScriptableObject<T>
            (string key, Action<AsyncOperationHandle<T>> onAssetLoaded) where T : ScriptableObject
        {
            var operationHandle = Addressables.LoadAssetAsync<T>($"{key}.asset");
            await operationHandle;

            if (operationHandle.Status == AsyncOperationStatus.Succeeded)
            {
                onAssetLoaded.Invoke(operationHandle);
            }
        }

        public async UniTask<T> LoadScriptableObject<T>(string key) where T : ScriptableObject
        {
            var operationHandle = Addressables.LoadAssetAsync<T>($"{key}.asset");
            return await operationHandle;
        }

        public async UniTask<T> LoadAssetReference<T>(AssetReference reference)
        {
            var operationHandle = Addressables.LoadAssetAsync<T>(reference);
            return await operationHandle;
        }
    }
}