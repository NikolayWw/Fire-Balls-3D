using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData.Levels
{
    [CreateAssetMenu(menuName = "Static Data/Levels Static Data")]
    public class LevelsStaticData : ScriptableObject
    {
        public List<LevelConfig> LevelConfigs;

        private void OnValidate()
        {
            LevelConfigs.ForEach(x => x.OnValidate());
        }
    }
}