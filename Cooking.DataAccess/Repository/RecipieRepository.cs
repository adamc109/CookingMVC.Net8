using Cooking.DataAccess.Data1;
using Cooking.DataAccess.Repository.IRepository;
using Cooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.DataAccess.Repository
{
    public class RecipieRepository : Repository<Recipie>, IRecipieRepository
    {
        private ApplicationDbContext _db;
        public RecipieRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }


        public void Update(Recipie obj)
        {
            _db.Recipies.Update(obj);
        }
    }
}
