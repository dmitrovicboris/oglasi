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
    public class EfAddCategoryCommand : BaseCommand, IAddCategoryCommand
    {
        public EfAddCategoryCommand(MyDbContext context) : base(context)
        {
        }

        public void Execute(NapraviNovuKategoriju request)
        {
            if (request == null)
                throw new NullReferenceException("Kategorija");
            if (Context.Kategorije.Any(m => m.Naziv == request.Naziv))
            {
                throw new EntityAlreadyExists("Kategorija");
            }

            var kategorija = new Kategorija
            {
                Naziv = request.Naziv,
                DateCreated = DateTime.Now
            };
            try
            {
                Context.Kategorije.Add(kategorija);
                Context.SaveChanges();
            }
            catch (Exception)
            {
                throw new EntryPointNotFoundException("Kategorija");
            }
        }
    }
}
