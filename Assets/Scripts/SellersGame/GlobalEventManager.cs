using System;

namespace SellersGame
{
    public class GlobalEventManager
    {
        public static event Action<int> OnMoneyValueChanged;

        public static void SendMoneyValue(int value) => OnMoneyValueChanged?.Invoke(value);
    }
}