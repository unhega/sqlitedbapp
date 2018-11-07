namespace sqlitedbapp.Models
{
    public class Price
    {
        // Настроить автоинкримент и ключевое поле
        public int Id {get; set;}
        public long TimeStamp {get; set;}
        public float USD {get; set;}
        public float RUB {get; set;}
    }
}