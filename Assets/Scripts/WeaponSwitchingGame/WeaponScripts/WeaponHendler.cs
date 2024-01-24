using UnityEngine;

namespace WeaponSwitchingGame
{
    public class WeaponHendler
    {
        private WeaponSwitcher _weaponSwitcher;
        private Weapon _weapon;

        public WeaponHendler(WeaponSwitcher weaponSwitcher)
        {
            _weaponSwitcher = weaponSwitcher;

            SetWeapon();
        }

        public void ChangeWeapon(float mouseScroll)
        {
            _weaponSwitcher.ChangeWeapon(mouseScroll);

            SetWeapon();
        }

        public void TryShoot() => _weapon.TryShoot();

        public void RechargeWeapon() => _weapon.RechargeWeapon();

        private void SetWeapon() => _weapon = _weaponSwitcher.CurrentWeapon;
    }
}