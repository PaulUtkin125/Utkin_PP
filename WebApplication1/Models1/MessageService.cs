using System.Windows;
using WebApplication1.Models1.Interface;

namespace WebApplication1.Models1
{
    // В этом классе представлен принцип единственной ответственности:
    // Клас отвечает только за одну задачу: отправку сообщений пользователю


    class MessageService : IMessageService
    {
        public void Message(string message, string title)
        {
            //MessageBox.Show(message, title);
        }
    }
}
