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
    public class EfGetUsersCommand : BaseCommand, IGetUsersCommand
    {
        public EfGetUsersCommand(MyDbContext context) : base(context)
        {
        }

        public PageResponse<KorisnikDto> Execute(UserSearch request)
        {
            var query = Context.Korisnici.AsQueryable();
            var totalRecords = query.Count();
            var pagesCount = (int)Math.Ceiling((double)totalRecords / request.PerPage);
            
            if (request.Email != null)
            {
                query = query.Where(k => k.Email == request.Email);
            }
            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);
            totalRecords = query.Count();
            var response = new PageResponse<KorisnikDto>
            {
                CurrentPage = request.PageNumber,
                TotalCount = totalRecords,
                PagesCount = pagesCount,
                Data = query.Select(k => new KorisnikDto
                {
                    Id = k.Id,
                    Ime = k.Ime,
                    Prezime = k.Prezime,
                    Email = k.Email,
                    DateCreated = k.DateCreated,
                    DateModified = k.DateModified
                })
            };

            return response;
        }
    }
}
