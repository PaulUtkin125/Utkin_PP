using Utkin_PP.Models.Db;

namespace Utkin_PP.Models.Interface
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
