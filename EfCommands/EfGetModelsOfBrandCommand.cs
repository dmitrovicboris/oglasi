using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
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
    public class EfGetModelsOfBrandCommand : BaseCommand, IGetModelsOfBrandCommand
    {
        public EfGetModelsOfBrandCommand(MyDbContext context) : base(context)
        {
        }

        public PageResponse<ModelDto> Execute(int brandId)
        {
            var models = Context.Modeli.AsQueryable();
            models = models.Where(x => x.MarkaId == brandId);
            var totalRecords = models.Count();
            var pagesCount = (int)Math.Ceiling((double)totalRecords / 4);
            if (models == null)
            {
                throw new EntityNotFoundException("Model");
            }

            return new PageResponse<ModelDto> {
                CurrentPage = 1,
                PagesCount = pagesCount,
                TotalCount = totalRecords,
                Data = models.Select(mo => new ModelDto
                {
                    DateCreated = mo.DateCreated,
                    Id = mo.Id,
                    Model = mo.Model
                })
            };
        }
    }
}
