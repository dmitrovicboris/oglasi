using Application.Commands;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeleteFuelCommand : BaseCommand, IDeleteFuelCommand
    {
        public EfDeleteFuelCommand(MyDbContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var gorivo = Context.VrsteGoriva.Find(request);
            try
            {
                Context.VrsteGoriva.Remove(gorivo);
                Context.SaveChanges();
            }
            catch
            {
                throw new EntityNotFoundException("Gorivo");
            }
        }
    }
}
