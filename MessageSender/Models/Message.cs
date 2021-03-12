using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageSender.Models
{
    public class Message
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public DateTime DateSending { get; set; }
        public string TextMessage { get; set; }
        

    }
}
