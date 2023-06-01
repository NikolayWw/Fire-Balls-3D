using UnityEngine;

namespace CodeBase.StaticData.Player
{
    [CreateAssetMenu(menuName = "Static Data/Player Static Data", order = 0)]
    public class PlayerStaticData : ScriptableObject
    {
        [field: SerializeField] public float ShootForce { get; private set; } = 20f;
        [field: SerializeField] public float MoveSpeed { get; private set; } = 10f;
    }
}