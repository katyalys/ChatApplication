using System.ComponentModel.DataAnnotations;

namespace ChatApplication.Models
{
    public class UsersModel
    {
        public UsersModel()
        {
            Messages = new HashSet<MessageModel>();
        }

        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<MessageModel> Messages { get; set; }
    }
}
