using UnityEngine;

namespace WeaponSwitchingGame
{
    [RequireComponent(typeof(IControllableCharacter))]

    public class PlayerInput : MonoBehaviour
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private const string MouseX = "Mouse X";
        private const string MouseY = "Mouse Y";
        private const string Fire1 = "Fire1";
        private const string MouseScroll = "Mouse ScrollWheel";

        [SerializeField] private float _mouseSensetivity = 8f;
        [SerializeField] private WeaponSwitcher _weaponSwitcher;

        private IControllableCharacter _playerCharacter;

        private WeaponHendler _weaponHendler;

        private void Awake()
        {
            _playerCharacter = GetComponent<IControllableCharacter>();
            _weaponHendler = new WeaponHendler(_weaponSwitcher);
        }

        private void Update()
        {
            float h = Input.GetAxisRaw(Horizontal);
            float v = Input.GetAxisRaw(Vertical);

            float mouseX = Input.GetAxis(MouseX);
            float mouseY = Input.GetAxis(MouseY);
            float mouseScroll = Input.GetAxisRaw(MouseScroll);
                        
            bool isShoot = Input.GetButtonDown(Fire1);
            bool isRechrgeWeapon = Input.GetKeyDown(KeyCode.R);

            _playerCharacter.SetInput(h, v, mouseX * _mouseSensetivity);
            _playerCharacter.RotateX(-mouseY * _mouseSensetivity);

            if (mouseScroll != 0) _weaponHendler.ChangeWeapon(mouseScroll);
            if (isShoot) _weaponHendler.TryShoot();
            if (isRechrgeWeapon) _weaponHendler.RechargeWeapon();
        }               
    }
}
