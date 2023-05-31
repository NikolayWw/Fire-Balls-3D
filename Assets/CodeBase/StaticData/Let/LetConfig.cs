using System;
using UnityEngine;

namespace CodeBase.StaticData.Let
{
    [Serializable]
    public class LetConfig
    {
        [SerializeField] private string _inspectorName;
        [field: SerializeField] public LetId Id { get; private set; }
        [field: SerializeField] public GameObject Prefab { get; private set; }

        public void OnValidate()
        {
            _inspectorName = Id.ToString();
        }
    }
}