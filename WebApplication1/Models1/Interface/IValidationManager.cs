namespace WebApplication1.Models1.Interface
{
    // Интерфейс IValidationManager определяет контракт для валидации данных
    // Это позволяет следовать принципу инверсии зависимостей и принципу разделения интерфейсов

    // принцип разделения интерфейсов:
    // интерфейс имеет четко определенную обязанность по валидации данных для данного типа пользователя (Менаджер)

    internal interface IValidationManager
    {
        bool SimpleSystem(string quentity, string price, string normaVur);
        bool Piecework_premium(string premia, string quentity, string price, string normaVur);
        bool Piecework_progressive(string porog, string cenaDoPoroga, string cenaPoslePoroga, string quentity);
        bool Indirectly_piecework(string zpOrg, string procent);
    }
}
