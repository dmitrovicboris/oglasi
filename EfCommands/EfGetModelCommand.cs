using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetModelCommand : BaseCommand, IGetModelCommand
    {
        public EfGetModelCommand(MyDbContext context) : base(context)
        {
        }

        public ModelDto Execute(int request)
        {
            var modeli = Context.Modeli.Include(m => m.Marka).AsQueryable();
            var model = modeli.Where(x => x.Id == request).FirstOrDefault();
            if (model == null)
                throw new EntityNotFoundException("Marka");

            return new ModelDto
            {
                Id = model.Id,
                Model = model.Model
            };
        }
    }
}
