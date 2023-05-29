using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData.Tower
{
    [CreateAssetMenu(menuName = "Static Data/Tower Static Data", order = 0)]
    public class TowerStaticData : ScriptableObject
    {
        public List<TowerConfig> TowerConfigs;

        private void OnValidate()
        {
            TowerConfigs.ForEach(x => x.OnValidate());
        }
    }
}