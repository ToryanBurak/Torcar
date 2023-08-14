using AutoMapper;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MimeKit;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Torcar.CORE.DTOs;
using Torcar.CORE.Entity;
using Torcar.CORE.Service;
using Torcar.SERVICE.Service;
using Torcar.REPOSITORY.Migrations;
using NETCore.Encrypt.Extensions;
using Torcar.CORE.Enums;

namespace Torcar.UI.Controllers
{
    [Authorize]
    
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAdvertService _advertService;
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UserController(IUserService userService, IMapper mapper, IConfiguration config, IAdvertService advertService, IRequestService requestService, ICarService carService)
        {
            _userService = userService;
            _mapper = mapper;
            _config = config;
            _advertService = advertService;
            _requestService = requestService;
        }

        public IActionResult Home()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User u = _userService.FirstOrDefault(x => x.Id.ToString() == id);
            UserDto dto = _mapper.Map<UserDto>(u);
            return View(dto);
        }
        [HttpGet]
        public IActionResult AddRequestForDay(int Id)
        {
            Advert advert = _advertService.FirstOrDefault(x => x.Id == Id);
            User u=_userService.FirstOrDefault(x=>x.Id.ToString()==User.FindFirstValue
            (ClaimTypes.NameIdentifier));
            UserDto udto= _mapper.Map<UserDto>(u);
            AdvertDto advertDto = _mapper.Map<AdvertDto>(advert);
            RequestDto requestDto = new RequestDto();
            requestDto.Advert = advertDto;
            requestDto.User = udto;
            TempData["AdvertId"]=Id.ToString();
            return View(requestDto);
        }
        [HttpPost]
        public async Task<IActionResult> AddRequestForDay(DateTime RentStart, int RentDay)
        {
            User userforwarrant = _userService.FirstOrDefault(x => x.Id.ToString() == User.FindFirstValue(ClaimTypes.NameIdentifier.ToString()));
            if (userforwarrant.rentrequestwarrant && RentStart!=null)
            {
                Advert advert = _advertService.FirstOrDefault(x => x.Id.ToString() == TempData["AdvertId"].ToString());
                AdvertDto advertDto = _mapper.Map<AdvertDto>(advert);
                RequestDto requestDto = new RequestDto();
                requestDto.AdvertId = advert.Id;
                requestDto.UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
                requestDto.RentDay = RentDay;
                requestDto.RentStart = RentStart;
                requestDto.RentEnd = RentStart.AddDays(RentDay);
                requestDto.ConfirmState = CORE.Enums.ConfirmState.Waiting;
                requestDto.TotalPrice = RentDay * advert.PriceOfDay;
                RentRequest request = _mapper.Map<RentRequest>(requestDto);
                User u = _userService.FirstOrDefault(x => x.Id.ToString() == User.FindFirstValue(ClaimTypes.NameIdentifier.ToString()));
                u.rentrequestwarrant = false;
                await _requestService.AddAsync(request);
                await _userService.UpdateAsync(u);
                return RedirectToAction("RequestWait");
            }
            else
            {
                return RedirectToAction("AccessDenied","Home");
            }
            
        }
        [HttpGet]
        public async Task<IActionResult> AddRequestForMonth(int Id)
        {

            Advert advert = _advertService.FirstOrDefault(x => x.Id == Id);
            User u = _userService.FirstOrDefault(x => x.Id.ToString() == User.FindFirstValue
            (ClaimTypes.NameIdentifier));
            UserDto udto = _mapper.Map<UserDto>(u);
            AdvertDto advertDto = _mapper.Map<AdvertDto>(advert);
            RequestDto requestDto = new RequestDto();
            requestDto.Advert = advertDto;
            requestDto.User = udto;
            TempData["AdvertId"] = Id.ToString();
            return View(requestDto);
        }
        [HttpPost]
        public async Task<IActionResult> AddRequestForMonth(DateTime RentStart,int RentMonth)
        {
            User userforwarrant = _userService.FirstOrDefault(x => x.Id.ToString() == User.FindFirstValue(ClaimTypes.NameIdentifier.ToString()));
            if (userforwarrant.rentrequestwarrant && RentStart != null)
            {
                Advert advert = _advertService.FirstOrDefault(x => x.Id.ToString() == TempData["AdvertId"].ToString());
                AdvertDto advertDto = _mapper.Map<AdvertDto>(advert);
                RequestDto requestDto = new RequestDto();
                requestDto.AdvertId = advert.Id;
                requestDto.UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
                requestDto.RentDay = RentMonth*30;
                requestDto.RentStart = RentStart;
                requestDto.RentEnd = RentStart.AddMonths(RentMonth);
                requestDto.ConfirmState = CORE.Enums.ConfirmState.Waiting;
                requestDto.TotalPrice = requestDto.RentDay * advert.PriceOfDay;
                RentRequest request = _mapper.Map<RentRequest>(requestDto);
                User u = _userService.FirstOrDefault(x => x.Id.ToString() == User.FindFirstValue(ClaimTypes.NameIdentifier.ToString()));
                u.rentrequestwarrant = false;
                await _requestService.AddAsync(request);
                await _userService.UpdateAsync(u);
                return RedirectToAction("RequestWait");
            }
            else
            {
                return RedirectToAction("AccessDenied", "Home");
            }
        }
        public IActionResult ConfirmMail()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            UserConfirmDto userConfirmDto = new UserConfirmDto();
            User u= _userService.FirstOrDefault(x => x.Id.ToString()==id);
            
            if (u != null)
            {
                userConfirmDto.User =_mapper.Map<UserDto>(u);
                return View(userConfirmDto);
            }
           return View();
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmMail(UserConfirmDto userConfirm)
        {
            if(ModelState.IsValid) {
                
            User user = _userService.FirstOrDefault(x => x.Id.ToString() == User.FindFirstValue(ClaimTypes.NameIdentifier));
                if (userConfirm.ConfirmCode.ToString()==user.ConfirmCode.ToString())
            {
                
                user.Verify = CORE.Enums.VerifyState.Verified;
                await _userService.UpdateAsync(user);
                return RedirectToAction("Index","Home");
            }
            else
            {
                    ModelState.AddModelError("", "Hatalı Kod Girdiniz.Lütfen maili kontrol ediniz");
            }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateName(String PersonName)
        {
           if (ModelState.IsValid)
            {
                string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                User u = _userService.FirstOrDefault(x => x.Id.ToString() == id);
                u.PersonName = PersonName;
                await _userService.UpdateAsync(u);
                return RedirectToAction("Success");

            }
           return RedirectToAction("Home", "User");

        }
        [HttpPost]
        public async Task<IActionResult> UpdateSurName(String PersonSurName)
        {
            if (ModelState.IsValid)
            {
                string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                User u = _userService.FirstOrDefault(x => x.Id.ToString() == id);
                u.PersonSurname = PersonSurName;
                await _userService.UpdateAsync(u);
                return RedirectToAction("Success");

            }
            return RedirectToAction("Home", "User");

        }
        [HttpPost]
        public async Task<IActionResult> UpdateEmail(string EMail)
        {
            if (ModelState.IsValid)
            {
                string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                User u = _userService.FirstOrDefault(x => x.Id.ToString() == id);
                Random rnd = new Random();
                string confirmcode = rnd.Next(1000, 9999).ToString();
                string mail = _config.GetValue<string>("SendMailFrom:mail");
                string Password = _config.GetValue<string>("SendMailFrom:password");
                MimeMessage message = new MimeMessage();
                MailboxAddress mailfrom = new MailboxAddress("Torcar", mail);
                MailboxAddress mailto = new MailboxAddress(u.Name, EMail);
                message.From.Add(mailfrom);
                message.To.Add(mailto);
                message.Subject = "Doğrulama Kodu";
                var Body = new BodyBuilder();
                Body.TextBody = confirmcode.ToString();
                message.Body = Body.ToMessageBody();
                SmtpClient smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, false);
                smtp.Authenticate(mail, Password);
                smtp.Send(message);
                smtp.Disconnect(true);
                TempData["ConfirmMailCode"] = confirmcode;
                TempData["ConfirmMailValue"] = EMail;
                return RedirectToAction("MailForUpdateUser");
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> UpdateAge(int Age)
        {
            if (ModelState.IsValid)
            {
                string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                User u = _userService.FirstOrDefault(x => x.Id.ToString() == id);
                u.Age = Age;
                await _userService.UpdateAsync(u);
                return RedirectToAction("Success");

            }
            return RedirectToAction("Home", "User");
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePhone(String Phone)
        {
            if (ModelState.IsValid)
            {
                string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                User u = _userService.FirstOrDefault(x => x.Id.ToString() == id);
                u.Phone = Phone;
                await _userService.UpdateAsync(u);
                return RedirectToAction("Success");

            }
            return RedirectToAction("Home", "User");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTC(String TC)
        {
            if (ModelState.IsValid)
            {
                string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                User u = _userService.FirstOrDefault(x => x.Id.ToString() == id);
                u.TC = TC;
                await _userService.UpdateAsync(u);
                return RedirectToAction("Success");

            }
            return RedirectToAction("Home", "User");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAddress(String Address)
        {
            if (ModelState.IsValid)
            {
                string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                User u = _userService.FirstOrDefault(x => x.Id.ToString() == id);
                u.Adress = Address;
                await _userService.UpdateAsync(u);
                return RedirectToAction("Success");

            }
            return RedirectToAction("Home", "User");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateImage(IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                User u=_userService.FirstOrDefault(x=>x.Id.ToString() == id);
                string filetype;
                if (ImageFile.FileName.ToLower().EndsWith(".jpg"))
                {
                    filetype = ".jpg";
                }
                else if (ImageFile.FileName.ToLower().EndsWith(".jpeg"))
                {
                    filetype = ".jpeg";
                }
                else if (ImageFile.FileName.ToLower().EndsWith(".png"))
                {
                    filetype = ".png";
                }
                else
                {
                    filetype = "";
                }
                string ImageName = $"User_{id}{filetype}";
                Stream str = new FileStream($"wwwroot/Images/Users/{ImageName}",FileMode.OpenOrCreate);
                ImageFile.CopyTo(str);
                string ImageUrl = $"/Images/Users/{ImageName}";
                u.ImageUrl = ImageUrl;
                str.Close();
                str.Dispose();
                await _userService.UpdateAsync(u);
                return RedirectToAction("Success");


            }
            return RedirectToAction("Home","User");
        }
         
        [HttpGet]
        public async Task<IActionResult> MailForUpdateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> MailForUpdateUser(String UpdateMailcode)
        {
            if (UpdateMailcode == TempData["ConfirmMailCode"].ToString())
            {
                string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                User u = _userService.FirstOrDefault(x => x.Id.ToString() == id);
                u.Email = TempData["ConfirmMailValue"].ToString();
                await _userService.UpdateAsync(u);
                return RedirectToAction("Success");
            }
            return RedirectToAction("Home", "User");


        }
        [HttpGet]
        public async Task<IActionResult> RequestWait()
        {
            return View();
        }
        public async Task<IActionResult> Success()
        {
            return View();
        }
        public async Task<IActionResult> DeleteUserFail()
        {
            return View();
        }
        public async Task<IActionResult> DeleteUserFailRented()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdatePasswordConfirmWithEmail(int Id)
        {
            Random rnd=new Random();
            User u = _userService.FirstOrDefault(x => x.Id.ToString() == User.FindFirstValue(ClaimTypes.NameIdentifier));
            int confirmCode = rnd.Next(10000, 99999);
            TempData["code"]=confirmCode;
            string mail = _config.GetValue<string>("SendMailFrom:mail");
            string Password = _config.GetValue<string>("SendMailFrom:password");
            MimeMessage message = new MimeMessage();
            MailboxAddress mailfrom = new MailboxAddress("Torcar", mail);
            MailboxAddress mailto = new MailboxAddress(u.Name, u.Email);
            message.From.Add(mailfrom);
            message.To.Add(mailto);
            message.Subject = "Doğrulama Kodu";
            var Body = new BodyBuilder();
            Body.TextBody = confirmCode.ToString();
            message.Body = Body.ToMessageBody();
            SmtpClient smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, false);
            smtp.Authenticate(mail, Password);
            smtp.Send(message);
            smtp.Disconnect(true);
            UpdateWithMailDto updateWithMailDto = new UpdateWithMailDto();
            updateWithMailDto.CodeToUser = confirmCode;
            return View(updateWithMailDto);
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePasswordConfirmWithEmail(UpdateWithMailDto updateWithMailDto)
        {
            if (ModelState.IsValid)
            {
                updateWithMailDto.CodeToUser =Convert.ToInt32(TempData["code"]);
                if (updateWithMailDto.CodeToUser == updateWithMailDto.CodeFromUser)
                {
                    return RedirectToAction("UpdatePassword");
                }
            }
            else
            {
                 ModelState.AddModelError("", "Doğrulama kodunu yanlış girdiniz.Kontrol Ediniz.");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdatePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordDto updatePassworddto)
        {
            if(ModelState.IsValid)
            {
                string NewPassword = updatePassworddto.Password;
                string NewPasswordSalt = NewPassword + _config.GetValue<string>("AppSettings:MD5Salt");
                string NewPasswordMD5 = NewPasswordSalt.MD5();
                User u = _userService.FirstOrDefault(x => x.Id.ToString() == User.FindFirstValue(ClaimTypes.NameIdentifier));
                u.Password = NewPasswordMD5;
                await _userService.UpdateAsync(u);
                return RedirectToAction("Success");
            }
            else
            {
                ModelState.AddModelError("", "Girdiğiniz Bilgiler Uyuşmuyor");
            }
            
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteUserConfirmWithMail(int Id)
        {
            if (User.FindFirstValue(ClaimTypes.Role) == "User")
            {
                User user = _userService.FirstOrDefault(x => x.Id.ToString() == User.FindFirstValue(ClaimTypes.NameIdentifier));
                if (user.rentrequestwarrant == true)
                {
                    Random rnd = new Random();
                    User u = _userService.FirstOrDefault(x => x.Id.ToString() == User.FindFirstValue(ClaimTypes.NameIdentifier));
                    int confirmCode = rnd.Next(10000, 99999);
                    TempData["code"] = confirmCode;
                    string mail = _config.GetValue<string>("SendMailFrom:mail");
                    string Password = _config.GetValue<string>("SendMailFrom:password");
                    MimeMessage message = new MimeMessage();
                    MailboxAddress mailfrom = new MailboxAddress("Torcar", mail);
                    MailboxAddress mailto = new MailboxAddress(u.Name, u.Email);
                    message.From.Add(mailfrom);
                    message.To.Add(mailto);
                    message.Subject = "Doğrulama Kodu";
                    var Body = new BodyBuilder();
                    Body.TextBody = confirmCode.ToString();
                    message.Body = Body.ToMessageBody();
                    SmtpClient smtp = new SmtpClient();
                    smtp.Connect("smtp.gmail.com", 587, false);
                    smtp.Authenticate(mail, Password);
                    smtp.Send(message);
                    smtp.Disconnect(true);
                    UpdateWithMailDto updateWithMailDto = new UpdateWithMailDto();
                    updateWithMailDto.CodeToUser = confirmCode;
                    return View(updateWithMailDto);
                }
                else
                {
                    return RedirectToAction("DeleteUserFailRented");
                }
                
            }
            else
            {
                return RedirectToAction("DeleteUserFail");
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUserConfirmWithMail(UpdateWithMailDto updateWithMailDto)
        {
            if (ModelState.IsValid)
            {
                updateWithMailDto.CodeToUser = Convert.ToInt32(TempData["code"]);
                if (updateWithMailDto.CodeToUser == updateWithMailDto.CodeFromUser)
                {
                    return RedirectToAction("DeleteUser");
                }
            }
            else
            {
                ModelState.AddModelError("", "Doğrulama kodunu yanlış girdiniz.Kontrol Ediniz.");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteUser()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            User u = _userService.FirstOrDefault(x => x.Id.ToString() == User.FindFirstValue(ClaimTypes.NameIdentifier));
            u.ObjectState = CORE.Enums.ObjectState.Deleted;
            u.DeletedDate = DateTime.Now;
            await _userService.UpdateAsync(u);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Identity");
        }
       



    }
}
