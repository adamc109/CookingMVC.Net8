﻿using Cooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.DataAccess.Repository.IRepository
{
    public interface IRecipieRepository : IRepository<Recipie>
    {
        void Update(Recipie obj);
       
    }
}
