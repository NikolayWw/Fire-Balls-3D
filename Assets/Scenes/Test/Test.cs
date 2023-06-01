using System;
using CodeBase.Data.Extension;
using UnityEngine;

namespace Scenes.Test
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private Pro[] vs;

        //private void Start()
        //{
        //   ToBubbleSort(vs);
        //}

        //private void ToBubbleSort(Array[] array)
        //{
        //    Pro temp;
        //    for (int i = 0; i < array.Length; i++)
        //        for (int j = 0; j < array.Length - 1 - i; j++)
        //            if (array[j].index > array[j + 1].index)
        //            {
        //                temp = array[j];
        //                array[j] = array[j + 1];
        //                array[j + 1] = temp;
        //            }
        //}
    }
    [Serializable]
    public class Pro
    {
        public int index;
        public bool Wwww = true;
    }
}