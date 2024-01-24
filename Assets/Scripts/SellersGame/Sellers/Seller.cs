using TMPro;
using UnityEngine;

namespace SellersGame
{
    public abstract class Seller : MonoBehaviour, ISeller
    {
        [SerializeField] private Canvas _gameCanvas;

        public bool InTrigger { get; private set; }
        public bool IsPressedE { get; private set; }
        public bool IsPressedY { get; private set; }
        public bool InDilog { get; private set; }
        public int PlayerMoneyValue { get; private set; }
        public IPlayer Player { get; private set; }

        public void SetPressE()
        {
            if (InTrigger == false) return;

            IsPressedE = !IsPressedE;

            if (IsPressedE) EnterDialog();
            else ExitDialog();
        }

        public void EnterDialog()
        {
            InDilog = true;
            StartDialog();
        }

        public void ExitDialog()
        {
            InDilog = false;
            StopDialog();
        }
        
        public void GetPlayerMoney() => PlayerMoneyValue = Player.GetMoneyValue();        

        public abstract void StartDialog();

        public abstract void StopDialog();

        public abstract void CheckMoneyValue();

        public virtual void AddPlayerMoney(int value) => Player.AddMoney(value);

        public virtual void SpendPlayerMoney(int value) => Player.SpendMoney(value);

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IPlayer player))
            {
                InTrigger = true;

                Player = player;
                Player.SetSeller(this);

                TextMeshProUGUI text = _gameCanvas.GetComponentInChildren<TextMeshProUGUI>();

                if (text != null)
                {
                    text.text = $"Нажми Е для начала диалога c " + this.name + " в консоли. Для завершения диалога нажать Е ли отойти от продавца";
                }

                _gameCanvas.gameObject.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IPlayer player))
            {
                InTrigger = false;

                if (IsPressedE)
                {
                    IsPressedE = false;
                    ExitDialog();
                }

                _gameCanvas.gameObject.SetActive(false);
            }
        }

    }
}