using CodeBase.Services.Factory;
using CodeBase.Services.StaticData;
using CodeBase.StaticData.Levels;
using UnityEngine;

namespace CodeBase.Let
{
    public class LetBuilder
    {
        private readonly IGameFactory _gameFactory;
        private readonly LevelConfig _levelConfig;

        public LetBuilder(IGameFactory gameFactory, LevelConfig levelConfig)
        {
            _gameFactory = gameFactory;
            _levelConfig = levelConfig;
        }

        public void Build()
        {
            _gameFactory.CreateLet(_levelConfig.LetId, Vector3.zero);
        }
    }
}