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
    public class EfIAddNewFuelTypeCommand : BaseCommand, IAddNewFuelTypeCommand
    {
        public EfIAddNewFuelTypeCommand(MyDbContext context) : base(context)
        {
        }

        public void Execute(NapraviVrstuGoriva request)
        {
            if (request == null)
                throw new NullReferenceException("Gorivo");
            if(Context.VrsteGoriva.Any(g => g.Naziv == request.VrstaGoriva))
            {
                throw new EntityAlreadyExists("Gorivo");
            }

            var gorivo = new Gorivo
            {
                Naziv = request.VrstaGoriva,
                DateCreated = DateTime.Now
            };
            try
            {
                Context.VrsteGoriva.Add(gorivo);
                Context.SaveChanges();
            }
            catch(Exception)
            {
                throw new EntryPointNotFoundException();
            }
        }
    }
}
