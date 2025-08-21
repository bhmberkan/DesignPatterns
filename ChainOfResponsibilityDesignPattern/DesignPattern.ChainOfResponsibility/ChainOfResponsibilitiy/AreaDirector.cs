using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibilitiy
{
    public class AreaDirector : Employee
    {
        public override void ProccesRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            if (req.Amount <= 400000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Bölge Direktörü - İsmail Kurnaz";
                customerProcess.Description = "Para Çekme işlemi Onaylandı, Müşteriye Talep Ettiği Tutar Ödendi.";
                context.customerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else 
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Bölge Direktörü - İsmail Kurnaz";
                customerProcess.Description = "Para Çekme Tutarı Bölge Direktörünün Günlük Ödeyebileceği Limiti Aştığı İçin İşlem Gerçekleştirilemedi." +
                    " Müşterinin Günlük Maksimum Çekebileceği Tutar 400.000₺ Olup Daha  fazlası için birden fazla gün şubeye gelmesi gerekli...";
                context.customerProcesses.Add(customerProcess);
                context.SaveChanges();
               
            }
        }
    }
}
