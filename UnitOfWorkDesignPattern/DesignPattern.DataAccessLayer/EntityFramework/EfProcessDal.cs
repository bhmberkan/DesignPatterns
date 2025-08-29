using DesignPattern.DataAccessLayer.Abstract;
using DesignPattern.DataAccessLayer.Concrete;
using DesignPattern.DataAccessLayer.Repositories;
using DesingPattern.EntityLayer.Concerte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.DataAccessLayer.EntityFramework
{
    public class EfProcessDal :GenericRepository<Process> , IProcessDal
    {
        public EfProcessDal(Context context) : base(context) 
        {

        }
    }
}
