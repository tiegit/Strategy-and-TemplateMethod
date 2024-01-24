using UnityEngine;

namespace SellersGame
{
    public class VegetablesSeller : Seller
    {
        [SerializeField] private int _vegetablesPrice = 30;

        public bool IsEnoughMoney { get; private set; }

        private void Update()
        {
            if (InDilog)
            {
                if (Input.GetKeyDown(KeyCode.Y) && IsEnoughMoney)
                {
                    Debug.Log("Фрукты и офощи за " + _vegetablesPrice + " денег");
                    Debug.Log("Забрал пакет с продуктами");

                    CheckMoneyValue();

                    SpendPlayerMoney(_vegetablesPrice);
                }
                
                if(!IsEnoughMoney)
                {
                    Debug.Log("УУУ расходились тут, работать не мишай. Мои пирадукты. Деник нету - нету пиродукты");
                    ExitDialog();
                }
            }
        }

        public override void StartDialog()
        {
            if (InDilog && IsPressedE)
            {
                CheckMoneyValue();

                Debug.Log("Я пиродавец в овощном палатки, я пиродаю офощи и фирукты по цене " + _vegetablesPrice +
                    " деник. Пакупайнама? Нажать Y для покупки");

            }
        }

        public override void StopDialog()
        {
            if (!InDilog && !IsPressedE)
            {
                Debug.Log("Пака");
            }
        }

        public override void CheckMoneyValue()
        {
            GetPlayerMoney();

            if (PlayerMoneyValue < _vegetablesPrice)
            {
                IsEnoughMoney = false;
            }
            else IsEnoughMoney = true;
        }
    }
}

