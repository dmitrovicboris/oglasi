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
    public class EfIAddNewTypeCommand : BaseCommand, IAddNewTypeCommand
    {
        public EfIAddNewTypeCommand(MyDbContext context) : base(context)
        {
        }

        public void Execute(NapraviNoviTip request)
        {
            if (request == null)
                throw new NullReferenceException("Tip");
            if (Context.Tipovi.Any(m => m.Type == request.Tip))
            {
                throw new EntityAlreadyExists("Tip");
            }

            var tip = new Tip
            {
                Type = request.Tip,
                DateCreated = DateTime.Now
            };
            try
            {
                Context.Tipovi.Add(tip);
                Context.SaveChanges();
            }
            catch (Exception)
            {
                throw new EntryPointNotFoundException();
            }
        }
    }
}
