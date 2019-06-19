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
    public class EfEditModelCommand : BaseCommand, IEditModelCommand
    {
        public EfEditModelCommand(MyDbContext context) : base(context)
        {
        }

        public void Execute(NapraviNovModel request)
        {
            var models = Context.Modeli.Find(request.ModelId);
            if (Context.Modeli.Where(x => x.Id != request.ModelId).Any(g => g.Model == request.Model))
            {
                throw new EntityAlreadyExists("Model");
            }
            if (!Context.Marke.Any(m => m.Id == request.MarkaId))
            {
                throw new EntityAlreadyExists("Marka");
            }

            try
            {
                models.DateModified = DateTime.Now;
                models.Model = request.Model;
                Context.SaveChanges();
            }
            catch
            {
                throw new NullReferenceException("Something went wrong with update in db");
            }
        }
    }
}
