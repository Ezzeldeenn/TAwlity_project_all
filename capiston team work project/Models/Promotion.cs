namespace capiston_team_work_project.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }

}
