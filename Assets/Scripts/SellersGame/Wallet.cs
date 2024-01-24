using TMPro;

namespace SellersGame
{
    public class Wallet
    {
        private int _moneyValue = 0;

        public int GetMoneyValue()
        {            
            return _moneyValue;
        }

        public void AddMoney(int moneyValue)
        {
            if (moneyValue <= 0) return;
            _moneyValue += moneyValue;
            GlobalEventManager.SendMoneyValue(_moneyValue);
        }

        public void SpendMoney(int moneyValue)
        {
            if (_moneyValue >= moneyValue)
            {
                _moneyValue -= moneyValue;
                GlobalEventManager.SendMoneyValue(_moneyValue);
            }
        }
    }
}
