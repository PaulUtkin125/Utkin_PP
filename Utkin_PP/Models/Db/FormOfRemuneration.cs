namespace Utkin_PP.Models.Db
{
    internal class FormOfRemuneration
    {
        // В этом классе представлен принцип единственной ответственности:
        // Класс отвечает только за одну задачу: хранение данных о формах оплаты труда
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
