using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace GestionParqueo.Application.Features.Auth.Commands
{
    public class LoginCommand : IRequest<string> // Devuelve el token como string
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}