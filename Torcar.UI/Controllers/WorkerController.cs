using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Torcar.CORE.DTOs;
using Torcar.CORE.Entity;
using Torcar.CORE.Enums;
using Torcar.CORE.Service;

namespace Torcar.UI.Controllers
{
    [Authorize(Roles = "Admin,Worker")]
    public class WorkerController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICarService _carService;
        private readonly ICarMarkService _carMarkService;
        private readonly ICarModelService _carModelService;
        private readonly ICarSerialService _carSerialService;
        private readonly IAdvertService _advertService;
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;
        private readonly IRentService _rentService;

        public WorkerController(IUserService userService, ICarService carService, ICarMarkService carMarkService, ICarModelService carModelService, ICarSerialService carSerialService, IAdvertService advertService, IRequestService requestService, IMapper mapper, IRentService rentService)
        {
            _userService = userService;
            _carService = carService;
            _carMarkService = carMarkService;
            _carModelService = carModelService;
            _carSerialService = carSerialService;
            _advertService = advertService;
            _requestService = requestService;
            _mapper = mapper;
            _rentService = rentService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Cars()
        {
            IEnumerable<Car> cars = new List<Car>();
            cars = await _carService.GetAllAsync();
            IEnumerable<CarDto> CarDtos = _mapper.Map<IEnumerable<CarDto>>(cars);

            return View(CarDtos);
        }
        public async Task<IActionResult> UpdateCar(int Id)
        {
            Car carupdate = _carService.FirstOrDefault(x => x.Id == Id);
            CarDto cardto = _mapper.Map<CarDto>(carupdate);
            TempData["CarId"] = Id;
            return View(cardto);
        }
        [HttpPost]
        public async Task<IActionResult> CarMarkUpdate(string Mark)
        {
            if (ModelState.IsValid)
            {
                Car c = _carService.FirstOrDefault(x => x.Id.ToString() == TempData["CarId"]);
                c.CarSerial.CarModel.CarMark.Name = Mark;
                await _carService.UpdateAsync(c);
                return RedirectToAction("Success");
            }
            return RedirectToAction("UpdateCar", "User", TempData["CarId"]);

        }
        [HttpPost]
        public async Task<IActionResult> CarModelUpdate(string Model)
        {
            if (ModelState.IsValid)
            {
                Car c = _carService.FirstOrDefault(x => x.Id.ToString() == TempData["CarId"]);
                c.CarSerial.CarModel.Name = Model;
                await _carService.UpdateAsync(c);
                return RedirectToAction("Success");
            }
            return RedirectToAction("UpdateCar", "User", TempData["CarId"]);

        }
        [HttpPost]
        public async Task<IActionResult> CarSerialUpdate(string Serial)
        {
            if (ModelState.IsValid)
            {
                Car c = _carService.FirstOrDefault(x => x.Id.ToString() == TempData["CarId"]);
                c.CarSerial.Name = Serial;
                await _carService.UpdateAsync(c);
                return RedirectToAction("Success");
            }
            return RedirectToAction("UpdateCar", "User");
        }
        [HttpPost]
        public async Task<IActionResult> CarDescUpdate(string Description)
        {
            if (ModelState.IsValid)
            {
                Car c = _carService.FirstOrDefault(x => x.Id.ToString() == TempData["CarId"]);
                c.Description = Description;
                await _carService.UpdateAsync(c);
                return RedirectToAction("Success");
            }
            return RedirectToAction("UpdateCar", "User");

        }
        [HttpPost]
        public async Task<IActionResult> CarYearUpdate(string Year)
        {
            if (ModelState.IsValid)
            {
                Car c = _carService.FirstOrDefault(x => x.Id.ToString() == TempData["CarId"]);
                c.Year = Year;
                await _carService.UpdateAsync(c);
                return RedirectToAction("Success");
            }
            return RedirectToAction("UpdateCar", "User");
        }
        [HttpPost]
        public async Task<IActionResult> CarFuelUpdate(Fuel CarFuel)
        {
            if (ModelState.IsValid)
            {
                Car c = _carService.FirstOrDefault(x => x.Id.ToString() == TempData["CarId"]);
                c.Fuel = CarFuel;
                await _carService.UpdateAsync(c);
                return RedirectToAction("Success");
            }
            return RedirectToAction("UpdateCar", "User");

        }
        [HttpPost]
        public async Task<IActionResult> CarGearUpdate(Gear CarGear)
        {
            if (ModelState.IsValid)
            {
                Car c = _carService.FirstOrDefault(x => x.Id.ToString() == TempData["CarId"]);
                c.Gear = CarGear;
                await _carService.UpdateAsync(c);
                return RedirectToAction("Success");
            }
            return RedirectToAction("UpdateCar", "User");

        }
        [HttpPost]
        public async Task<IActionResult> CarKmUpdate(string KM)
        {
            if (ModelState.IsValid)
            {
                Car c = _carService.FirstOrDefault(x => x.Id.ToString() == TempData["CarId"]);
                c.KM = KM;
                await _carService.UpdateAsync(c);
                return RedirectToAction("Success");
            }
            return RedirectToAction("UpdateCar", "User");
        }
        [HttpPost]
        public async Task<IActionResult> CarCaseUpdate(CaseType CarCase)
        {
            if (ModelState.IsValid)
            {
                Car c = _carService.FirstOrDefault(x => x.Id.ToString() == TempData["CarId"]);
                c.Case = CarCase;
                await _carService.UpdateAsync(c);
                return RedirectToAction("Success");

            }
            return RedirectToAction("UpdateCar", "User");
        }
        [HttpPost]
        public async Task<IActionResult> CarHpUpdate(int HP)
        {
            if (ModelState.IsValid)
            {
                Car c = _carService.FirstOrDefault(x => x.Id.ToString() == TempData["CarId"]);
                c.HP = HP;
                await _carService.UpdateAsync(c);
                return RedirectToAction("Success");
            }

            return RedirectToAction("UpdateCar", "User");
        }
        [HttpPost]
        public async Task<IActionResult> CarCcUpdate(double CC)
        {
            if (ModelState.IsValid)
            {
                Car c = _carService.FirstOrDefault(x => x.Id.ToString() == TempData["CarId"]);
                c.CC = CC;
                await _carService.UpdateAsync(c);
                return RedirectToAction("Success");
            }
            return RedirectToAction("UpdateCar", "User");
        }
        [HttpPost]
        public async Task<IActionResult> CarColorUpdate(Color Color)
        {
            if (ModelState.IsValid)
            {
                Car c = _carService.FirstOrDefault(x => x.Id.ToString() == TempData["CarId"]);
                c.Color = Color;
                await _carService.UpdateAsync(c);
                return RedirectToAction("Success");
            }
            return RedirectToAction("UpdateCar", "User");
        }
        public async Task<IActionResult> Adverts()
        {
            IEnumerable<Advert> adverts = await _advertService.GetAllAsync();
            IEnumerable<AdvertDto> advertDto = _mapper.Map<IEnumerable<AdvertDto>>(adverts);
            return View(advertDto);
        }
        [HttpGet]
        public async Task<IActionResult> AddAdvertCheckCar()
        {
            IEnumerable<Car> cars = _carService.GetAll().Where(x => x.ActiveState == ActivityState.Active).ToList();
            IEnumerable<CarDto> cardtos = _mapper.Map<IEnumerable<CarDto>>(cars).ToList();
            return View(cardtos);
        }
        [HttpGet]
        public async Task<IActionResult> AddAdvert(int Id)
        {
            if (ModelState.IsValid)
            {
                Car car = _carService.FirstOrDefault(x => x.Id == Id);
                CarDto carDto = _mapper.Map<CarDto>(car);
                AdvertDto advertDto = new AdvertDto();
                advertDto.Car = carDto;
                TempData["IdForCarAdvert"] = Id.ToString();
                return View(advertDto);

            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAdvert(AdvertDto advertDto)
        {

            string carid = TempData["IdForCarAdvert"].ToString();
            Car car = _carService.FirstOrDefault(X => X.Id.ToString() == carid);
            car.ActiveState = ActivityState.Inactive;
            Advert addAdvert = _mapper.Map<Advert>(advertDto);
            addAdvert.CarId = Convert.ToInt32(carid);
            addAdvert.PublishDate = DateTime.Now;
            addAdvert.ActiveState = ActivityState.Active;
            await _advertService.AddAsync(addAdvert);
            await _carService.UpdateAsync(car);
            return RedirectToAction("Adverts");
        }
        [HttpPost]
        public async Task<IActionResult> InactiveAdvert(int Id)
        {
            Advert advert = _advertService.FirstOrDefault(x => x.Id == Id);
            advert.ActiveState = ActivityState.Inactive;
            await _advertService.UpdateAsync(advert);
            return RedirectToAction("Adverts");
        }
        [HttpPost]
        public async Task<IActionResult> ActiveAdvert(int Id)
        {
            Advert advert = _advertService.FirstOrDefault(x => x.Id == Id);
            advert.ActiveState = ActivityState.Active;
            await _advertService.UpdateAsync(advert);
            return RedirectToAction("Adverts");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAdvert(int Id)
        {
            Advert _Advert = _advertService.FirstOrDefault(x => x.Id == Id);
            AdvertDto _advertDto = _mapper.Map<AdvertDto>(_Advert);
            TempData["AdvertId"] = Id.ToString();
            return View(_advertDto);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAdvert(AdvertDto Advert, int Price)
        {
            Advert _advert = _advertService.FirstOrDefault(x => x.Id.ToString() == TempData["AdvertId"]);
            _advert.PriceOfDay = Price;
            await _advertService.UpdateAsync(_advert);
            return RedirectToAction("Adverts");
        }
        public async Task<IActionResult> Requests()
        {
            IEnumerable<RentRequest> requests = new List<RentRequest>();
            requests = await _requestService.GetAllAsync();
            IEnumerable<RequestDto> requestDto = _mapper.Map<IEnumerable<RequestDto>>(requests);
            return View(requestDto);
        }
        [HttpPost]
        public async Task<IActionResult> RequestSuccess(int Id)
        {
            RentRequest request = _requestService.FirstOrDefault(x => x.Id == Id);
            request.ConfirmState = ConfirmState.Success;
            Car car = request.Advert.Car;
            car.RentState = RentState.Rented;
            await _requestService.UpdateAsync(request);
            await _carService.UpdateAsync(car);
            Rent addrent = new Rent();
            addrent.RentRequestId = Id;
            await _rentService.AddAsync(addrent);
            return RedirectToAction("Requests");
        }
        [HttpPost]
        public async Task<IActionResult> RequestFail(int Id)
        {
            return View();
        }
        public async Task<IActionResult> Rents()
        {
            IEnumerable<Rent> rents = await _rentService.GetAllAsync();
            IEnumerable<RentDto> rentDtos = _mapper.Map<IEnumerable<RentDto>>(rents);

            return View(rentDtos);
        }
    }
}
