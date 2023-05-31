using System;
using UnityEngine;

namespace CodeBase.StaticData.Tower
{
    [Serializable]
    public class TowerLevelStaticData
    {
        [SerializeField] private string _inspectorName;
        [field: SerializeField] public TowerId TowerId { get; private set; }
        [field: SerializeField] public Vector3 Position { get; private set; }

        public TowerLevelStaticData(TowerId towerId, Vector3 position)
        {
            TowerId = towerId;
            Position = position;
        }

        public void OnValidate()
        {
            _inspectorName = TowerId.ToString();
        }
    }
}