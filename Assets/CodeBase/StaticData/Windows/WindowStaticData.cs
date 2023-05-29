using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData.Windows
{
    [CreateAssetMenu(menuName = "Static Data/Window Static Data")]
    public class WindowStaticData : ScriptableObject
    {
        [field: SerializeField] public List<WindowConfig> Configs { get; private set; }

        private void OnValidate()
        {
            Configs.ForEach(x => x.Validate());
        }
    }
}