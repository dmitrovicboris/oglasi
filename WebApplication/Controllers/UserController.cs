using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.DataTransfer.CreateDtos;
using Application.Exceptions;
using Application.Interfaces;
using Application.SearchObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly IGetUsersCommand _getUsersCommand;
        private readonly IGetUserCommand _getUserCommand;
        private readonly IAddNewUserCommand _addUserCommand;
        private readonly IEditUserCommand _editUserCommand;
        private readonly IDeleteUserCommand _deleteUserCommand;
        private IEmailSender _emailSender;

        public UserController(IGetUsersCommand getUsersCommand, IGetUserCommand getUserCommand, IAddNewUserCommand addUserCommand, IDeleteUserCommand deleteUserCommand, IEmailSender emailSender, IEditUserCommand editUserCommand)
        {
            _getUsersCommand = getUsersCommand;
            _getUserCommand = getUserCommand;
            _addUserCommand = addUserCommand;
            _deleteUserCommand = deleteUserCommand;
            _emailSender = emailSender;
            _editUserCommand = editUserCommand;
        }

        // GET: User
        public ActionResult Index(UserSearch search)
        {
            var users = _getUsersCommand.Execute(search);
            return View(users);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var dto = _getUserCommand.Execute(id);
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

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NapraviKorisnika korisnik)
        {
            if (!ModelState.IsValid)
            {
                TempData["greska"] = "Doslo je do greske pri unosu";
                RedirectToAction("create");
            }
            try
            {
                _addUserCommand.Execute(korisnik);
                _emailSender.Subject = "Cestitamo na <b>REGISTRACIJI!</b>";
                _emailSender.ToEmail = korisnik.Email;
                _emailSender.Body = "Uspesno ste se registrovali na nasem sajtu!";
                _emailSender.Send();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var dto = _getUserCommand.Execute(id);
                return View(dto);
            }
            catch (EntityNotFoundException ex)
            {
                TempData["error"] = ex.Message;

            }
            catch (Exception)
            {
                TempData["greska"] = "Doslo je do greske.";
            }
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NapraviKorisnika korisnik)
        {
            if (!ModelState.IsValid)
            {
                TempData["greska"] = "Doslo je do greske pri unosu";
                RedirectToAction("Edit");
            }
            try
            {
                korisnik.KorisnikId = id;
                _editUserCommand.Execute(korisnik);

                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException ex)
            {
                TempData["error"] = ex.Message;
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var dto = _getUserCommand.Execute(id);
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

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _deleteUserCommand.Execute(id);
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