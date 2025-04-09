using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using Utkin_PP.Data;
using Utkin_PP.Models;
using Utkin_PP.Models.Db;
using Utkin_PP.Models.Interface;
using Utkin_PP.Windows;

using WebApplication1.Controllers;
using WebApplication1.Controllers.Db;

namespace Utkin_PP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private readonly IValidationLogin _validationLogin;
        //private readonly ILogo _informationService;
        //private readonly DbContact _context;

        //private readonly EmloeAPI _emloeAPI;
        //private readonly HttpClient _httpClient;

        public MainWindow()
        {
            InitializeComponent();

            //_context = new DbContact();

            //_httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:5054/") };

            MessageService messageService = new MessageService();
            //_validationLogin = new ValidationOfdata(messageService);
            //_informationService = new LogoService(_context);

            LoadUsers();

            //_emloeAPI = new EmloeAPI();
            //foreach (var worker in _emloeAPI.GetRt())
            //{
            //    Role_ComboBox.Items.Add(worker);
            //}

        }

        private async void LoadUsers()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5054/"); // заходит на главную страницу API ("сервера")
                var response = await client.PostAsJsonAsync("api/EmloeAPI/post_employee", ""); // запрашивает выполнение метода с именем "post_employee" из контролера EmloeAPI

                if (response.IsSuccessStatusCode)
                {
                    var employees = await response.Content.ReadFromJsonAsync<List<WebApplication1.Controllers.Db.Employee>>();
                    foreach (var worker in employees)
                    {
                        Role_ComboBox.Items.Add(worker);
                    }
                }
            }
            
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            //_context.Dispose();
            base.OnClosing(e);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
        //    var selectRol = Role_ComboBox.SelectedItem as Employee;
        //    int selectIndex = Role_ComboBox.SelectedIndex;
        //    if(_validationLogin.Login(selectIndex) == false) return;

        //    if (selectRol.RoleId == 1)
        //    {
        //        HrDepartment hrDepartment = new HrDepartment();
        //        hrDepartment.Show();

        //    }
        //    else if (selectRol.RoleId == 2)
        //    {
        //        Manager manager = new Manager();
        //        manager.Show();
        //    }
        //    else 
        //    {
        //        Worker worker = new Worker(selectRol.Id);
        //        worker.Show();
        //    }
        //    Close();
        }
    }
}