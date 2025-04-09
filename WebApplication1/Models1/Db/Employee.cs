namespace WebApplication1.Controllers.Db
{
    public class Employee
    {
        // В этом классе представлен принцип единственной ответственности:
        // Класс отвечает только за одну задачу: хранение данных о сотруднике
        public int Id { get; set; }  // табельный №

        public string LastName { get; set; }

        public FormOfRemuneration formOfRemuneration { get; set; }
        public int formOfRemunerationId { get; set; }

        public Role Role { get; set; }
        public int RoleId { get; set; } = 3;
    }
}
