using AutoMapper;
using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Torcar.CORE.DTOs;
using Torcar.CORE.Entity;
using Torcar.CORE.Enums;
using Torcar.CORE.Service;

namespace Torcar.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICarService _carService;
        private readonly ICarMarkService _carMarkService;
        private readonly ICarModelService _carModelService;
        private readonly ICarSerialService _carSerialService;
        private readonly IMapper _mapper;
        private readonly IRentService _rentService;
        


        public AdminController(IUserService userService, ICarService carService, IMapper mapper, ICarMarkService carMarkService, ICarModelService carModelService, ICarSerialService carSerialService, IRentService rentService)
        {
            _userService = userService;
            _carService = carService;
            _mapper = mapper;
            _carMarkService = carMarkService;
            _carModelService = carModelService;
            _carSerialService = carSerialService;
            _rentService = rentService;
        }


        public async Task<IActionResult> Index()
        {
            IEnumerable<Rent> Rents = await _rentService.GetAllAsync();
            foreach (var item in Rents)
            {
                if (item.RentDateState == RentDateState.Not_Started)
                {
                    if (DateTime.Compare(item.RentRequest.RentStart, DateTime.Now) < 0)
                    {
                        item.RentDateState = RentDateState.Rented;
                    }

                }
                if (item.RentDateState == RentDateState.Rented)
                {
                    if (DateTime.Compare(item.RentRequest.RentStart, DateTime.Now) > 0)
                    {
                        item.RentDateState = RentDateState.Finished;
                        item.RentRequest.User.rentrequestwarrant = true;
                        item.RentRequest.Advert.Car.RentState = RentState.Not_Rented;
                        item.RentRequest.Advert.ActiveState = ActivityState.Active;
                       
                    }
                }
                await _rentService.UpdateAsync(item);

            }
            return View();
        }
        public async Task<IActionResult> Members()
        {
            IEnumerable<User> user = new List<User>();
            user = _userService.GetAll().Where(x => x.State == CORE.Enums.UserState.User);
            if (user != null)
            {

                IEnumerable<UserDto> userDto = _mapper.Map<IEnumerable<UserDto>>(user);
                return View(userDto);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateMember(int? Id)
        {
            if (Id!=null)
            {
                string id = Id.ToString();
                User u = _userService.FirstOrDefault(x => x.Id.ToString() == id);
                UserDto dto = _mapper.Map<UserDto>(u);
                return View(dto);
            }
            return RedirectToAction("Index");
            
        }
        [HttpPost]
        public async Task<IActionResult> ToMember(int? Id)
        {
            if (Id!=null)
            {


                string id = Id.ToString();
                User u = _userService.FirstOrDefault(x => x.Id.ToString() == id);
                if (u.rentrequestwarrant == true)
                {
                u.State = UserState.User;
                await _userService.UpdateAsync(u);
                return RedirectToAction("Workers");
                }
                if(u.rentrequestwarrant==false)
                {
                    return RedirectToAction("CustomError", "Home");
                }
            
            }
            return View();
        }
        public async Task<IActionResult> Workers()
        {
            IEnumerable<User> user = new List<User>();
            user =  _userService.GetAll().Where(x => x.State == CORE.Enums.UserState.Worker);
            IEnumerable<UserDto> WorkerDto = _mapper.Map<IEnumerable<UserDto>>(user);
            return View(WorkerDto);
        }
        [HttpPost]
        public async Task<IActionResult> ToWorker(int? Id)
        {
            if (Id != null)
            {
                string id = Id.ToString();
                User u = _userService.FirstOrDefault(x => x.Id.ToString() == id);
                u.State = UserState.Worker;
                await _userService.UpdateAsync(u);
                return RedirectToAction("Members");
            }
            return RedirectToAction("CustomError","Home");
            
        }

        [HttpGet]
        public async Task<IActionResult> AddCar()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCar(CarDto car)
        {
            if (ModelState.IsValid)
            {

                CarMark carMark = _mapper.Map<CarMark>(car.CarSerial.CarModel.CarMark);
                if (!await _carMarkService.AnyAsync(x => x.Name == carMark.Name))
                {
                    await _carMarkService.AddAsync(carMark);
                }
                CarMark tempMark = _carMarkService.FirstOrDefault(x => x.Name == carMark.Name);
                CarModel carModel = _mapper.Map<CarModel>(car.CarSerial.CarModel);
                carModel.Name = car.CarSerial.CarModel.Name;
                if (!await _carModelService.AnyAsync(x => x.Name == carModel.Name))
                {
                    await _carModelService.AddAsync(carModel);
                }
                CarModel tempModel = _carModelService.FirstOrDefault(x => x.Name == carModel.Name);
                CarSerial carSerial = _mapper.Map<CarSerial>(car.CarSerial);
                carSerial.CarModelId = tempModel.Id;
                carSerial.Name = car.CarSerial.Name;
                if (!await _carSerialService.AnyAsync(x => x.Name == carSerial.Name))
                {
                    await _carSerialService.AddAsync(carSerial);
                }
                CarSerial tempserial = _carSerialService.FirstOrDefault(x => x.Name == carSerial.Name);
                Car addcar = _mapper.Map<Car>(car);
                addcar.CarSerialId = tempserial.Id;
                await _carService.AddAsync(addcar);
                Car forimage = _carService.FirstOrDefault(x => x.Description == car.Description);
                if (car.Image != null)
                {
                    string filetype;
                    if (car.Image.FileName.ToLower().EndsWith(".jpg"))
                    {
                        filetype = ".jpg";
                    }
                    else if (car.Image.FileName.ToLower().EndsWith(".jpeg"))
                    {
                        filetype = ".jpeg";
                    }
                    else if (car.Image.FileName.ToLower().EndsWith(".png"))
                    {
                        filetype = ".png";
                    }
                    else
                    {
                        filetype = "";
                    }
                    string ImageName = $"Car_{forimage.Id}{filetype}";
                    Stream str=new FileStream($"wwwroot/Images/Cars/{ImageName}", FileMode.OpenOrCreate);
                    car.Image.CopyTo(str);
                    string ImageUrl = $"/Images/Cars/{ImageName}";
                    forimage.ImageUrl = ImageUrl;
                    await _carService.UpdateAsync(forimage);
                    str.Close();
                    str.Dispose();
                }

                return RedirectToAction("Cars","Worker");
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("AddCar", "Eksik veya Hatalı Bilgi Girdiniz.");
            }

            return View();
        }

    }
}
