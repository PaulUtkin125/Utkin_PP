using Utkin_PP.Data;
using Utkin_PP.Models.Db;
using Utkin_PP.Models.Interface;

namespace Utkin_PP.Models
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
