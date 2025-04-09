using WebApplication1.Controllers.Db;

namespace WebApplication1.Models1.Interface
{
    // Интерфейс ILogo определяет контракт для управления информацией о сотрудниках
    // Это также соответствует принципу инверсии зависимостей

    // принцип разделения интерфейсов:
    // интерфейс имеет четко определенную обязанность по предоставленю информации для корректного формирования стартого окна
    internal interface ILogo
    {
        List<Employee> WorkerList();
    }
}
