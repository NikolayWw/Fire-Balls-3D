using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData.Bullet
{
    [CreateAssetMenu(menuName = "Static Data/Bullet Static Data", order = 0)]
    public class BulletStaticData : ScriptableObject
    {
        [field: SerializeField] public int PoolCount { get; private set; } = 20;
        [field: SerializeField] public float LifeTime { get; private set; } = 5f;

        public List<BulletConfig> BulletConfigs;

        private void OnValidate()
        {
            BulletConfigs.ForEach(x => x.OnValidate());

            if (LifeTime < 0) LifeTime = 0;
            if (PoolCount < 0) PoolCount = 0;
        }
    }
}