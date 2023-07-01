using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMWebApp.Application.ATM.Commands
{
    public class LoginCommand: IRequest<Guid>
    {
        public int? Pin { get; set; }
        public string? Password { get; set; }
    }
}
