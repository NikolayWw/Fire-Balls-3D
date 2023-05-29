using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Logic;
using CodeBase.Services;
using CodeBase.Services.Input;
using CodeBase.Services.StaticData;
using CodeBase.UI.Services.Factory;
using CodeBase.UI.Services.Window;

namespace CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string InitScene = "Initial";
        private const string MainScene = "Main";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;

            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(InitScene, OnLoaded);
        }

        public void Exit()
        { }

        private void RegisterServices()
        {
            _services.RegisterSingle<IGameStateMachine>(_stateMachine);
            RegisterStaticData();
            _services.RegisterSingle<IInputService>(new InputService());
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssetProvider>()));
            _services.RegisterSingle<IUIFactory>(new UIFactory(_services.Single<IAssetProvider>(), _services.Single<IStaticDataService>()));
            _services.RegisterSingle<IWindowService>(new WindowService(_services.Single<IUIFactory>()));
        }

        private void OnLoaded()
        {
            _stateMachine.Enter<LoadLevelState, string>(MainScene);
        }

        private void RegisterStaticData()
        {
            var service = new StaticDataService();
            service.Load();
            _services.RegisterSingle<IStaticDataService>(service);
        }
    }
}