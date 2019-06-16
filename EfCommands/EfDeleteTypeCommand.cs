using Application.Commands;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeleteTypeCommand : BaseCommand, IDeleteTypeCommand
    {
        public EfDeleteTypeCommand(MyDbContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var tip = Context.Tipovi.Find(request);
            try
            {
                Context.Tipovi.Remove(tip);
                Context.SaveChanges();
            }
            catch
            {
                throw new EntityNotFoundException("Type");
            }
        }
    }
}
