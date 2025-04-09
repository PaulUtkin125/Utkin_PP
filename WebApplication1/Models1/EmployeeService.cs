using WebApplication1.Controllers.Db;
using WebApplication1.Data;
using WebApplication1.Models1.Interface;


namespace WebApplication1.Models1
{
    // В этом классе представлен принцип единственной ответственности
    // Клас отвечает только за одну задачу: управление сотрудниками


    // класс строится на базе интерфейса IEmployeeService, в следствии чего соблюдается
    // принцип открытости/закрытости: так как мы можем реализовать больше функций, чем указано в интерфейсе,
    // но меньше того количества не можем
    internal class EmployeeService : IEmployeeService
    {
        private readonly MessageService _messageService;
        private readonly DbContact _context;

        // Клас зависит от обстракции IEmployeeService, а обстракция не зависит от деталей
        // конструктор принимает зависимости DbContact и MessageService, что позволяет следовать
        // принципу инверсии завсмости
        public EmployeeService(DbContact context, MessageService messageService)
        {
            _context = context;
            _messageService = messageService;
        }
        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();

            _messageService.Message("Запись добавлена", "Message");
        }
    }
}
