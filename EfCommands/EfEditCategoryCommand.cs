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
    public class EfEditCategoryCommand : BaseCommand, IEditCategoryCommand
    {
        public EfEditCategoryCommand(MyDbContext context) : base(context)
        {
        }

        public void Execute(NapraviNovuKategoriju request)
        {
            var kategorija = Context.Kategorije.Find(request.KategorijaId);
            if (Context.Kategorije.Where(x => x.Id != request.KategorijaId).Any(g => g.Naziv == request.Naziv))
            {
                throw new EntityAlreadyExists("Kategorija");
            }

            try
            {
                kategorija.DateModified = DateTime.Now;
                kategorija.Naziv = request.Naziv;
                Context.SaveChanges();
            }
            catch
            {
                throw new NullReferenceException("Something went wrong with update in db");
            }
        }
    }
}
