using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfGetCategoryCommand : BaseCommand, IGetCategoryCommand
    {
        public EfGetCategoryCommand(MyDbContext context) : base(context)
        {
        }

        public KategorijaDto Execute(int request)
        {
            var kategorija = Context.Kategorije.Find(request);
            if (kategorija == null)
                throw new EntityNotFoundException("Kategorija");

            return new KategorijaDto
            {
                Id = kategorija.Id,
                Kategorija = kategorija.Naziv,
                DateCreated = kategorija.DateCreated
            };
        }
    }
}
