using StarWarsTFA.Domain;
using StarWarsTFA.Domain.RepositoryInterfaces;
using StarWarsTFA.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StarWarsTFA.Infrastructure.Web.Controllers
{
    public class HomeController : Controller
    {
        SWDatabase db = new SWDatabase();
        IRepository<Character> crepo = new CharacterRepository();
        // GET: Home
        public ActionResult Index()
        {
            
            return View(crepo.GetAll());
        }
    }
}