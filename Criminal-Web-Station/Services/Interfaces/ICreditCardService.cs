﻿namespace Criminal_Web_Station.Services.Interfaces
{
    using Criminal_Web_Station.Models;
    using System.Threading.Tasks;

    public interface ICreditCardService
    {
        Task CreateAsync(CreditCardFormModel creditCard);
        bool HasCreditCard(string accountId);
        CreditCardFormModel GetCreditCardAsync(string accountId);
        decimal GetCreditCardBalance(string accountId);
        void AddMoney(string accountId,decimal amount);
        void RemoveMoney(string accountId,decimal amount);
    }
}
