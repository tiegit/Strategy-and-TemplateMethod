using UnityEngine;

namespace WeaponSwitchingGame
{
    public class Bazooka : Weapon
    {
        private float _nextTimeToFire = 0;

        public override void TryShoot()
        {
            if (Time.time >= _nextTimeToFire)
            {
                InstantiateBullet();
                _nextTimeToFire = Time.time + OneSecond / _fireRate;
            }
        }

        public override void RechargeWeapon()
        {
        }
    }
}
