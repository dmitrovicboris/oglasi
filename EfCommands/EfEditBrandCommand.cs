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
    public class EfEditBrandCommand : BaseCommand, IEditBrandCommand
    {
        public EfEditBrandCommand(MyDbContext context) : base(context)
        {
        }

        public void Execute(NapraviIzmeniMarku request)
        {
            var brands = Context.Marke.Find(request.MarkaId);
            if (Context.Marke.Where(x => x.Id != request.MarkaId).Any(m => m.MarkaAutomobila == request.Marka))
            {
                throw new EntityAlreadyExists("Model");
            }

            try
            {
                brands.DateModified = DateTime.Now;
                brands.MarkaAutomobila = request.Marka;
                Context.SaveChanges();
            }
            catch
            {
                throw new NullReferenceException("Something went wrong with update in db");
            }
        }
    }
}
