using System;
using System.Web;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MessageSender.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace MessageSender.Controllers
{
    public class HomeController : Controller
    {
      
        private MessageDBContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(MessageDBContext context)
        {
            
           

          
            _context = context;

           
        }

        public IActionResult SendMessage(ViewUserMessage user_message)
        {
            try
            {
                User user = new User();
                Message message = new Message();

                Random rnd = new Random();

                bool is_exist = false;

                foreach (User u in _context.AllUsers.ToList())
                {
                    if (u.UserName == user_message.UserName)
                    {
                        is_exist = true;
                        message.UserId = u.Id;
                        break;
                    }
                }

                message.DateSending = DateTime.Now;
                message.TextMessage = user_message.TextMessage;

                if (is_exist == false)
                {
                    user.Id = rnd.Next(100000, 999999);
                    user.UserName = user_message.UserName;
                    message.UserId = user.Id;
                }


                _context.AllUsers.Add(user);
                _context.AllMessage.Add(message);
                _context.SaveChanges();


                return RedirectToRoute(new { action = "Index" });
            }
            catch (Exception ex)
            {


                string exceptionMessage = ex.Message;
                return RedirectToRoute(new { controller = "Error", action = "Error", exceptionMessage = exceptionMessage });
            }
        }
        public List<Message> Serch(User user)
        {
            
                var allmessages = _context.AllMessage.ToList();
                var allusers = _context.AllUsers.ToList();
                List<Message> listMessage = new List<Message>();
                bool is_user_exist = false;
                foreach (User u in allusers)
                {
                    if (u.UserName == user.UserName)
                    {
                        user.Id = u.Id;
                    }
                }
                if (is_user_exist == false)
                {

                }
                foreach (Message m in allmessages)
                {
                    if (m.UserId == user.Id)
                    {
                        listMessage.Add(m);
                    }
                }
                ViewBag.UsersMessages = listMessage;

                return listMessage;
            
            


        }


        public IActionResult Index(User user)
        {
            try
            {
                List<Message> listMessages = new List<Message>();
                listMessages = Serch(user);
                var allmessages = _context.AllMessage.ToList();
                ViewBag.AllMessages = allmessages;
                ViewBag.UsersMessages = listMessages;
                return View();
            }
            catch (Exception ex)
            {


                string exceptionMessage = ex.Message;
                return RedirectToRoute(new { controller = "Error", action = "Error", exceptionMessage = exceptionMessage });
            }
            

            
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
