using Utkin_PP.Data;
using Utkin_PP.Models.Db;
using Utkin_PP.Models.Interface;

namespace Utkin_PP.Models
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
