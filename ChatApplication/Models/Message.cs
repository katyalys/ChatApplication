namespace ChatApplication.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string MesTitle { get; set; }
        public string MesBody { get; set; }

        public virtual User UsersModel { get; set; } 
        public User Reciever { get; set; }
    }
}
