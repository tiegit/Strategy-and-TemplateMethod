using UnityEngine;

namespace SellersGame
{
    public class WeaponsSeller : Seller
    {
        [SerializeField] private int _weaponPrice = 200;

        public bool IsEnoughMoney { get; private set; }

        private void Update()
        {
            if (InDilog)
            {
                if (Input.GetKeyDown(KeyCode.Y) && IsEnoughMoney)
                {
                    Debug.Log("Вот ящик оружия за " + _weaponPrice + " денег");
                    Debug.Log("Забрал оружие");

                    CheckMoneyValue();

                    SpendPlayerMoney(_weaponPrice);
                }
                
                if(!IsEnoughMoney)
                {
                    Debug.Log("У тебя не достаточно денег. Ящик оружия стоит " + _weaponPrice + " денег. Приходи в другой раз");
                    ExitDialog();
                }
            }
        }

        public override void StartDialog()
        {
            if (InDilog && IsPressedE)
            {
                CheckMoneyValue();

                Debug.Log("Я честный продавец оружия, я продаю самые красивые пистолеты, автоматы и базуки, по цене " + _weaponPrice +
                    " денег за ящик. Хочешь взять ящик блестящего оружия? Нажать Y для покупки");

            }
        }

        public override void StopDialog()
        {
            if (!InDilog && !IsPressedE)
            {
                Debug.Log("Приходи еще за моим оружием");
            }
        }

        public override void CheckMoneyValue()
        {
            GetPlayerMoney();

            if (PlayerMoneyValue < _weaponPrice)
            {
                IsEnoughMoney = false;
            }
            else IsEnoughMoney = true;
        }
    }
}

