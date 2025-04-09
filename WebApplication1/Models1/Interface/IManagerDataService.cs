using WebApplication1.Controllers.Db;

namespace WebApplication1.Models1.Interface
{
    // принцип разделения интерфейсов:
    // интерфейс имеет четко определенную обязанность для данного типа пользователя (HR)

    // Интерфейс IManagerDataService определяет контракт для управления информацией о формах оплаты труда
    // Это также соответствует принципу инверсии зависимостей
    internal interface IManagerDataService
    {
        List<FormOfRemuneration> HRDepartment_Support();
    }
}
