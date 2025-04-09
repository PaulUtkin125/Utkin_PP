namespace Utkin_PP.Models.Db
{
    // В этом классе представлен принцип единственной ответственности:
    // Класс отвечает только за одну задачу: хранение данных о ролях/должностях работников
    class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
