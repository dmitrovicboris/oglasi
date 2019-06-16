using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfGetFuelCommand : BaseCommand, IGetFuelCommand
    {
        public EfGetFuelCommand(MyDbContext context) : base(context)
        {
        }

        public GorivoDto Execute(int request)
        {
            var gorivo = Context.VrsteGoriva.Find(request);
            if (gorivo == null)
                throw new EntityNotFoundException("Gorivo");

            return new GorivoDto
            {
                Id = gorivo.Id,
                NazivGoriva = gorivo.Naziv
            };
        }
    }
}
