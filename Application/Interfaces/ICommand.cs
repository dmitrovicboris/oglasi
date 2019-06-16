using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface ICommand<TRequset>
    {
        void Execute(TRequset request);
    }
    public interface ICommand<TRequset,TResponse>
    {
        TResponse Execute(TRequset request);
    }
}
