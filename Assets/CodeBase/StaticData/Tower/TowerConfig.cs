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
        [field: SerializeField] public float Height { get; private set; } = 5f;
        [field: SerializeField] public float StepHeight { get; private set; } = 1f;

        public void OnValidate()
        {
            _inspectorName = TowerId.ToString();

            if (Height < 0) Height = 0;
            if (StepHeight < 0) StepHeight = 0;
        }
    }
}