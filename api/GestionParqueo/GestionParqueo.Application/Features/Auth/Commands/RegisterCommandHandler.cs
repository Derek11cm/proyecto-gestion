using MediatR;
using GestionParqueo.Application.Interfaces;
using GestionParqueo.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace GestionParqueo.Application.Features.Auth.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public RegisterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new Usuario
            {
                Username = request.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            return user.Id;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA256())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}