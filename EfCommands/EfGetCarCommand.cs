using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetCarCommand : BaseCommand, IGetCarCommand
    {
        public EfGetCarCommand(MyDbContext context) : base(context)
        {
        }

        public AutomobilDto Execute(int request)
        {
            var query = Context.Automobili.Include(m => m.Marka)
                                          .ThenInclude(mo => mo.Modeli)
                                          .Include(t => t.Tip)
                                          .Include(k => k.Kategorija)
                                          .Include(s => s.Slike)
                                          .Include(kor => kor.Korisnik)
                                          .Include(g => g.Gorivo)
                                          .AsQueryable();
            var automobil = query.Where(x => x.Id == request).FirstOrDefault();
            if (automobil == null)
                throw new EntityNotFoundException("Automobil");

            return new AutomobilDto
            {
                Id = automobil.Id,
                Naziv = automobil.Naziv,
                Opis = automobil.Opis,
                Price = automobil.Price,
                Vlasnik = automobil.Vlasnik,
                DateCreated = automobil.DateCreated,
                Godiste = automobil.Godiste,
                Kategorija = automobil.Kategorija.Naziv,
                MarkaAutomobila = automobil.Marka.MarkaAutomobila,
                Model = automobil.Model != null ? automobil.Model.Model : "",
                Slike = automobil.Slike.Select(s => new SlikeDto
                {
                    Id = s.Id,
                    Path = s.Putanja
                }).ToList(),
                Tip = automobil.Tip.Type,
                VrstaGoriva = automobil.Gorivo.Naziv
            };
        }
    }
}
