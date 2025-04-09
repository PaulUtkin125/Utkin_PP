using System.Text.RegularExpressions;
using WebApplication1.Models1.Interface;

namespace WebApplication1.Models1
{
    // В этом классе представлен принцип единственной ответственности:
    // Клас отвечает только за одну задачу: проверка корректности введенных данных

    // класс строится на базе интерфейса IValidationHr, в следствии чего соблюдается
    // принцип открытости/закрытости: так как мы можем реализовать больше функций, чем указано в интерфейсе,
    // но меньше того количества не можем
    internal class ValidationOfdata : IValidationHr, IValidationLogin
    {
        private readonly MessageService _messageService;

        // Клас зависит от обстракции IEmployeeService, а обстракция не зависит от деталей
        // конструктор принимает зависимость MessageService, что позволяет следовать
        // принципу инверсии завсмости
        public ValidationOfdata(MessageService messageService)
        {
            _messageService = messageService;
        }
        public bool LastName(string lName)
        {
            string lastName = lName.Trim();
            if (string.IsNullOrWhiteSpace(lastName))
            {
                _messageService.Message("Фамилия не указана!", "Error");
                return false;
            }

            // Используется регулярное выражение для проверки фамилии, что соответствует принципу открытости/закрытости
            // Код открыт для расширения (например, добавления новых правил валидации) и закрыт для модификации.
            if (!Regex.IsMatch(lastName, @"^[А-Яа-яЁё ]+$"))
            {
                _messageService.Message("Разрешается использование только кирилицы!", "Error");
                return false;
            }

            return true;
        }

        public bool FormOfRemuneration(int index)
        {
            if (index == -1)
            {
                _messageService.Message("Виберите форму оплаты труда!", "Error");
                return false;
            }
            return true;
        }

        public bool Login(int index)
        {
            if (index == -1)
            {
                _messageService.Message("Тип пользователя не выбран", "Error");
                return false;
            }
            return true;
        }
    }
}
