using WebApplication1.Models1.Interface;

namespace WebApplication1.Models1
{
    // принцип: единственной ответственности
    // класс отвечает исключительно за валедацию данных

    internal class ValidationManagerService : IValidationManager
    {
        private readonly IMessageService _messageService; // Использование интерфейса для абстракции (Принцип инверсии зависимостей)
        public ValidationManagerService(IMessageService messageService)
        {
            _messageService = messageService;
        }
        public bool SimpleSystem(string quentity, string price, string normaVur)
        {
            if (!double.TryParse(quentity, out double _quentity))
            {
                _messageService.Message("В поле 'Произведено продукции' введено некорректное значение", "Error");
                return false;
            }
            if (!double.TryParse(price, out double _price))
            {
                _messageService.Message("В поле 'Ставка' введено некорректное значение", "Error");
                return false;
            }
            if (!int.TryParse(normaVur, out int _normaVur))
            {
                _messageService.Message("В поле 'Ставка' введено некорректное значение", "Error");
                return false;
            }

            if (_quentity < 0.5)
            {
                _messageService.Message("Значение 'Произведено продукции' должно быть больше 0.5!", "Error");
                return false;
            }

            if (_price < 1)
            {
                _messageService.Message("Значение 'Ставка' должно быть больше 0!", "Error");
                return false;
            }

            if (_normaVur < 0.5)
            {
                _messageService.Message("Значение 'Норма выработки' должно быть больше 0.5!", "Error");
                return false;
            }

            return true;
        }

        public bool Piecework_premium(string premia, string quentity, string price, string normaVur)
        {
            if (!SimpleSystem(quentity, price, normaVur)) return false;
            if (!int.TryParse(premia, out int _premia))
            {
                _messageService.Message("В поле 'Премия' введено некорректное значение", "Error");
                return false;
            }
            if (_premia < 1)
            {
                _messageService.Message("Значение 'Премия' должно быть больше 0!", "Error");
                return false;
            }

            return true;
        }

        public bool Piecework_progressive(string porog, string cenaDoPoroga, string cenaPoslePoroga, string quentity)
        {
            if (!double.TryParse(porog, out double _porog))
            {
                _messageService.Message("В поле 'Порог' введено некорректное значение", "Error");
                return false;
            }

            if (!double.TryParse(cenaDoPoroga, out double _cenaDoPoroga))
            {
                _messageService.Message("В поле 'Сдельная расценка до парогового значения' введено некорректное значение", "Error");
                return false;
            }

            if (!double.TryParse(cenaPoslePoroga, out double _cenaPoslePoroga))
            {
                _messageService.Message("В поле 'Сдельная расценка после парогового значения' введено некорректное значение", "Error");
                return false;
            }

            if (!double.TryParse(quentity, out double _quentity))
            {
                _messageService.Message("В поле 'Произведено продукции' введено некорректное значение", "Error");
                return false;
            }

            if (_porog < 0.5)
            {
                _messageService.Message("Значение 'Порог' должно быть больше 0.5!", "Error");
                return false;
            }
            if (_cenaDoPoroga < 1)
            {
                _messageService.Message("Значение 'Сдельная расценка до парогового значения' должно быть больше 0!", "Error");
                return false;
            }
            if (_cenaPoslePoroga < 1)
            {
                _messageService.Message("Значение 'Сдельная расценка после парогового значения' должно быть больше 0!", "Error");
                return false;
            }
            if (_cenaDoPoroga >= _cenaPoslePoroga)
            {
                _messageService.Message($"Значение 'Сдельная расценка после парогового значения' должно быть\nбольше значения 'Сдельная расценка до парогового значения'!", "Error");
                return false;
            }

            if (_quentity < 1)
            {
                _messageService.Message("Значение 'Произведено продукции' должно быть больше 1", "Error");
                return false;
            }

            return true;
        }
        public bool Indirectly_piecework(string zpOrg, string procent)
        {
            if (!double.TryParse(zpOrg, out double _zpOrg))
            {
                _messageService.Message($"В поле 'заработок работников основного производства'\nвведено некорректное значение", "Error");
                return false;
            }
            if (!double.TryParse(procent, out double _procent))
            {
                _messageService.Message("В поле 'процент' введено некорректное значение", "Erro");
                return false;
            }

            if (_zpOrg < 1)
            {
                _messageService.Message("Значение 'заработок работников основного производства' должно быть больше 0!", "Error");
                return false;
            }
            if (_procent < 1)
            {
                _messageService.Message("Значение 'процент' должно быть больше 0!", "Error");
                return false;
            }

            return true;
        }
    }
}
