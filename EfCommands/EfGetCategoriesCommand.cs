using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using Application.Responses;
using Application.SearchObjects;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetCategoriesCommand : BaseCommand, IGetCategoriesCommand
    {
        public EfGetCategoriesCommand(MyDbContext context) : base(context)
        {
        }

        public PageResponse<KategorijaDto> Execute(CategorySearch request)
        {

            var query = Context.Kategorije.AsQueryable().Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);
            var totalRecords = query.Count();
            var pagesCount = (int)Math.Ceiling((double)totalRecords / request.PerPage);
            if (request != null)
            {
                if (request.Keyword != null)
                {
                    query = query.Where(m => m.Naziv
                    .ToLower()
                    .Contains(request.Keyword.ToLower()));
                }
                totalRecords = query.Count();
                var response = new PageResponse<KategorijaDto>
                {
                    CurrentPage = request.PageNumber,
                    TotalCount = totalRecords,
                    PagesCount = pagesCount,
                    Data = query.Select(cat => new KategorijaDto
                    {
                        Id = cat.Id,
                        Kategorija = cat.Naziv,
                        DateCreated = cat.DateCreated,
                        DateModified = cat.DateModified
                    })
                };

                return response;
            }
            else
            {
                return new PageResponse<KategorijaDto>
                {
                    CurrentPage = request.PageNumber,
                    TotalCount = totalRecords,
                    PagesCount = pagesCount,
                    Data = query.Select(cat => new KategorijaDto
                    {
                        Id = cat.Id,
                        Kategorija = cat.Naziv,
                        DateCreated = cat.DateCreated,
                        DateModified = cat.DateModified
                    })
                };
            }
        }
    }
}
