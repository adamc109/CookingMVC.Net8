﻿using Cooking.DataAccess.Data1;
using Cooking.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork

    {
        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IRecipieRepository Recipie { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Recipie = new RecipieRepository(_db);
        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}