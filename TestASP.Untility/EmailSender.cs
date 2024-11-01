using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookASP.Utility
{
    public class EmailSender:IEmailSender
    {
        public Task SendEmailAsync(string email ,string subject,string htmlMessage)
        {
            //! muốn gửi có thể thêm logic vào
            return Task.CompletedTask;
        }
    }
}
