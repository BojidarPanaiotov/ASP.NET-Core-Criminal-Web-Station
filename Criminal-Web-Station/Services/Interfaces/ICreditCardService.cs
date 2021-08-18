namespace Criminal_Web_Station.Services.Interfaces
{
    using Criminal_Web_Station.Models;

    public interface ICreditCardService
    {
        void Create(CreditCardFormModel creditCard);
        bool HasCreditCard(string accountId);
        CreditCardFormModel GetCreditCardAsync(string accountId);
        decimal GetCreditCardBalance(string accountId);
        void AddMoney(string accountId, decimal amount);
        void RemoveMoney(string accountId, decimal amount);
    }
}
