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
    public class EfGetCarsCommand : BaseCommand, IGetCarsCommand
    {
        public EfGetCarsCommand(MyDbContext context) : base(context)
        {
        }

        public PageResponse<AutomobilDto> Execute(PretragaAutomobila request)
        {
            var query = Context.Automobili.Include(m => m.Marka)
                                          .ThenInclude(mo => mo.Modeli)
                                          .Include(t => t.Tip)
                                          .Include(k => k.Kategorija)
                                          .Include(s => s.Slike)
                                          .Include(kor => kor.Korisnik)
                                          .AsQueryable().Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);
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
                if (request.Marka != null)
                {
                    query = query.Where(m => m.Marka.MarkaAutomobila.ToLower()
                                                                    .Contains(request.Marka.ToLower()));
                }
                if (request.Godiste != null)
                {
                    query = query.Where(a => a.Godiste.ToString() == request.Godiste);
                }
                totalRecords = query.Count();
                var response = new PageResponse<AutomobilDto>
                {
                    CurrentPage = request.PageNumber,
                    TotalCount = totalRecords,
                    PagesCount = pagesCount,
                    Data = query.Select(a => new AutomobilDto
                    {
                        Id = a.Id,
                        Godiste = a.Godiste,
                        MarkaAutomobila = a.Marka.MarkaAutomobila,
                        Kategorija = a.Kategorija.Naziv,
                        Naziv = a.Naziv,
                        Opis = a.Opis,
                        Price = a.Price,
                        Tip = a.Tip.Type,
                        Vlasnik = a.Vlasnik,
                        VrstaGoriva = a.Gorivo.Naziv,
                        Model = a.Model.Model,
                        DateCreated = a.DateCreated,
                        DateModified = a.DateModified
                    })
                };

                return response;
            }
            else
            {
                return new PageResponse<AutomobilDto>
                {
                    CurrentPage = request.PageNumber,
                    TotalCount = totalRecords,
                    PagesCount = pagesCount,
                    Data = query.Select(a => new AutomobilDto
                    {
                        Id = a.Id,
                        Godiste = a.Godiste,
                        MarkaAutomobila = a.Marka.MarkaAutomobila,
                        Kategorija = a.Kategorija.Naziv,
                        Naziv = a.Naziv,
                        Opis = a.Opis,
                        Price = a.Price,
                        Tip = a.Tip.Type,
                        Vlasnik = a.Vlasnik,
                        VrstaGoriva = a.Gorivo.Naziv,
                        Model = a.Model.Model,
                        DateCreated = a.DateCreated,
                        DateModified = a.DateModified,
                        Slike = a.Slike.Select(s => new SlikeDto
                        {
                            Id = s.Id,
                            Path = s.Putanja
                        }).ToList()
                    })
                };
            }
        }
    }
}
