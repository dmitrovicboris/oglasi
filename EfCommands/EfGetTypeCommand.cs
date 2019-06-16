using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfGetTypeCommand : BaseCommand, IGetTypeCommand
    {
        public EfGetTypeCommand(MyDbContext context) : base(context)
        {
        }

        public TypeDto Execute(int request)
        {
            var tip = Context.Tipovi.Find(request);
            if (tip == null)
                throw new EntityNotFoundException("Type");

            return new TypeDto
            {
                Id = tip.Id,
                Type = tip.Type
            };
        }
    }
}
