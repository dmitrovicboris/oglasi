using Application.DataTransfer;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public interface IGetCarCommand : ICommand<int,AutomobilDto>
    {
    }
}
