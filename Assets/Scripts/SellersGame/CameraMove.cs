using UnityEngine;

namespace SellersGame
{
    public class CameraMove : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private float _lerpModifier = 5f;

        private void LateUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, _targetTransform.position, Time.deltaTime * _lerpModifier);
            transform.rotation = Quaternion.Lerp(transform.rotation, _targetTransform.rotation, Time.deltaTime * _lerpModifier);
        }
    }
}
