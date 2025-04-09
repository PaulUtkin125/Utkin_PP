using WebApplication1.Controllers.Db;

namespace WebApplication1.Models1.Interface
{
    // Интерфейс IEmployeeService определяет контракт для управления сотрудниками
    // Это также соответствует принципу инверсии зависимостей

    // принцип разделения интерфейсов:
    // интерфейс имеет четко определенную обязанность
    interface IEmployeeService
    {
        void AddEmployee(Employee employee);
    }
}
