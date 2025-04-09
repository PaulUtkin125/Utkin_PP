using WebApplication1.Controllers.Db;
using WebApplication1.Data;
using WebApplication1.Models1.Interface;

namespace WebApplication1.Models1
{
    // Принцип единственной ответственности:
    // этот класс отвечает только за получение информации о работнике
    internal class WorkerInformationService : IWorkerInformation
    {
        private readonly DbContact _context; // Принцип инверсии зависимостей: WorkerInformationService зависит от DbContact
        public WorkerInformationService(DbContact dbContact)
        {
            _context = dbContact;
        }
        public WorkInformation? ZpInformation(int id)
        {
            WorkInformation? workerRecord_Exist = _context.WorkInformation.OrderByDescending(x => x.Id).FirstOrDefault(x => x.EmployeeId == id);
            return workerRecord_Exist;
        }
        public Employee WorkerInf(int id)
        {
            return _context.Employees.Find(id);
        }
    }
}
