using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApplication.Models
{
    public class MessageModel
    {
        [Key]
        public int MessageId { get; set; }
        public string MesTitle { get; set; }
        public string MesBody { get; set; }

        public virtual UsersModel UsersModel { get; set; } // навигационное свойство

        [ForeignKey("UsersModel")]
        public UsersModel Reciever { get; set; }

    }
}
