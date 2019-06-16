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
    public class EfGetTypesCommand : BaseCommand, IGetTypesCommand
    {
        public EfGetTypesCommand(MyDbContext context) : base(context)
        {
        }

        public PageResponse<TypeDto> Execute(TypeSearch request)
        {
            try
            {

                var query = Context.Tipovi.AsQueryable().Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);
                var totalRecords = query.Count();
                var pagesCount = (int)Math.Ceiling((double)totalRecords / request.PerPage);
                if (request != null)
                {
                    if (request.Keyword != null)
                    {
                        query = query.Where(m => m.Type
                        .ToLower()
                        .Contains(request.Keyword.ToLower()));
                    }
                    totalRecords = query.Count();
                    var response = new PageResponse<TypeDto>
                    {
                        CurrentPage = request.PageNumber,
                        TotalCount = totalRecords,
                        PagesCount = pagesCount,
                        Data = query.Select(m => new TypeDto
                        {
                            Id = m.Id,
                            Type = m.Type,
                            DateCreated = m.DateCreated,
                            DateModified = m.DateModified
                        })
                    };

                    return response;
                }
                else
                {
                    return new PageResponse<TypeDto>
                    {
                        CurrentPage = request.PageNumber,
                        TotalCount = totalRecords,
                        PagesCount = pagesCount,
                        Data = query.Select(m => new TypeDto
                        {
                            Id = m.Id,
                            Type = m.Type,
                            DateCreated = m.DateCreated,
                            DateModified = m.DateModified
                        })
                    };
                }
            }
            catch
            {
                throw new EntityNotFoundException("Type");
            }
        }
    }
}
