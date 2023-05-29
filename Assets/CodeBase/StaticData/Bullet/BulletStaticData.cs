using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData.Bullet
{
    [CreateAssetMenu(menuName = "Static Data/Bullet Static Data", order = 0)]
    public class BulletStaticData : ScriptableObject
    {
        [field: SerializeField] public float ShootForce { get; private set; } = 20f;
       // [field: SerializeField] public float LifeTime { get; private set; } = 5f;
        public List<BulletConfig> BulletConfigs;

        private void OnValidate()
        {
            BulletConfigs.ForEach(x => x.OnValidate());

            if (ShootForce < 0) ShootForce = 0;
            //if (LifeTime < 0) LifeTime = 0;
        }
    }
}