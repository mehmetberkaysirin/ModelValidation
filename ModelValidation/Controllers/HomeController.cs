using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelValidation.Models;

namespace ModelValidation.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("Register",new Register() { BirthDate=DateTime.Now});
        }


        [HttpPost]
        public IActionResult Register(Register model)
        {

            if (string.IsNullOrEmpty(model.USerName))
            {
                ModelState.AddModelError(nameof(model.USerName), "Zorunlu bir Alan");
            }
            if (string.IsNullOrEmpty(model.Email))
            {
                ModelState.AddModelError(nameof(model.Email), "Email Zorunlu alan.");
            }
            else
            {
                //email regular exp.
                if (!model.Email.Contains("@"))
                {
                    ModelState.AddModelError(nameof(model.Email), "Email adresi geçerli bir adres değil.");
                }
            }


            if (string.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError(nameof(model.Password), "Password Zorunlu alan.");
            }
            else
            {

                if (model.Password.Length < 6)
                {
                    ModelState.AddModelError(nameof(model.Password), "Parola min 6 karakter olmalıdır.");
                }
            }
            if (!model.TermsAccept)
            {
                ModelState.AddModelError(nameof(model.TermsAccept),"Kullanım koşullarını kabul etmelisiniz.");
            }
            if (ModelState.IsValid)
            {
                return View("Comploted", model);

            }
            else
            {
                return View(model);
            }
           
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
