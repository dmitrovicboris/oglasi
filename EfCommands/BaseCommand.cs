using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class BaseCommand
    {
        protected MyDbContext Context { get; }

        public BaseCommand(MyDbContext context)
        {
            Context = context;
        }

    }
}
