namespace Utkin_PP.Models.Db
{
    internal class WorkInformation
    {
        // В этом классе представлен принцип единственной ответственности:
        // Клас отвечает только за одну задачу: хранение данных о з/п сотрудников
        public int Id { get; set; }

        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }

        public double Salary { get; set; }

    }
}
