using UnityEngine;

namespace SellersGame
{
    public class MoneySeller : Seller
    {
        [SerializeField] private int _moneyValue = 100;

        private void Update()
        {
            if (InDilog)
            {
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    Debug.Log("Вот " + _moneyValue + "денег за каких-то 100500 %/год");
                    Debug.Log("Забрал деньги");

                    AddPlayerMoney(_moneyValue);
                }
            }
        }

        public override void StartDialog()
        {
            if (InDilog && IsPressedE)
            {
                CheckMoneyValue();

                Debug.Log("Я банкир, я ничего не продаю, я раздаю деньги совершенно бесплатно, за " +
                    "маленький процент. Хочешь взять денег? Нажать Y для получения денег");
            }
        }

        public override void StopDialog()
        {
            if (!InDilog && !IsPressedE)
            {
                Debug.Log("Приходи еще за деньгами");
            }
        }

        public override void CheckMoneyValue()
        {
            GetPlayerMoney();

            if (PlayerMoneyValue < _moneyValue)
            {
                Debug.Log("По глазам вижу вам деньги нужны");
            }
        }
    }
}

