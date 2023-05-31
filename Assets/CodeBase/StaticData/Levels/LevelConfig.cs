using CodeBase.StaticData.Tower;
using System;
using CodeBase.StaticData.Let;
using UnityEngine;

namespace CodeBase.StaticData.Levels
{
    [Serializable]
    public class LevelConfig
    {
        [field: SerializeField] public string LevelKey { get; private set; }
        [field: SerializeField] public TowerId TowerId { get; private set; }
        [field: SerializeField] public LetId LetId { get; private set; }
        [field: SerializeField] public float LetMoveSpeed { get; private set; } = 5f;
    }
}