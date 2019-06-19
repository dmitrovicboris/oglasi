using Application.Commands;
using Application.DataTransfer.CreateDtos;
using Application.Exceptions;
using EfCommands.Encryption;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfEditUserCommand : BaseCommand, IEditUserCommand
    {
        public EfEditUserCommand(MyDbContext context) : base(context)
        {
        }

        public void Execute(NapraviKorisnika request)
        {
            var korisnik = Context.Korisnici.Find(request.KorisnikId);
            if (Context.Korisnici.Where(x => x.Id != request.KorisnikId).Any(k => k.Email == request.Email))
            {
                throw new EntityAlreadyExists("Korisnik");
            }

            try
            {
                korisnik.DateModified = DateTime.Now;
                korisnik.Ime = request.Ime;
                korisnik.Prezime = request.Prezime;
                korisnik.Email = request.Email;
                korisnik.Password = HashPasswordCommand.MD5Hash(request.Password);
                Context.SaveChanges();
            }
            catch
            {
                throw new NullReferenceException("Something went wrong with update in db");
            }
        }
    }
}
