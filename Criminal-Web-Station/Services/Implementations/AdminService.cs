namespace Criminal_Web_Station.Services.Implementations
{
    using Criminal_Web_Station.Areas.Admin.Models;
    using Criminal_Web_Station.Data.Entities;
    using Criminal_Web_Station.Services.Interfaces;
    using global::AutoMapper;
    using global::AutoMapper.QueryableExtensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class AdminService : IAdminService
    {
        private readonly UserManager<Account> userManager;
        private readonly IMapper mapper;

        public AdminService(
            UserManager<Account> userManager,
            IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public IEnumerable<UserServiceModel> GetAllUsers()
        {
            return this.userManager
                      .Users
                      .Include(u => u.CreditCard)
                      .Include(u => u.Items)
                      .Select(x => new UserServiceModel
                      {
                          Username = x.UserName,
                          CreadtedOn = x.CreatedOn,
                          CreditCard = this.mapper.Map<CreditCardServiceModel>(x.CreditCard),
                          Items = x.Items.Select(i => new ItemServiceModel
                          {
                              Name = i.Name,
                              CreatedOn = i.CreatedOn,
                              CategoryId = i.CategoryId,
                              LastUpdate = i.LastUpdate,
                              MainImgUrl = i.MainImgUrl,
                              Price = i.Price,
                              Weight = i.Weight
                          }),
                          Purchases = x.Purchases.Select(p => new PurchaseAdminModel
                          {
                              Cost = p.Cost,
                              Name = p.Name,
                              PurchaseDate = p.PurchaseDate
                          })
                      })
                      .ToList();
        }
    }
}
