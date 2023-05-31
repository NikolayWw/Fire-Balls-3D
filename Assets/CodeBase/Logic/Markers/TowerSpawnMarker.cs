using CodeBase.StaticData.Tower;
using UnityEngine;

namespace CodeBase.Logic.Markers
{
    public class TowerSpawnMarker : MonoBehaviour
    {
        [field: SerializeField] public TowerId TowerId { get; private set; }

        private void OnValidate()
        {
            if (PrefabChecker.IsPrefab(gameObject) == false)
                gameObject.name = $"TowerMarker_{TowerId}";
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 1f);
        }
    }
}