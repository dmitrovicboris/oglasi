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
    public class EfEditTypeCommand : BaseCommand, IEditTypeCommand
    {
        public EfEditTypeCommand(MyDbContext context) : base(context)
        {
        }

        public void Execute(NapraviNoviTip request)
        {
            var type = Context.Tipovi.Find(request.TipId);
            if (Context.Tipovi.Any(t => t.Type == request.Tip))
            {
                throw new EntityAlreadyExists("Tip");
            }

            try
            {
                type.DateModified = DateTime.Now;
                type.Type = request.Tip;
                Context.SaveChanges();
            }
            catch
            {
                throw new NullReferenceException("Something went wrong with update in db");
            }
        }
    }
}
