using Utkin_PP.Models.Db;

namespace Utkin_PP.Models.Interface
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
