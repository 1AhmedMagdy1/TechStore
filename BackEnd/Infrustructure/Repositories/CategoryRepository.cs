using Core.Interfaces;
using Core.Models;
using Infrustructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.Repositories
{
    public class CategoryRepository : GenericRepository<Categoty>, ICategoryRepository
    {
        public CategoryRepository(TechStoreContext context) : base(context)
        {
        }


    }
}
