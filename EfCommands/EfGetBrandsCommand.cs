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
    public class EfGetBrandsCommand : BaseCommand, IGetBrandsCommand
    {
        public EfGetBrandsCommand(MyDbContext context) : base(context)
        {
        }

        public PageResponse<MarkaDto> Execute(BrandSearch request)
        {
            var query = Context.Marke.AsQueryable().Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);
            var totalRecords = query.Count();
            var pagesCount = (int)Math.Ceiling((double)totalRecords / request.PerPage);
            if (request != null)
            {
                if (request.Keyword != null)
                {
                    query = query.Where(m => m.MarkaAutomobila
                    .ToLower()
                    .Contains(request.Keyword.ToLower()));
                }
                totalRecords = query.Count();
                var response = new PageResponse<MarkaDto>
                {
                    CurrentPage = request.PageNumber,
                    TotalCount = totalRecords,
                    PagesCount = pagesCount,
                    Data = query.Select(m => new MarkaDto
                    {
                        Id = m.Id,
                        Marka = m.MarkaAutomobila,
                        DateCreated = m.DateCreated,
                        DateModified = m.DateModified
                    })
                };

                return response;
            }
            else
            {
                return new PageResponse<MarkaDto>
                {
                    CurrentPage = request.PageNumber,
                    TotalCount = totalRecords,
                    PagesCount = pagesCount,
                    Data = query.Select(m => new MarkaDto
                    {
                        Id = m.Id,
                        Marka = m.MarkaAutomobila,
                        DateCreated = m.DateCreated,
                        DateModified = m.DateModified
                    })
                };
            }
        }
    }
}
