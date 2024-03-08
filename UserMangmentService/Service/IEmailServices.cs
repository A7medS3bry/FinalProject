using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMangmentService.Models;

namespace UserMangmentService.Service
{
    public interface IEmailServices
    {
        void SendEmail(Message messag);

    }
}
