using Bono.ToDo.Web.Razor.Models;
//using Bono.ToDo.Web.Razor.HttpClients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Bono.ToDo.Web.Razor.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        //private readonly TaskToDoApiClient _api;

        //public HomeController(TaskToDoApiClient api)
        //{
        //    _api = api;
        //}

        public async Task<IActionResult> Index()
        {

            //mas como recuperar?


            //problema é que não tenho a propriedade HttpContext na classe LivroApiClient. E agora?

            return View();


        }
    }
}