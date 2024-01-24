using UnityEngine;

namespace WeaponSwitchingGame
{
    public class Pistol : Weapon
    {
        [SerializeField] private Canvas _RechargeCanvas;
        [SerializeField] private int _weaponMagazineValue = 6;
        private float _weaponMagazine = 0;
        private float _nextTimeToFire = 0;

        private void Start() => RechargeWeapon();

        public override void TryShoot()
        {
            if (Time.time >= _nextTimeToFire)
            {
                if (_weaponMagazine <= 0)
                {
                    _RechargeCanvas.gameObject.SetActive(true);
                    return;
                }

                InstantiateBullet();

                _nextTimeToFire = Time.time + OneSecond/ _fireRate;

                _weaponMagazine--;
            }
        }

        public override void RechargeWeapon()
        {
            _weaponMagazine = _weaponMagazineValue;
            _RechargeCanvas.gameObject.SetActive(false);
        }
    }
}
