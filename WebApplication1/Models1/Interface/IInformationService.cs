using WebApplication1.Controllers.Db;

namespace WebApplication1.Models1.Interface
{
    // принцип разделения интерфейсов:
    // интерфейс имеет четко определенную обязанность для данного типа пользователя (Менеджер)

    // Интерфейс IInformationService определяет контракт для управления информацией о сотрудниках и сохранении данных
    // Это также соответствует принципу инверсии зависимостей
    interface IInformationService
    {
        List<Employee> NoHeaderWorkerList();
        void SaveData(WorkInformation value);
    }
}
