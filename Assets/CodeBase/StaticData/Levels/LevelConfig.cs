using CodeBase.StaticData.Tower;
using CodeBase.StaticData.Trek;
using System;
using UnityEngine;

namespace CodeBase.StaticData.Levels
{
    [Serializable]
    public class LevelConfig
    {
        [field: SerializeField] public string LevelKey { get; private set; }
        [field: SerializeField] public float ObstacleMoveSpeed { get; private set; } = 5f;
        [field: SerializeField] public Vector3 PlayerInitialPosition { get; private set; }
        [field: SerializeField] public TrekLevelStaticData[] TrekLevelStaticData { get; private set; }
        [field: SerializeField] public TowerLevelStaticData[] TowerLevelStaticData { get; private set; }

        public void OnValidate()
        {
            Validate();
        }

        public void SetData(Vector3 playerInitialPosition, TrekLevelStaticData[] trekLevelStaticData, TowerLevelStaticData[] towerLevelStaticData)
        {
            PlayerInitialPosition = playerInitialPosition;
            TrekLevelStaticData = trekLevelStaticData;
            TowerLevelStaticData = towerLevelStaticData;
            Validate();
        }

        private void Validate()
        {
            foreach (TowerLevelStaticData staticData in TowerLevelStaticData)
                staticData.OnValidate();
        }
    }
}