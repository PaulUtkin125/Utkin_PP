using System.ComponentModel;
using System.Windows;
using Utkin_PP.Data;
using Utkin_PP.Models;
using Utkin_PP.Models.Db;
using Utkin_PP.Models.Interface;


namespace Utkin_PP.Windows
{
    /// <summary>
    /// Логика взаимодействия для HrDepartment.xaml
    /// </summary>
    public partial class HrDepartment : Window
    {
        private readonly ValidationOfdata _validationOfdata;
        private readonly EmployeeService _employeeService;
        private readonly IManagerDataService _information;
        private readonly DbContact _context;
        public HrDepartment()
        {
            InitializeComponent();

            _context = new DbContact();

            MessageService messageService = new MessageService();
            _validationOfdata = new ValidationOfdata(messageService);
            _employeeService = new EmployeeService(_context, messageService);
            _information = new ManagerDataService(_context);

            formOfRemuneration_ComboBox.ItemsSource = _information.HRDepartment_Support();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _context.Dispose();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            base.OnClosing(e);
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (!_validationOfdata.LastName(lastName_TextBox.Text.Trim())) return;
            if (!_validationOfdata.FormOfRemuneration(formOfRemuneration_ComboBox.SelectedIndex)) return;

            FormOfRemuneration workInformation_Exist = formOfRemuneration_ComboBox.SelectedItem as FormOfRemuneration;
            

            Employee employee = new()
            {
                LastName = lastName_TextBox.Text.Trim(),
                formOfRemunerationId = workInformation_Exist.Id
            };
            _employeeService.AddEmployee(employee);
        }
    }
}
