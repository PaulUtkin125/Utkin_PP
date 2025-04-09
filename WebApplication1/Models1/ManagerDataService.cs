using WebApplication1.Controllers.Db;
using WebApplication1.Data;
using WebApplication1.Models1.Interface;

namespace WebApplication1.Models1
{
    // В этом классе представлен принцип единственной ответственности:
    // Клас отвечает только за одну задачу: выгрузку информации из БД
    internal class ManagerDataService : IManagerDataService
    {
        private readonly DbContact _context;
        // конструктор принимает зависимость DbContact, что позволяет следовать
        // принципу инверсии завсмости

        public ManagerDataService(DbContact dbContact)
        {
            _context = dbContact;
        }

        public List<FormOfRemuneration> HRDepartment_Support()
        {
            return _context.FormOfRemuneration.ToList();
        }
    }
}
