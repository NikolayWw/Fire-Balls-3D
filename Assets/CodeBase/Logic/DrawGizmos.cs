using UnityEngine;

namespace CodeBase.Logic
{
    public class DrawGizmos : MonoBehaviour
    {
#if UNITY_EDITOR

        [SerializeField] private Color _color = Color.red;
        [SerializeField] private Vector3 _size = Vector3.one;

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(_color.r, _color.g, _color.b);
            Gizmos.DrawCube(transform.position, _size);
        }

#endif
    }
}