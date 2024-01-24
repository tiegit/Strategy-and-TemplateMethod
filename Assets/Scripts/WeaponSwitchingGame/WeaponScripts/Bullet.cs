using System.Collections;
using UnityEngine;

namespace WeaponSwitchingGame
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _lifeTime = 5f;
        [SerializeField] private Rigidbody _rigidbody;        

        public void Init(Vector3 velocity)
        {
            _rigidbody.velocity = velocity;
            StartCoroutine(DestroyCorutine());
        }

        private IEnumerator DestroyCorutine()
        {
            yield return new WaitForSecondsRealtime(_lifeTime);
            Destroy();
        }

        private void Destroy()
        {
            Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Destroy();
        }
    }
}