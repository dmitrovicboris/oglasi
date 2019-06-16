using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class EntityAlreadyExists : Exception
    {
        public EntityAlreadyExists(string entity) : base($"{entity} already exists.")
        {

        }
    }
}
