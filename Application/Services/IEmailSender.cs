using Application.Common.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}
