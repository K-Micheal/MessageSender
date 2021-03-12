using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageSender.Models
{
    public class ViewUserMessage
    {
        public int? UserId { get; set; }
        public DateTime DateSending { get; set; }
        public string TextMessage { get; set; }
        public string UserName { get; set; }
    }
}
