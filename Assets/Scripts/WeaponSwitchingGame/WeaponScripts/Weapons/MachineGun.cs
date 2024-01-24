using System.Collections;
using UnityEngine;

namespace WeaponSwitchingGame
{
    public class MachineGun : Weapon
    {
        [SerializeField] private Canvas _RechargeCanvas;
        [SerializeField] private int _weaponMagazineValue = 10;
        [SerializeField] private float _weaponMagazine = 0;
        [SerializeField] private int _shotsInBurst = 3;

        private void Start() => RechargeWeapon();

        public override void TryShoot()
        {
            if (_weaponMagazine <= 0)
            {
                _RechargeCanvas.gameObject.SetActive(true);
                return;
            }

            StartCoroutine(SootCorutine());
        }

        public override void RechargeWeapon()
        {
            _weaponMagazine = _weaponMagazineValue;
            _RechargeCanvas.gameObject.SetActive(false);
        }

        private IEnumerator SootCorutine()
        {
            for (int i = 0; i < _shotsInBurst; i++)
            {
                if (_weaponMagazine <= 0)
                {
                    _RechargeCanvas.gameObject.SetActive(true);
                    StopAllCoroutines();
                    yield return null;
                }

                Soot();
                _weaponMagazine--;
                yield return new WaitForSeconds(OneSecond / _fireRate);
            }
        }

        private void Soot()
        {
            InstantiateBullet();
        }
    }
}