using System;
using UnityEngine;

namespace CodeBase.StaticData.Tower
{
    [Serializable]
    public class TowerConfig
    {
        [SerializeField] private string _inspectorName;
        [field: SerializeField] public TowerId TowerId { get; private set; }
        [field: SerializeField] public GameObject TowerPrefab { get; private set; }

        public void OnValidate()
        {
            _inspectorName = TowerId.ToString();
        }
    }
}