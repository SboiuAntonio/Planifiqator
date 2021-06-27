using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Planifiqator.Data;
using Planifiqator.Data.Entities;
using Planifiqator.Models;
using Planifiqator.Services;
using Planifiqator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Controllers
{
    public class AppController : Controller
    {
        private readonly IAppRepository repository;
        private readonly IUtilizatorService _userService;
        private readonly IDestinatiiService _destinatiiService;
        private readonly INotiteService _notiteService;
        private readonly IUtilizatorRecompensatService _utilizatorRecompensatService;
        private readonly IPlanificariVacanteService _planificariVacanteService;

        public AppController(IAppRepository repository, IUtilizatorService userService, IDestinatiiService destinatiiService, INotiteService notiteService, IUtilizatorRecompensatService utilizatorRecompensatService, IPlanificariVacanteService planificariVacanteService)
        {
            this.repository = repository;
            this._userService = userService;
            this._destinatiiService = destinatiiService;
            this._notiteService = notiteService;
            this._utilizatorRecompensatService = utilizatorRecompensatService;
            this._planificariVacanteService = planificariVacanteService;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
               
            }
            else
            {

            }
            return View();
        }
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Despre()
        {
            return View();
        }
        public IActionResult Contact()
        { 
            return View();
        }
        public IActionResult CautaDestinatii()
        {
            var rezultatCautaDestinatii = repository.GetAllDestinatii();
            return View(rezultatCautaDestinatii);
        }
        public IActionResult Notite()
        {
            return View();
        }
        public IActionResult Profil()
        {
            return View();
        }
        //Register si login
       

        [HttpPost("App/Register")]
        [EnableCors("AllowOrigin")]
        public IActionResult Register([FromBody]AuthenticationRequest request)
        {
            return Ok(_userService.Register(request));
        }

        [HttpPost("App/Register/GetNume")]
        public IActionResult GetNume([FromBody] String Nume)
        {
            return Ok(_userService.GetUtilizatorByNume(Nume));
        }

        [HttpPost("App/Register/GetEmail")]
        public IActionResult GetEmail([FromBody] String Email)
        {
            return Ok(_userService.GetUtilizatorByEmail(Email));
        }

        [HttpPost("App/Profil/AddRezervareVacanta")]
        public IActionResult AddRezervareVacanta([FromBody] AddVacantaRequest request)
        {
            return Ok(_planificariVacanteService.InsertPlanificareVacanta(request));
        }

        [HttpPost("App/Profil/GetPlanificare")]
        public IActionResult GetPlanificareByUtilizator([FromBody] GetVacanteByUtilizatorRequest request)
        {
            return Ok(_planificariVacanteService.GetAllVacanteByUtilizator(request));
        }

        [HttpPost("App/CautaDestinatii/GetDestinatie")]
        public IActionResult GetDestinatieById([FromBody]int Id)
        {
            return Ok(_destinatiiService.GetDestinatieById(Id));
        }

        [HttpPost("App/Login")]
        public IActionResult Login([FromBody]LoginRequest request)
        {
            return Ok(_userService.Login(request));
        }
        [HttpPost("App/Profil/Nume")]
        public IActionResult PutNume([FromBody]NumeProfilRequest request)
        {
            return Ok(_userService.UpdateNume(request));
        }
        [HttpPost("App/Profil/Email")]
        public IActionResult PutEmail([FromBody] EmailProfilRequest request)
        {
            return Ok(_userService.UpdateEmail(request));
        }
        [HttpPost("App/Profil/Parola")]
        public IActionResult PutParola([FromBody] ParolaProfilRequest request)
        {
            return Ok(_userService.UpdateParola(request));
        }
        [HttpPost("App/Profil/getMonede")]
        public IActionResult GetMonede([FromBody] GetMonedeByIdRequest request)
        {
            return Ok(_userService.GetMonedeById(request));
        }
        [HttpPost("App/CautaDestinatii/All")]
        public IActionResult GetAllDestinatii([FromBody] AllDestinatiiRequest request)
        {
            return Ok(_destinatiiService.GetAllDestinatii(request));
        }
        [HttpPost("App/CautaDestinatii/Tara")]
        public IActionResult GetAllDestinatiiByTara([FromBody] TaraDestinatiiRequest request)
        {
            return Ok(_destinatiiService.GetAllDestinatiiByTara(request));
        }
        [HttpPost("App/CautaDestinatii/Oras")]
        public IActionResult GetAllDestinatiiByOras([FromBody] OrasDestinatiiRequest request)
        {
            return Ok(_destinatiiService.GetAllDestinatiiByOras(request));
        }
        [HttpPost("App/CautaDestinatii/Regiune")]
        public IActionResult GetAllDestinatiiByRegiune([FromBody] RegiuneDestinatiiRequest request)
        {
            return Ok(_destinatiiService.GetAllDestinatiiByRegiune(request));
        }
        [HttpPost("App/CautaDestinatii/Rating")]
        public IActionResult PutRatingById([FromBody] PutRatingRequest request)
        {
            return Ok(_destinatiiService.PutRating(request));
        }
        [HttpPost("App/Notite/insert")]
        public IActionResult InsertNotita([FromBody] AddNotitaRequest request)
        {
            return Ok(_notiteService.InsertNotita(request));
        }
        [HttpPost("App/Notite/getAll")]
        public IActionResult GetAllNotite([FromBody] GetAllNotiteByUserRequest request)
        {
            return Ok(_notiteService.GetAllNotite(request));
        }
        [HttpPost("App/UtilizatorRecompensat/addMonede")]
        public IActionResult AddMonede([FromBody] AddMonedeRequest request)
        {
            return Ok(_utilizatorRecompensatService.InsertMonede(request));
        }
        [HttpPost("App/Profil/getAll")]
        public IActionResult GetAllUsers([FromBody] GetAllUsers request)
        {
            return Ok(_userService.GetAll(request));
        }
    }
}


