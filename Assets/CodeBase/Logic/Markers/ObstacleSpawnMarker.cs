using CodeBase.StaticData.Obstacle;
using UnityEngine;

namespace CodeBase.Logic.Markers
{
    public class ObstacleSpawnMarker : MonoBehaviour
    {
        [field: SerializeField] public ObstacleId ObstacleId { get; private set; }

        private void OnValidate()
        {
            if (PrefabChecker.IsPrefab(gameObject) == false)
                gameObject.name = $"ObstacleMarker_{ObstacleId}";
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 1f);
        }
    }
}