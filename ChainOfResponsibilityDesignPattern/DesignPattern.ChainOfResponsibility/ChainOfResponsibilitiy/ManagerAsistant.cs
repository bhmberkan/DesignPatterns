using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibilitiy
{
    public class ManagerAsistant : Employee
    {
        public override void ProccesRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            if (req.Amount<=150000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Şube Müdür Yardımcısı - Melike Öztürk";
                customerProcess.Description = "Para Çekme işlemi Onaylandı, Müşteriye Talep Ettiği Tutar Ödendi.";
                context.customerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Şube Müdür Yardımcısı - Melike Öztürk";
                customerProcess.Description = "Para Çekme Tutarı Şube Müdür Yardımcısının  Günlük Ödeyebileceği Limiti Aştığı İçin İşlem Şube Müdürüne Gönderildi.";
                context.customerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProccesRequest(req);
            }
        }
    }
}
