using MergeAndServe.Data;
using MergeAndServe.Factorys;
using MergeAndServe.Game;
using MergeAndServe.Services;
using MergeAndServe.Settings;
using MergeAndServe.Signals;
using UnityEngine;
using Zenject;

namespace MergeAndServe.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [Inject] private PrefabSettings _prefabSettings;

        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            BindSignals();
            BindPools();
            BindFactories();
            BindServices();
            BindManagers();
            BindControllers();

            Debug.Log("InstallBindings");
        }

        private void BindPools()
        {
            Container.BindMemoryPool<Product, Product.Pool>()
                .WithInitialSize(Const.PoolSizes.PRODUCT_SIZE)
                .FromComponentInNewPrefab(_prefabSettings.Product)
                .WithGameObjectName("Product")
                .UnderTransformGroup("Product_PoolHolder");

            Container.BindMemoryPool<Generator, Generator.Pool>()
                .WithInitialSize(Const.PoolSizes.GENERATOR_SIZE)
                .FromComponentInNewPrefab(_prefabSettings.Generator)
                .WithGameObjectName("Generator")
                .UnderTransformGroup("Generator_PoolHolder");
        }

        private void BindSignals()
        {
            Container.DeclareSignal<GameSignals.ItemDragReleased>().OptionalSubscriber();
            Container.DeclareSignal<GameSignals.MergeCompleted>().OptionalSubscriber();
            Container.DeclareSignal<GameSignals.ItemProduced>().OptionalSubscriber();
            Container.DeclareSignal<GameSignals.ItemDestroyed>().OptionalSubscriber();
            Container.DeclareSignal<GameSignals.ItemMarked>().OptionalSubscriber();
            Container.DeclareSignal<GameSignals.ItemUnmarked>().OptionalSubscriber();
            Container.DeclareSignal<GameSignals.OrderItemsServed>().OptionalSubscriber();
            Container.DeclareSignal<GameSignals.ServeRequested>().OptionalSubscriber();
            Container.DeclareSignal<GameSignals.BoardFull>().OptionalSubscriber();
            Container.DeclareSignal<GameSignals.OrdersRefilled>().OptionalSubscriber();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<OGAddressableService>().AsSingle();
        }

        private void BindManagers()
        {
            Container.BindInterfacesAndSelfTo<ItemManager>().AsSingle();
        }

        private void BindControllers()
        {
            Container.BindInterfacesAndSelfTo<TaskController>().AsSingle();
        }

        private void BindFactories()
        {
            Container.BindInterfacesAndSelfTo<ItemFactory>().AsSingle();
        }
    }
}