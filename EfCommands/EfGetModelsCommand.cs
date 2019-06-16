using Application.Commands;
using Application.DataTransfer;
using Application.Responses;
using Application.SearchObjects;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetModelsCommand : BaseCommand, IGetModelsCommand
    {
        public EfGetModelsCommand(MyDbContext context) : base(context)
        {
        }

        public PageResponse<ModelDto> Execute(ModelSearch request)
        {
            var query = Context.Modeli.Include(m => m.Marka).AsQueryable().Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);
            var totalRecords = query.Count();
            var pagesCount = (int)Math.Ceiling((double)totalRecords / request.PerPage);
            if (request != null)
            {
                if (request.Keyword != null)
                {
                    query = query.Where(m => m.Model
                    .ToLower()
                    .Contains(request.Keyword.ToLower()));
                }
                totalRecords = query.Count();
                var response = new PageResponse<ModelDto>
                {
                    CurrentPage = request.PageNumber,
                    TotalCount = totalRecords,
                    PagesCount = pagesCount,
                    Data = query.Select(m => new ModelDto
                    {
                        Id = m.Id,
                        Model = m.Model,
                        Marka = m.Marka.MarkaAutomobila,
                        DateCreated = m.DateCreated,
                        DateModified = m.DateModified
                    })
                };

                return response;
            }
            else
            {
                return new PageResponse<ModelDto>
                {
                    CurrentPage = request.PageNumber,
                    TotalCount = totalRecords,
                    PagesCount = pagesCount,
                    Data = query.Select(m => new ModelDto
                    {
                        Id = m.Id,
                        Model = m.Model,
                        DateCreated = m.DateCreated,
                        DateModified = m.DateModified
                    })
                };
            }
        }
    }
}
