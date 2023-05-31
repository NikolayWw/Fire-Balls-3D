using CodeBase.Logic;
using System;
using UnityEngine;

namespace CodeBase.Tower
{
    public class TowerApplyDamage : MonoBehaviour, IApplyDamage
    {
        public Action OnApplyDamage;

        public void ApplyDamage()
        {
            OnApplyDamage?.Invoke();
        }
    }
}