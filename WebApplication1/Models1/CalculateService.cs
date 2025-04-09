using WebApplication1.Models1.Interface;

namespace WebApplication1.Models1
{
    // принцип единственной ответственности:
    // класс отвечает исключительно за расчет з/п

    internal class CalculateService : ICalculateService
    {
        public double CalculateSimpleSystem(double quentity, double price, int normaVur)
        {
            double sdelRasc = price / normaVur;
            return sdelRasc * quentity;
        }

        public double CalculatePiecework_premium(int premia, double quentity, double price, int normaVur)
        {
            return CalculateSimpleSystem(quentity, price, normaVur) + premia;
        }
        public double CalculatePiecework_progressive(double porog, double cenaDoPoroga, double cenaPoslePoroga, double quentity)
        {
            if (porog > quentity)
            {
                return quentity * cenaDoPoroga;
            }
            else
            {
                double quentityPosle = quentity - porog;
                return porog * cenaDoPoroga + quentityPosle * cenaPoslePoroga;
            }
        }
        public double CalculateIndirectly_piecework(double zpOrg, double procent)
        {
            return zpOrg * (procent / 100);
        }
    }
}