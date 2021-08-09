namespace Criminal_Web_Station.Services.Implementations
{
    using Criminal_Web_Station.Data;
    using Criminal_Web_Station.Data.Entities;
    using Criminal_Web_Station.Models;
    using Criminal_Web_Station.Services.Interfaces;
    using global::AutoMapper;
    using global::AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    public class CreditCardService : ICreditCardService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CreditCardService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddMoney(string accountId, decimal amount)
        {
            var creditCard = this.context
                .CreditCards
                .Where(x => x.AccountId == accountId)
                .FirstOrDefault();

            creditCard.Balance += amount;

            this.context.SaveChanges();
        }

        public async Task CreateAsync(CreditCardFormModel creditCard)
        {
            var creditCardEntity = new CreditCard
            {
                AccountId = creditCard.AccountId,
                Number = creditCard.Number,
                Cvv = creditCard.Cvv,
                ExpiredOn = DateTime.UtcNow,
                Balance = 0
            };

            await this.context.AddAsync(creditCardEntity);
            await this.context.SaveChangesAsync();
        }

        public CreditCardFormModel GetCreditCardAsync(string accountId)
            => this.context
                .CreditCards
                .Where(x => x.AccountId == accountId)
                .ProjectTo<CreditCardFormModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefault();

        public decimal GetCreditCardBalance(string accountId)
            => this.context
            .CreditCards
            .FirstOrDefault(x => x.AccountId == accountId)
            .Balance;

        public bool HasCreditCard(string accountId)
            => this.context
                .CreditCards
                .Any(c => c.AccountId == accountId);

        public void RemoveMoney(string accountId, decimal amount)
        {
            var creditCard = this.context
                .CreditCards
                .Where(x => x.AccountId == accountId)
                .FirstOrDefault();

            creditCard.Balance -= amount;

            this.context.SaveChanges();
        }
    }
}
