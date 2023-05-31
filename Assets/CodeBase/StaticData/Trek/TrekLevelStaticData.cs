using System;
using UnityEngine;

namespace CodeBase.StaticData.Trek
{
    [Serializable]
    public class TrekLevelStaticData
    {
        [field: SerializeField] public Vector3[] Points { get; private set; }

        public TrekLevelStaticData(Vector3[] points)
        {
            Points = points;
        }
    }
}