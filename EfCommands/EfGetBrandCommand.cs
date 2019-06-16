using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfGetBrandCommand : BaseCommand, IGetBrandCommand
    {
        public EfGetBrandCommand(MyDbContext context) : base(context)
        {
        }

        public MarkaDto Execute(int request)
        {
            var marka = Context.Marke.Find(request);
            if (marka == null)
                throw new EntityNotFoundException("Marka");

            return new MarkaDto
            {
                Id = marka.Id,
                Marka = marka.MarkaAutomobila
            };
        }
    }
}
