using Application.Commands;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeleteCarCommand : BaseCommand, IDeleteCarCommand
    {
        public EfDeleteCarCommand(MyDbContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var automobil = Context.Automobili.Find(request);
            try
            {
                Context.Automobili.Remove(automobil);
                Context.SaveChanges();
            }
            catch
            {
                throw new EntityNotFoundException("Automobil");
            }
        }
    }
}
