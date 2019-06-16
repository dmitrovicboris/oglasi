using Application.DataTransfer;
using Application.Interfaces;
using Application.Responses;
using Application.SearchObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public interface IGetCarsCommand : ICommand<PretragaAutomobila,PageResponse<AutomobilDto>>
    {
    }
}
