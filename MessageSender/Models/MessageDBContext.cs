using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageSender.Models
{
    public class MessageDBContext:DbContext
    {
        public MessageDBContext(DbContextOptions<MessageDBContext> options)
       : base(options) { }

        public DbSet<Models.User> AllUsers { get; set; }
        public DbSet<Models.Message> AllMessage { get; set; }
    }
}
