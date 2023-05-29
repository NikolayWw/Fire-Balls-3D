using System;
using CodeBase.Bullet;
using UnityEngine;

namespace CodeBase.StaticData.Bullet
{
    [Serializable]
    public class BulletConfig
    {
        [SerializeField] private string _inspectorName;
        [field: SerializeField] public BulletId BulletId { get; private set; }
        [field: SerializeField] public BulletMove Prefab { get; private set; }

        public void OnValidate()
        {
            _inspectorName = BulletId.ToString();
        }
    }
}