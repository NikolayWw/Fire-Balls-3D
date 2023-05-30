using System;
using UnityEngine;

namespace CodeBase.Bullet
{
    public class BulletMove : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _mainTransform;

       

        public void SetPositionAndDirection(Vector3 position, Vector3 direction)
        {
            _mainTransform.position = position;
            _rigidbody.velocity = direction;
        }

    }
}