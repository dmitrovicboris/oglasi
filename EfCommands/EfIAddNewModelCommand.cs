using Application.Commands;
using Application.DataTransfer.CreateDtos;
using Application.Exceptions;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfIAddNewModelCommand : BaseCommand, IAddNewModelCommand
    {
        public EfIAddNewModelCommand(MyDbContext context) : base(context)
        {
        }

        public void Execute(NapraviNovModel request)
        {
            if (request == null)
                throw new NullReferenceException("Model");
            if (Context.Modeli.Any(m => m.Model == request.Model))
            {
                throw new EntityAlreadyExists("Model");
            }
            if (!Context.Marke.Any(ma => ma.Id == request.MarkaId))
            {
                throw new EntityAlreadyExists("Marka");
            }

            var model = new ModelAutomobila
            {
                Model = request.Model,
                MarkaId = request.MarkaId,
                DateCreated = DateTime.Now
            };
            try
            {
                Context.Modeli.Add(model);
                Context.SaveChanges();
            }
            catch (Exception)
            {
                throw new EntryPointNotFoundException();
            }
        }
    }
}
