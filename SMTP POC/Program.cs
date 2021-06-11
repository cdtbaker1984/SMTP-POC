using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SMTP_POC
{
    class Program
    {
        private static MailMessage mailMessage;
        static void Main(string[] args)
        {
            Console.WriteLine($"START:");
            CreateMessage();
          
            To();
            //From();
            SMTP_Send();
            Console.WriteLine($"FINISH:");
        }

      

        private static void CreateMessage()
        {
            Console.WriteLine($"Creating Message");
            mailMessage = new MailMessage
            {
                From = new MailAddress("testSMTP@capita-ic.com"),
                Subject = "subject",
                Body = "<h1>Hello</h1>",
                IsBodyHtml = true,
            };
         

        }

        private static void To()
        {
            Console.WriteLine($"Adding Recipents");
            mailMessage.To.Add(new MailAddress("christopher.baker@capita.com"));
        }

        private static void From()
        {
            Console.WriteLine($"Adding From Address");
            mailMessage.From = new MailAddress("");
        }

        private static void SMTP_Send()
        {
            var smtpClient = new SmtpClient("smtp.capita-ic.com")
            {
                Port = 25,
               // Credentials = new NetworkCredential("email", "password"),
                EnableSsl = true,
            };
            Console.WriteLine($"Sending Message......");
            smtpClient.Send(mailMessage);
            Console.WriteLine($"Sent");
        }
    }
}
