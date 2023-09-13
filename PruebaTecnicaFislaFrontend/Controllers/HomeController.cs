using PruebaTecnicaFislaFrontend.Request;
using PruebaTecnicaFislaFrontend.Validation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaTecnicaFislaFrontend.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult IsValid(string password) {
            return Json(Validator.getValidation(password));
        }

    }
}