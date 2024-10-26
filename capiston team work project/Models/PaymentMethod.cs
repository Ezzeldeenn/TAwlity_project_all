namespace capiston_team_work_project.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string Method { get; set; } // e.g., Credit Card, PayPal, etc.
        public ICollection<Order> Orders { get; set; }
    }

}
