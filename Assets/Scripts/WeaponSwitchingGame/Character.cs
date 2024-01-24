using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;

namespace WeaponSwitchingGame
{
    [RequireComponent(typeof(Rigidbody))]

    public class Character : MonoBehaviour, IControllableCharacter
    {
        [SerializeField] private Transform _head;
        [SerializeField] private Transform _cameraPoint;
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _maxHeadAngle = 45f;
        [SerializeField] private float _minHeadAngle = -45f;
        
        private Rigidbody _rigidbody;
        private float _inputH, _inputV, _rotateY, _mscroll;
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();

            Transform camera = Camera.main.transform;
            camera.parent = _cameraPoint;
            camera.localPosition = Vector3.zero;
            camera.localRotation= Quaternion.identity;            
        }

        private void FixedUpdate()
        {
            Move();
            RotateY();
        }

        public void SetInput(float h, float v, float rotateY)
        {
            _inputH = h;
            _inputV = v;
            _rotateY += rotateY;
        }

        public void RotateX(float value)
        {
            _mscroll = Mathf.Clamp(_mscroll + value, _minHeadAngle, _maxHeadAngle);
            _head.localEulerAngles = new Vector3(-_mscroll, 0, 0);
        }

        private void Move()
        {
            Vector3 velocity = (transform.forward * _inputV + transform.right * _inputH).normalized * _speed;
            velocity.y = _rigidbody.velocity.y;
            
            _rigidbody.velocity = velocity;
        }

        private void RotateY()
        {
            _rigidbody.angularVelocity = new Vector3(0, _rotateY, 0);
            _rotateY = 0;
        }
    }
}