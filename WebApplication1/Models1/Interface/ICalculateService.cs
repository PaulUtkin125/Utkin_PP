namespace WebApplication1.Models1.Interface
{
    // принцип разделения интерфейсов:
    // интерфейс имеет четко определенную обязанность

    // Интерфей определяет контракт для расчета з/п
    // Это также соответствует принципу инверсии зависимостей
    internal interface ICalculateService
    {
        double CalculateSimpleSystem(double quentity, double price, int normaVur);
        double CalculatePiecework_premium(int premia, double quentity, double price, int normaVur);
        double CalculatePiecework_progressive(double porog, double cenaDoPoroga, double cenaPoslePoroga, double quentity);
        double CalculateIndirectly_piecework(double zpOrg, double procent);
    }
}
