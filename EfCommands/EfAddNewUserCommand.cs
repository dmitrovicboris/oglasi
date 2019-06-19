using Application.Commands;
using Application.DataTransfer.CreateDtos;
using Application.Exceptions;
using Domain;
using EfCommands.Encryption;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfAddNewUserCommand : BaseCommand, IAddNewUserCommand
    {
        public EfAddNewUserCommand(MyDbContext context) : base(context)
        {
        }

        public void Execute(NapraviKorisnika request)
        {
            if (request == null)
                throw new NullReferenceException("Korisnik");
            if (Context.Korisnici.Any(k => k.Email == request.Email))
            {
                throw new EntityAlreadyExists("Korisnik");
            }

            var korisnik = new Korisnik
            {
                Ime = request.Ime,
                Prezime = request.Prezime,
                Email = request.Email,
                Password = HashPasswordCommand.MD5Hash(request.Password),
                DateCreated = DateTime.Now
            };
            try
            {
                Context.Korisnici.Add(korisnik);
                Context.SaveChanges();
            }
            catch (Exception)
            {
                throw new EntryPointNotFoundException();
            }
        }
    }
}
