using UnityEngine;

namespace SellersGame
{
    [RequireComponent(typeof(PlayerCharacter))]

    public class PlayerInput : MonoBehaviour
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private const string MouseX = "Mouse X";

        [SerializeField] private float _mouseSensetivity = 8f;

        private PlayerCharacter _playerCharacter;

        private void Awake()
        {
            _playerCharacter = GetComponent<PlayerCharacter>();
        }

        private void Update()
        {
            float h = Input.GetAxisRaw(Horizontal);
            float v = Input.GetAxisRaw(Vertical);

            float mouseX = Input.GetAxis(MouseX);
                        
            bool clickedE = Input.GetKeyDown(KeyCode.E);

            _playerCharacter.SetInput(h, v, mouseX * _mouseSensetivity);

            if (clickedE) _playerCharacter.Seller.SetPressE();
        }
    }
}
