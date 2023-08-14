using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using NETCore.Encrypt.Extensions;
using System.Security.Claims;
using Torcar.CORE.DTOs;
using Torcar.CORE.Entity;
using Torcar.CORE.Enums;
using Torcar.CORE.Service;
using MailKit.Net.Smtp;

namespace Torcar.UI.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _config;

        public IdentityController(IUserService userService, IMapper mapper,IWebHostEnvironment webHostEnvironment,IConfiguration config)
        {
            
            _userService = userService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _config = config;
        }

        public IActionResult Login()
        {
            UserLoginDto userLoginDto = new UserLoginDto();
            return View(userLoginDto);
        }
        [HttpPost]
        public async Task< IActionResult> Login(UserLoginDto login)
        {
            
            if (ModelState.IsValid)
            {
                string loginPassword = login.Password;
                string SaltPassword = login.Password + _config.GetValue<string>("AppSettings:MD5Salt");
                string Hashed = SaltPassword.MD5();
                User u =await _userService.FirstOrDefaultAsync(x => x.Name.ToLower() == login.UserName.ToLower() && x.Password.ToLower() == Hashed.ToLower());
                if (u == null)
                {
                    ModelState.AddModelError("", "Yanlış Bilgi Girdiniz.Kontrol Ediniz.");
                }
                if (u != null)
                {
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, u.Id.ToString()));
                    claims.Add(new Claim("Name",u.Name.ToString()));
                    claims.Add(new Claim(ClaimTypes.Role,u.State.ToString()));
                    claims.Add(new Claim(ClaimTypes.UserData, u.Verify.ToString()));
                    if (u.Verify == VerifyState.Unverified)
                    {
                        claims.Add(new Claim(ClaimTypes.Email, u.Email.ToString()));

                    }
                    ClaimsIdentity identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                   await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal);
                    if(u.Verify == VerifyState.Verified)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    if (u.Verify == VerifyState.Unverified)
                    {
                        string mail = _config.GetValue<string>("SendMailFrom:mail");
                        string Password = _config.GetValue<string>("SendMailFrom:password");
                        MimeMessage message = new MimeMessage();
                        MailboxAddress mailfrom = new MailboxAddress("Torcar",mail);
                        MailboxAddress mailto = new MailboxAddress(u.Name, u.Email);
                        message.From.Add(mailfrom);
                        message.To.Add(mailto);
                        message.Subject = "Doğrulama Kodu";
                        var Body = new BodyBuilder();
                        Body.TextBody = u.ConfirmCode.ToString();
                        message.Body = Body.ToMessageBody();
                        SmtpClient smtp = new SmtpClient();
                        smtp.Connect("smtp.gmail.com", 587, false);
                        smtp.Authenticate(mail, Password);
                        smtp.Send(message);
                        smtp.Disconnect(true);
                        return RedirectToAction("ConfirmMail", "User");
                    }
                }
            }

            return View();
        }
        public  IActionResult Register()
        {
            UserRegisterDto registerdto =new UserRegisterDto();

            return View(registerdto);
        }
        [HttpPost]
        public async Task< IActionResult> Register(UserRegisterDto register)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Eksik Bilgi Girdiniz.Kontrol ediniz.");
            }
            
            User uforname = await _userService.FirstOrDefaultAsync(x=>x.Name ==register.Name);
            User uforMail = await _userService.FirstOrDefaultAsync(x => x.Email == register.Email);
            if (uforname!=null)
            {
                ModelState.AddModelError(nameof(register.Name), "Girdiğiniz kullanıcı adı daha önceden alınmış.");
                
            }
            if (uforMail != null)
            {
                ModelState.AddModelError(nameof(register.Email), "Girdiğiniz Email daha önceden alınmış.");

            }

            if (ModelState.IsValid)
            {

                
                Random rnd=new Random();
                int confirmcode = rnd.Next(1000, 9999);
                register.ConfirmCode=confirmcode;
                string Md5Salt = _config.GetValue<string>("AppSettings:MD5Salt");
                string saltedPassword = register.Password + Md5Salt;
                string Hashed = saltedPassword.MD5();
                register.Password = Hashed;
                Torcar.CORE.Entity.User user = new User();
                user = _mapper.Map<Torcar.CORE.Entity.User>(register);
                switch (register.Gender)
                {
                    case CORE.Enums.Gender.Man: user.Gender = Gender.Man;
                        break;
                    case CORE.Enums.Gender.Woman:user.Gender = Gender.Woman;
                        break;
                }
                
                await _userService.AddAsync(user);
                return RedirectToAction("Confirm", "Identity");

            }
            return View();
        }
        public IActionResult LogOut()
        {


            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        public async Task<IActionResult> Confirm()
        {

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ForgetPasswordForMail()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPasswordForMail(ForgetPasswordDto forgetPasswordDto)
        {
            if (ModelState.IsValid)
            {
                if (await _userService.AnyAsync(x => x.Email == forgetPasswordDto.Email))
                {
                    User u=_userService.FirstOrDefault(x=>x.Email == forgetPasswordDto.Email);
                    TempData["UserId"] = u.Id;
                    return RedirectToAction("UpdatePasswordConfirmWithMail");
                }
                else
                {
                    ModelState.AddModelError("", "Email Hatalı,Lütfen Kontrol Ediniz");
                }

            }
           else
            {
                ModelState.AddModelError("", "Lütfen Email Giriniz");
                
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdatePasswordConfirmWithMail()
        {
            Random rnd = new Random();
            User u = _userService.FirstOrDefault(x => x.Id.ToString() == TempData["UserId"]);
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
        [HttpPost]
        public async Task<IActionResult> UpdatePasswordConfirmWithMail(UpdateWithMailDto updateWithMailDto)
        {
            if (ModelState.IsValid)
            {
                updateWithMailDto.CodeToUser = Convert.ToInt32(TempData["code"]);
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
            if (ModelState.IsValid)
            {
                string NewPassword = updatePassworddto.Password;
                string NewPasswordSalt = NewPassword + _config.GetValue<string>("AppSettings:MD5Salt");
                string NewPasswordMD5 = NewPasswordSalt.MD5();
                User u = _userService.FirstOrDefault(x => x.Id.ToString() == TempData["UserId"]);
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
        public async Task<IActionResult> Success()
        {
            return View();
        }
    }
}
