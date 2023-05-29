using CodeBase.StaticData.Tower;
using System;
using UnityEngine;

namespace CodeBase.StaticData.Levels
{
    [Serializable]
    public class LevelConfig
    {
        [field: SerializeField] public string LevelKey { get; private set; }
        [field: SerializeField] public TowerId TowerId { get; private set; }
    }
}