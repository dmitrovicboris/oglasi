using Application.Commands;
using Application.DataTransfer.CreateDtos;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfEditFuelCommand : BaseCommand, IEditFuelCommand
    {
        public EfEditFuelCommand(MyDbContext context) : base(context)
        {
        }

        public void Execute(NapraviVrstuGoriva request)
        {
            var fuels = Context.VrsteGoriva.Find(request.GorivoId);
            if (Context.VrsteGoriva.Where(x => x.Id != request.GorivoId).Any(g => g.Naziv == request.VrstaGoriva))
            {
                throw new EntityAlreadyExists("Gorivo");
            }

            try
            {
                fuels.DateModified = DateTime.Now;
                fuels.Naziv = request.VrstaGoriva;
                Context.SaveChanges();
            }
            catch
            {
                throw new NullReferenceException("Something went wrong with update in db");
            }
        }
    }
}
