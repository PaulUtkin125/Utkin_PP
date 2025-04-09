using System.Windows;
using Utkin_PP.Models.Interface;

namespace Utkin_PP.Models
{
    // В этом классе представлен принцип единственной ответственности:
    // Клас отвечает только за одну задачу: отправку сообщений пользователю

    
    class MessageService : IMessageService
    {
        public void Message(string message, string title)
        {
            MessageBox.Show(message, title);
        }
    }
}
