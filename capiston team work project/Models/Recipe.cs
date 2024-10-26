namespace capiston_team_work_project.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Instructions { get; set; }
        public DateTime PostedAt { get; set; }
        public int PostedBy { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public string Ingredients { get; set; }
        
    }

}
