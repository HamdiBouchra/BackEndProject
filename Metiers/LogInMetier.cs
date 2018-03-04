using BackEndProject.Helpers;
using BackEndProject.Models;
using BackEndProject.Services;
using MailKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Metiers
{
    public class LogInMetier
    {
        private IConfiguration _config;
        private Services.MailService _mailService;
        private TokenHelper _tokenHelper;

        private readonly CRMv1Context _context;
        public LogInMetier(IConfiguration config)
        {
            _config = config;
            _mailService = new Services.MailService(config);
            _tokenHelper = new TokenHelper(config);
            _context = new CRMv1Context();

        }

        public void SendMail(MailModel mail)
        {
            _mailService.SendVerificationMail(mail);
        }
  
        public PublicUser Authenticate(LoginModel login)
        {
            PublicUser UserTmp = _context.PublicUser.Include(pp => pp.Role).Include(pp => pp.Contact)
                .ThenInclude(c => c.CompteContact).ThenInclude(cc => cc.IdCptNavigation)
                .FirstOrDefault(pp => pp.Username == login.Username);
            
            if (UserTmp != null)
            {
                if ((UserTmp.Password != login.Password) || (UserTmp.EstActive == false))
                {
                    return null;
                }
                else
                {
                    UserTmp.Password = null;
                    return  UserTmp;
                }
            }
            return null;
        }

    

    }
}
