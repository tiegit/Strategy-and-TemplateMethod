using System;
using UnityEngine;

namespace WeaponSwitchingGame
{
    public abstract class Weapon : MonoBehaviour
    {
        public const int OneSecond = 1;

        public Bullet _bulletPrefab;
        public Transform _bulletPoint;
        public float _bulletSpeed = 5f;
        public float _fireRate = 15f;

        public abstract void TryShoot();

        public abstract void RechargeWeapon();

        public void InstantiateBullet()
        {
            Vector3 position = _bulletPoint.position;
            Quaternion rotation = _bulletPoint.rotation;
            Vector3 velocity = _bulletPoint.forward * _bulletSpeed;

            Instantiate(_bulletPrefab, position, rotation).Init(velocity);
        }
    }
}
