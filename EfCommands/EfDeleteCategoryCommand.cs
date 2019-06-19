using Application.Commands;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeleteCategoryCommand : BaseCommand, IDeleteCategoryCommand
    {
        public EfDeleteCategoryCommand(MyDbContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var kategorija = Context.Kategorije.Find(request);
            try
            {
                Context.Kategorije.Remove(kategorija);
                Context.SaveChanges();
            }
            catch
            {
                throw new EntityNotFoundException("Kategorija");
            }
        }
    }
}
