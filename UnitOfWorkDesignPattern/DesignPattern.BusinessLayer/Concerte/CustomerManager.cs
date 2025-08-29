using DesignPattern.BusinessLayer.Abstract;
using DesignPattern.DataAccessLayer.Abstract;
using DesignPattern.DataAccessLayer.UnitOfWork;
using DesingPattern.EntityLayer.Concerte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.BusinessLayer.Concerte
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly IUnitOfWorkDal _unitOfWork;

        public CustomerManager(ICustomerDal customerDal, IUnitOfWorkDal unitOfWork)
        {
            _customerDal = customerDal;
            _unitOfWork = unitOfWork;
        }

        public void TDelete(Customer t)
        {
            _customerDal.Delete(t);
            _unitOfWork.Save();
        }

        public Customer TGetByID(int id)
        {
            return _customerDal.GetByID(id);
        }

        public List<Customer> TGetList()
        {
            return _customerDal.GetList();
        }

        public void TInsert(Customer t)
        {
            _customerDal.Insert(t);
            _unitOfWork.Save();
        }

        public void TMultiUpdate(List<Customer> t)
        {
            _customerDal.MultiUpdate(t);
            _unitOfWork.Save();
        }

        public void TUpdate(Customer t)
        {
            _customerDal.Update(t);
            _unitOfWork.Save();
        }
    }
}
