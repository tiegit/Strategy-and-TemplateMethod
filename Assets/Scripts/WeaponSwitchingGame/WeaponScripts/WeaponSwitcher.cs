using System;
using UnityEngine;

namespace WeaponSwitchingGame
{
    public class WeaponSwitcher : MonoBehaviour
    {
        [SerializeField] private int _selectedWeapon = 0;
        public Weapon CurrentWeapon { get; private set; }

        private void Awake()
        {
            SelectWeapon(_selectedWeapon);
        }

        public void ChangeWeapon(float mouseScroll)
        {
            if (mouseScroll < 0)
            {
                if (_selectedWeapon >= transform.childCount - 1)
                    _selectedWeapon = 0;
                else
                    _selectedWeapon++;
            }

            if (mouseScroll > 0)
            {
                if (_selectedWeapon <= 0)
                    _selectedWeapon = transform.childCount - 1;
                else
                    _selectedWeapon--;
            }

            SelectWeapon(_selectedWeapon);
        }

        private void SelectWeapon(int selectedWeapon)
        {
            int i = 0;

            foreach (Transform weapon in transform)
            {
                if(i == selectedWeapon)
                    ActivateWeapon(weapon);
                else
                    DeactivateWeapon(weapon);

                i++;
            }
        }

        private void ActivateWeapon(Transform weapon)
        {
            weapon.gameObject.SetActive(true);

            CurrentWeapon = weapon.GetComponentInChildren<Weapon>();
        }

        private void DeactivateWeapon(Transform weapon)
        {
            weapon.gameObject.SetActive(false);
        }

    }
}
