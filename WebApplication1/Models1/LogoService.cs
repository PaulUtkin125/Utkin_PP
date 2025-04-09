using WebApplication1.Controllers.Db;
using WebApplication1.Data;
using WebApplication1.Models1.Interface;

namespace WebApplication1.Models1
{
    // В этом классе представлен принцип единственной ответственности:
    // Клас отвечает только за одну задачу: выгрузку информации из БД
    internal class LogoService : ILogo
    {
        private readonly DbContact _context;
        // конструктор принимает зависимость DbContact, что позволяет следовать
        // принципу инверсии завсмости

        public LogoService(DbContact dbContact)
        {
            _context = dbContact;
        }
        public List<Employee> WorkerList()
        {
            return _context.Employees.ToList();
        }
    }
}
