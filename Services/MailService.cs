using BackEndProject.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Services
{
    public class MailService
    {
        private IConfiguration _config;
        public MailService(IConfiguration config)
        {
            _config = config;
        }
        public void SendVerificationMail(MailModel mail)
        {
            var message = new MimeMessage();
            message.To.Add(new MailboxAddress(mail.toName, mail.toAdr));
            message.From.Add(new MailboxAddress(mail.fromName, mail.fromAdr));

            message.Subject = mail.subject;
            //We will say we are sending HTML. But there are options for plaintext etc. 
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = mail.content
            };

            //Be careful that the SmtpClient class is the one from Mailkit not the framework!
            using (var emailClient = new SmtpClient())
            {
                emailClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
                //The last parameter here is to use SSL (Which you should!)
                emailClient.Connect("smtp.gmail.com",465,true);

                //Remove any OAuth functionality as we won't be using it. 
                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

                emailClient.Authenticate(_config["EmailConfiguration:SmtpUsername"], _config["EmailConfiguration:SmtpPassword"]);

                emailClient.Send(message);

                emailClient.Disconnect(true);
            }
        }
    }
}
