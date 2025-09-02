using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattern.DataAccessLayer.Abstract;
using RepositoryDesignPattern.DataAccessLayer.Concrete;
using RepositoryDesignPattern.DataAccessLayer.Repositories;
using RepositoryDesignPattern.EntityLayer.Concerte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDesignPattern.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        private readonly  Context _context;
        public EfProductDal(Context context) : base(context)
        {
            _context = context;
        }

        public List<Product> ProductListWithCategory()
        {
          return  _context.products.Include(x => x.Category).ToList();
        }
    }
}
