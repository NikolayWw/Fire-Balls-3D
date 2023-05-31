using CodeBase.Logic;
using System;
using UnityEngine;

namespace CodeBase.Obstacle
{
    public class ObstacleSegmentApplyDamageReporter : MonoBehaviour, IApplyDamage
    {
        public Action OnApplyDamage;

        public void ApplyDamage()
        {
            OnApplyDamage?.Invoke();
        }
    }
}