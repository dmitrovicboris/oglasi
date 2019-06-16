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
    public class EfIAddNewBrandCommand : BaseCommand, IAddNewBrandCommand
    {
        public EfIAddNewBrandCommand(MyDbContext context) : base(context)
        {
        }

        public void Execute(NapraviIzmeniMarku request)
        {
            if (request == null)
                throw new NullReferenceException("Marka");
            if (Context.Marke.Any(m => m.MarkaAutomobila == request.Marka))
            {
                throw new EntityAlreadyExists("Marka");
            }

            var marka = new Marka
            {
                MarkaAutomobila = request.Marka,
                DateCreated = DateTime.Now
            };
            try
            {
                Context.Marke.Add(marka);
                Context.SaveChanges();
            }
            catch (Exception)
            {
                throw new EntryPointNotFoundException();
            }
        }
    }
}
