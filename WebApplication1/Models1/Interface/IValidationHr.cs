namespace WebApplication1.Models1.Interface
{
    // Интерфейс IValidationHr определяет контракт для валидации данных
    // Это позволяет следовать принципу инверсии зависимостей и принципу разделения интерфейсов

    // принцип разделения интерфейсов:
    // интерфейс имеет четко определенную обязанность для данного типа пользователя (HR)

    interface IValidationHr
    {
        bool LastName(string lName);
        bool FormOfRemuneration(int index);
    }
}
