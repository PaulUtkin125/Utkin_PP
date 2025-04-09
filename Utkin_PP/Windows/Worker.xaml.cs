using System.ComponentModel;
using System.Windows;
using Utkin_PP.Data;
using Utkin_PP.Models;
using Utkin_PP.Models.Interface;

namespace Utkin_PP.Windows
{
    /// <summary>
    /// Логика взаимодействия для Worker.xaml
    /// </summary>
    public partial class Worker : Window
    {
        private readonly IWorkerInformation _workerInformation; // Использование интерфейса для абстракции (Принцип инверсии зависимостей)
        private readonly IMessageService _messageService; // Использование интерфейса для абстракции (Принцип инверсии зависимостей)
        private int id;

        private readonly DbContact _context;

        public Worker(int uId)
        {
            InitializeComponent();
            id = uId;

            _context = new DbContact();

            _messageService = new MessageService();
            _workerInformation = new WorkerInformationService(_context);

            var user_Exist = _workerInformation.WorkerInf(id);
            TabelNumber_TextBlock.Text = user_Exist.Id.ToString();
            LastName_TextBlock.Text = user_Exist.LastName.ToString();

            var workerHistory_Exist = _workerInformation.ZpInformation(id);
            if (workerHistory_Exist is null)
            {
                _messageService.Message("Данные о зарплате не найдены", "Error");
                Zp_TextBlock.Text = "NoN";
                return;
            }
            else 
            {
                Zp_TextBlock.Text = workerHistory_Exist.Salary.ToString() + "руб.";
            }

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _context.Dispose();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            base.OnClosing(e);
        }
    }
}
