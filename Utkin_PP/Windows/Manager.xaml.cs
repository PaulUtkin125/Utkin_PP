using System.ComponentModel;
using System.Windows;
using Utkin_PP.Data;
using Utkin_PP.Models;
using Utkin_PP.Models.Db;
using Utkin_PP.Models.Interface;

namespace Utkin_PP.Windows
{
    /// <summary>
    /// Логика взаимодействия для Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        private readonly IInformationService _informationService;
        private readonly IValidationManager _validationManager;
        private readonly IMessageService _messageService;
        private readonly ICalculateService _calculateService;
        private readonly DbContact _context;

        private int uId;
        public Manager()
        {
            InitializeComponent();
            _context = new DbContact();

            _messageService = new MessageService();
            _validationManager = new ValidationManagerService(_messageService);
            _calculateService = new CalculateService();
            _informationService = new InformationService(_context);


            WorkerList_DG.ItemsSource = _informationService.NoHeaderWorkerList();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _context.Dispose();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            base.OnClosing(e);
        }

        private void SelectedWorker_Click(object sender, RoutedEventArgs e)
        {
            var worker_Exist = WorkerList_DG.SelectedItem as Employee;
            if (worker_Exist is null)
            {
                _messageService.Message("Работник не выбран!", "Error");
                return;
            }
            uId = worker_Exist.Id;

            switch (worker_Exist.formOfRemunerationId)
            {
                case 1:
                    SimpleSystem.Visibility = Visibility.Visible;

                    NoN.Visibility = Visibility.Collapsed;
                    piecework_premium.Visibility = Visibility.Collapsed;
                    piecework_progressive.Visibility = Visibility.Collapsed;
                    Indirectly_piecework.Visibility = Visibility.Collapsed;
                    break;

                case 2:
                    piecework_premium.Visibility = Visibility.Visible;

                    NoN.Visibility = Visibility.Collapsed;
                    SimpleSystem.Visibility = Visibility.Collapsed;
                    piecework_progressive.Visibility = Visibility.Collapsed;
                    Indirectly_piecework.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    piecework_progressive.Visibility = Visibility.Visible;

                    NoN.Visibility = Visibility.Collapsed;
                    SimpleSystem.Visibility = Visibility.Collapsed;
                    piecework_premium.Visibility = Visibility.Collapsed;
                    Indirectly_piecework.Visibility = Visibility.Collapsed;
                    break;
                case 4:
                    Indirectly_piecework.Visibility = Visibility.Visible;

                    NoN.Visibility = Visibility.Collapsed;
                    SimpleSystem.Visibility = Visibility.Collapsed;
                    piecework_premium.Visibility = Visibility.Collapsed;
                    piecework_progressive.Visibility = Visibility.Collapsed;
                    break;
            }

        }

        private void Vuchisl_Click(object sender, RoutedEventArgs e)
        {
            if (SimpleSystem.Visibility == Visibility.Visible)
            {
                string _KolProizvProd = KolProizvProd.Text;
                string _Stavka = Stavka.Text;
                string _NormaVurabotki = NormaVurabotki.Text;
                if (!_validationManager.SimpleSystem(_KolProizvProd, _Stavka, _NormaVurabotki)) return;

                ZP.Text = _calculateService.CalculateSimpleSystem(double.Parse(_KolProizvProd), double.Parse(_Stavka), int.Parse(_NormaVurabotki)).ToString();
            }
            else if (piecework_premium.Visibility == Visibility.Visible) 
            {
                string _KolProizvProd = KolProizvProd1.Text;
                string _Stavka = Stavka1.Text;
                string _NormaVurabotki = NormaVurabotki.Text;
                string _Premia = Premiiy.Text;
                if (!_validationManager.Piecework_premium(_Premia, _KolProizvProd, _Stavka, _NormaVurabotki)) return;
                
                ZP.Text = _calculateService.CalculatePiecework_premium(int.Parse(_Premia), double.Parse(_KolProizvProd), double.Parse(_Stavka), int.Parse(_NormaVurabotki)).ToString();
            }
            else if (piecework_progressive.Visibility == Visibility.Visible)
            {
                string _quentity = KolProizvProd2.Text;
                string _StavkayDo = sdelRascDoPznach.Text;
                string _StavkaPosle = sdelRascPoslePznach.Text;
                string _Porog = porog.Text;
                if(!_validationManager.Piecework_progressive(_Porog, _StavkayDo, _StavkaPosle, _quentity)) return;

                ZP.Text = _calculateService.CalculatePiecework_progressive(double.Parse(_Porog), double.Parse(_StavkayDo), double.Parse(_StavkaPosle), double.Parse(_quentity)).ToString();
            }
            else if (Indirectly_piecework.Visibility == Visibility.Visible)
            {
                string _ZpOspZavoda = ZPOsnProizv.Text;
                string _procent = Procent.Text;
                if(!_validationManager.Indirectly_piecework(_ZpOspZavoda, _procent)) return;

                ZP.Text = _calculateService.CalculateIndirectly_piecework(double.Parse(_ZpOspZavoda), double.Parse(_procent)).ToString();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (ZP.Text == "0")
            {
                _messageService.Message("Зарплата не рассчитана", "Error");
                return;
            }

            WorkInformation workInformation = new ()
            {
                EmployeeId = uId,
                Salary = double.Parse(ZP.Text)
            };

            _informationService.SaveData(workInformation);

            _messageService.Message("Запись сохранена", "Message");
        }
    }
}
