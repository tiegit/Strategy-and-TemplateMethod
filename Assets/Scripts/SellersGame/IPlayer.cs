namespace SellersGame
{
    public interface IPlayer
    {
        public int GetMoneyValue();

        public void AddMoney(int moneyValue);

        public void SpendMoney(int moneyValue);

        public void SetSeller(ISeller seller);
    }
}