using TMPro;
using UnityEngine;

namespace SellersGame
{
    public class PlayerCharacter : MonoBehaviour, IPlayer
    {
        [SerializeField] private float _speed = 3f;
        [SerializeField] private float _rotationSensitivity = 5f;

        [SerializeField] private TextMeshProUGUI _moneyText;
        [SerializeField] private Wallet _wallet;
        [SerializeField] private int _startMoneyValue = 0;

        private float _inputH, _inputV, _rotateY;

        public ISeller Seller { get; private set; }

        private void Start()
        {
            _wallet = new Wallet();
            GlobalEventManager.OnMoneyValueChanged += ChangeMoneyView;
            AddMoney(_startMoneyValue);
        }
        
        private void FixedUpdate() => Move();
        
        public void SetInput(float h, float v, float rotateY)
        {
            _inputH = h;
            _inputV = v;
            _rotateY += rotateY;
        }

        public int GetMoneyValue() => _wallet.GetMoneyValue();

        public void AddMoney(int moneyValue) => _wallet.AddMoney(moneyValue);

        public void SpendMoney(int moneyValue) => _wallet.SpendMoney(moneyValue);

        public void SetSeller(ISeller seller) => Seller = seller;

        private void Move()
        {
            Vector3 offset = new Vector3(_inputH, 0, _inputV) * Time.deltaTime * _speed;
            transform.Translate(offset);
            transform.Rotate(0, _rotateY * _rotationSensitivity, 0);
            _rotateY = 0;
        }

        private void ChangeMoneyView(int value) => _moneyText.text = "$ " + value.ToString();
        
        private void OnDisable()
        {
            GlobalEventManager.OnMoneyValueChanged -= ChangeMoneyView;
        }
    }
}
