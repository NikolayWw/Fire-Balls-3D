using CodeBase.Extension;
using UnityEngine;

namespace CodeBase.Logic.Markers
{
    public class TrekMarker : MonoBehaviour, IArraySort
    {
        [field: SerializeField] public int SortNumber { get; private set; }
        [SerializeField] private Transform[] _trekPoints;

        public Vector3[] GetTrekPoints()
        {
            var points = new Vector3[_trekPoints.Length];
            for (var i = 0; i < _trekPoints.Length; i++)
            {
                points[i] = _trekPoints[i].position;
            }

            return points;
        }
    }
}