using Application.Commands;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeleteUserCommand : BaseCommand, IDeleteUserCommand
    {
        public EfDeleteUserCommand(MyDbContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var korisnik = Context.Korisnici.Find(request);
            try
            {
                Context.Korisnici.Remove(korisnik);
                Context.SaveChanges();
            }
            catch
            {
                throw new EntityNotFoundException("Korisnik");
            }
        }
    }
}
