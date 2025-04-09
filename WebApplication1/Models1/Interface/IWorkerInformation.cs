using WebApplication1.Controllers.Db;

namespace WebApplication1.Models1.Interface
{
    // принцип разделения интерфейсов:
    // описывает узкоспециализированный функционал

    // Интерфейс IWorkerInformation определяет контракт для управления данными
    // Это позволяет следовать принципу инверсии зависимостей и принципу разделения интерфейсов

    // принцип открытости/закрытости:
    // позволяют добавлять новые реализации, не изменяя существующий код

    internal interface IWorkerInformation
    {
        WorkInformation? ZpInformation(int id);
        Employee WorkerInf(int id);
    }
}
