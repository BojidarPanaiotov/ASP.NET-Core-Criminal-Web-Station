namespace Criminal_Web_Station.Services.Implementations
{
    using Criminal_Web_Station.Areas.Admin.Models;
    using Criminal_Web_Station.Data;
    using Criminal_Web_Station.Data.Entities;
    using Criminal_Web_Station.Services.Interfaces;
    using global::AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class AdminService : IAdminService
    {
        private readonly UserManager<Account> userManager;
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;

        public AdminService(
            UserManager<Account> userManager,
            IMapper mapper,
            ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.context = context;
        }

        public IEnumerable<UserServiceModel> GetAllUsers()
        {
            return this.userManager
                      .Users
                      .Include(u => u.CreditCard)
                      .Include(u => u.Items)
                      .Select(x => new UserServiceModel
                      {
                          AccountId = x.Id,
                          Username = x.UserName,
                          CreadtedOn = x.CreatedOn,
                          CreditCard = this.mapper.Map<CreditCardServiceModel>(x.CreditCard),
                          ItemsCount = x.Items.Count(),
                          PurchasesCount = x.Purchases.Count()
                      })
                      .OrderByDescending(x => x.ItemsCount)
                      .ToList();
        }

        public string GetUsernameById(string accountId)
            => this.context
                .Accounts
                .FirstOrDefault(x => x.Id == accountId)
                .UserName;
    }
}
