using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData.Let
{
    [CreateAssetMenu(menuName = "Static Data/Let Static Data", order = 0)]
    public class LetStaticData : ScriptableObject
    {
        public List<LetConfig> LetConfigs;

        private void OnValidate()
        {
            LetConfigs.ForEach(x => x.OnValidate());
        }
    }
}