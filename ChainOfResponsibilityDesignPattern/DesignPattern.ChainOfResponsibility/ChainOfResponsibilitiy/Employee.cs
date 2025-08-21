using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibilitiy
{
    public abstract class Employee
    {
        protected Employee NextApprover;
        public void SetNextApprover(Employee superVisor)
        {
            this.NextApprover = superVisor;
        }
        public abstract void ProccesRequest(CustomerProcessViewModel req);
    }
}
