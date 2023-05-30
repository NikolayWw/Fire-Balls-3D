using CodeBase.Logic.Pool;
using System.Collections;
using UnityEngine;

namespace CodeBase.Bullet
{
    public class BulletPoolObject : MonoBehaviour, IObjectPool
    {
        private WaitForSeconds _wait;

        public void Construct(float lifeTime)
        {
            _wait = new WaitForSeconds(lifeTime);
        }

        public bool IsReady() =>
            gameObject.activeInHierarchy == false;

        public void Enable()
        {
            StopAllCoroutines();
            gameObject.SetActive(true);
            StartCoroutine(DisableThisDelay());
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        private IEnumerator DisableThisDelay()
        {
            yield return _wait;
            gameObject.SetActive(false);
        }
    }
}