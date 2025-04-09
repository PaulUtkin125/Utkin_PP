using WebApplication1.Controllers.Db;
using WebApplication1.Data;
using WebApplication1.Models1.Interface;

namespace WebApplication1.Models1
{
    // В этом классе представлен принцип единственной ответственности:
    // Клас отвечает только за одну задачу: выгрузку информации из БД
    internal class InformationService : IInformationService
    {
        private readonly DbContact _context;

        // конструктор принимает зависимость DbContact, что позволяет следовать
        // принципу инверсии завсмости
        public InformationService(DbContact context)
        {
            _context = context;
        }

        public List<Employee> NoHeaderWorkerList()
        {
            return _context.Employees.Where(x => x.RoleId == 3).ToList();
        }

        public void SaveData(WorkInformation value)
        {
            _context.WorkInformation.Add(value);
            _context.SaveChanges();
        }
    }
}
