using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Tower
{
    public class TowerApplyDamage : MonoBehaviour, IApplyDamage
    {
        public void ApplyDamage()
        {
            Debug.Log("Tower Apply Damage");
        }
    }
}