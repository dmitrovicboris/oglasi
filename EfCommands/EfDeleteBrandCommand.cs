using Application.Commands;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeleteBrandCommand : BaseCommand, IDeleteBrandCommand
    {
        public EfDeleteBrandCommand(MyDbContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var marka = Context.Marke.Find(request);
            try
            {
                Context.Marke.Remove(marka);
                Context.SaveChanges();
            }
            catch
            {
                throw new EntityNotFoundException("Marka");
            }
        }
    }
}
