using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Torcar.CORE.DTOs;
using Torcar.CORE.Entity;
using Torcar.CORE.Enums;
using Torcar.CORE.Service;
using Torcar.UI.Models;

namespace Torcar.UI.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IUserService _userservice;
        private readonly IAdvertService _advertService;
        private readonly IMapper _mapper;


        public HomeController( IUserService userservice, IAdvertService advertService, IMapper mapper)
        {
            _userservice = userservice;
            _advertService = advertService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult Adverts()
        {
            IEnumerable<Advert> adverts=_advertService.GetAll().Where(X=>X.ActiveState==ActivityState.Active).ToList();
            IEnumerable<AdvertDto> _adverts=_mapper.Map<IEnumerable<AdvertDto>>(adverts);
            return View(_adverts);
        }
        //public IActionResult Email()
        //{
        //    string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    User u = _userservice.FirstOrDefault(x => x.Id == Convert.ToInt32(id));
        //    int confirmcode = u.ConfirmCode;
        //    return View(confirmcode);
        //}
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult CustomError()
        {
            return View();
        }
        
    }
}