using CodeBase.Infrastructure.Logic;
using CodeBase.Services.Factory;
using CodeBase.Services.StaticData;
using CodeBase.StaticData.Levels;
using CodeBase.UI.Services.Factory;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayloadState<string>
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;
        private readonly IUIFactory _uiFactory;
        private readonly IStaticDataService _dataService;

        private string _activeSceneName;

        public LoadLevelState(IGameStateMachine stateMachine, SceneLoader sceneLoader, LoadCurtain loadingCurtain, IGameFactory gameFactory, IUIFactory uiFactory, IStaticDataService dataService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
            _uiFactory = uiFactory;
            _dataService = dataService;
        }

        public void Enter(string sceneName)
        {
            _activeSceneName = sceneName;
            _loadingCurtain.Show();
            Clean();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            _loadingCurtain.Hide();
        }

        private void OnLoaded()
        {
            GetLevelConfig(_activeSceneName, out LevelConfig levelConfig);

            _uiFactory.CreateUIRoot();

            _gameFactory.CreateTower(levelConfig.TowerId, Vector3.zero);
            _stateMachine.Enter<LoopState>();
        }

        private void GetLevelConfig(string activeSceneName, out LevelConfig levelConfig)
        {
            levelConfig = _dataService.ForLevel(activeSceneName);
        }

        private void Clean()
        {
            _uiFactory.Clean();
        }
    }
}