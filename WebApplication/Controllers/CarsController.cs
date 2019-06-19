using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.DataTransfer.CreateDtos;
using Application.Exceptions;
using Application.SearchObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class CarsController : Controller
    {
        private readonly IGetCarsCommand _getCarsCommand;
        private readonly IGetCarCommand _getCarCommand;
        private readonly IDeleteCarCommand _deleteCarCommand;

        private readonly IGetCategoriesCommand _getCategoriesCommand;
        private readonly IGetFuelsCommand _getFuelsCommand;
        private readonly IGetBrandsCommand _getBrandsCommand;
        private readonly IGetTypesCommand _getTypesCommand;
        private readonly IGetModelsCommand _getModelsCommand;

        public CarsController(IGetCarsCommand getCarsCommand, IGetCarCommand getCarCommand, IDeleteCarCommand deleteCarCommand, IGetCategoriesCommand getCategoriesCommand, IGetFuelsCommand getFuelsCommand, IGetBrandsCommand getBrandsCommand, IGetTypesCommand getTypesCommand, IGetModelsCommand getModelsCommand)
        {
            _getCarsCommand = getCarsCommand;
            _getCarCommand = getCarCommand;
            _deleteCarCommand = deleteCarCommand;
            _getCategoriesCommand = getCategoriesCommand;
            _getFuelsCommand = getFuelsCommand;
            _getBrandsCommand = getBrandsCommand;
            _getTypesCommand = getTypesCommand;
            _getModelsCommand = getModelsCommand;
        }

        // GET: Cars
        public ActionResult Index(PretragaAutomobila search)
        {
            var cars = _getCarsCommand.Execute(search);
            return View(cars);
        }

        // GET: Cars/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var dto = _getCarCommand.Execute(id);
                return View(dto);
            }
            catch (EntityNotFoundException ex)
            {
                TempData["error"] = ex.Message;
            }
            catch (Exception e)
            {
                TempData["greska"] = "Doslo je do greske.";
            }
            return View();
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            ViewBag.Categories = _getCategoriesCommand.Execute(new CategorySearch { });
            ViewBag.Types = _getTypesCommand.Execute(new TypeSearch { });
            ViewBag.Fuels = _getFuelsCommand.Execute(new FuelSearch { });
            ViewBag.Models = _getModelsCommand.Execute(new ModelSearch { });
            ViewBag.Brands = _getBrandsCommand.Execute(new BrandSearch { });
            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NapraviNovAutomobil dto)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var dto = _getCarCommand.Execute(id);
                return View(dto);
            }
            catch (EntityNotFoundException ex)
            {
                TempData["error"] = ex.Message;
            }
            catch (Exception e)
            {
                TempData["greska"] = "Doslo je do greske.";
            }
            return View();
        }

        // POST: Cars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var dto = _getCarCommand.Execute(id);
                return View(dto);
            }
            catch (EntityNotFoundException ex)
            {
                TempData["error"] = ex.Message;
            }
            catch (Exception e)
            {
                TempData["greska"] = "Doslo je do greske.";
            }
            return View();
        }

        // POST: Cars/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _deleteCarCommand.Execute(id);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException ex)
            {
                TempData["error"] = ex.Message;
                return View();
            }
        }
    }
}