using Application.Commands;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeleteModelCommand : BaseCommand, IDeleteModelCommand
    {
        public EfDeleteModelCommand(MyDbContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var model = Context.Modeli.Find(request);
            try
            {
                Context.Modeli.Remove(model);
                Context.SaveChanges();
            }
            catch
            {
                throw new EntityNotFoundException("Model");
            }
        }
    }
}
