using TestTask.Enums;

namespace TestTask.Models
{
    public class VMUser
    {
        public int Id { get; set; } 

        public string Email { get; set; }

        public UserStatus Status { get; set; }
        public int NumberOfOrders { get; set; }
    }
}
