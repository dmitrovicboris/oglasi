using Application.Commands;
using Application.DataTransfer;
using Application.Responses;
using Application.SearchObjects;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetFuelsCommand : BaseCommand, IGetFuelsCommand
    {
        public EfGetFuelsCommand(MyDbContext context) : base(context)
        {
        }

        public PageResponse<GorivoDto> Execute(FuelSearch request)
        {
            var query = Context.VrsteGoriva.AsQueryable().Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);
            var totalRecords = query.Count();
            var pagesCount = (int)Math.Ceiling((double)totalRecords / request.PerPage);
            if (request != null)
            {
                if (request.Keyword != null)
                {
                    query = query.Where(g => g.Naziv
                    .ToLower()
                    .Contains(request.Keyword.ToLower()));
                }
                totalRecords = query.Count();
                var response = new PageResponse<GorivoDto>
                {
                    CurrentPage = request.PageNumber,
                    TotalCount = totalRecords,
                    PagesCount = pagesCount,
                    Data = query.Select(g => new GorivoDto
                    {
                        Id = g.Id,
                        NazivGoriva = g.Naziv,
                        DateCreated = g.DateCreated,
                        DateModified = g.DateModified
                    })
                };

                return response;
            }
            else
            {
                return new PageResponse<GorivoDto>
                {
                    CurrentPage = request.PageNumber,
                    TotalCount = totalRecords,
                    PagesCount = pagesCount,
                    Data = query.Select(g => new GorivoDto
                    {
                        Id = g.Id,
                        NazivGoriva = g.Naziv,
                        DateCreated = g.DateCreated,
                        DateModified = g.DateModified
                    })
                };
            }
        }
    }
}
