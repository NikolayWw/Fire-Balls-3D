using CodeBase.Logic;
using System;
using UnityEngine;

namespace CodeBase.Obstacle
{
    public class ObstacleSegmentBulletTouchReporter : MonoBehaviour, IBulletTouch
    {
        public Action OnApplyDamage;

        public void BulletTouch()
        {
            OnApplyDamage?.Invoke();
        }
    }
}