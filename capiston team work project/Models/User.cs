namespace capiston_team_work_project.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<CommunityPost> CommunityPosts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
        public Address Address { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }

}
//good day for models and Dbcontext