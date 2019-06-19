using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfGetUserCommand : BaseCommand, IGetUserCommand
    {
        public EfGetUserCommand(MyDbContext context) : base(context)
        {
        }

        public KorisnikDto Execute(int request)
        {
            var korisnik = Context.Korisnici.Find(request);
            if (korisnik == null)
                throw new EntityNotFoundException("Korisnik");

            return new KorisnikDto
            {
                Id = korisnik.Id,
                Ime = korisnik.Ime,
                Email = korisnik.Email,
                Prezime = korisnik.Prezime,
                DateCreated = korisnik.DateCreated,
                DateModified = korisnik.DateModified
            };
        }
    }
}
