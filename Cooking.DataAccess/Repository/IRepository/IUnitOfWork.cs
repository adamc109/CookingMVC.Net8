﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.DataAccess.Repository.IRepository
{
    public  interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IRecipieRepository Recipie { get; }
        ICompanyRepository Company { get; }
        IShoppingCartRepository ShoppingCart { get; }
        IApplicationUserRepository ApplicationUser { get; }
        IOrderHeaderRepository OrderHeader { get; }
        IOrderDetailRepository OrderDetail { get; }

        void Save();
    }
}
