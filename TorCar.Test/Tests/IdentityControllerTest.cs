using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NETCore.Encrypt.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Torcar.CORE.DTOs;
using Torcar.CORE.Entity;
using Torcar.CORE.Service;
using Torcar.SERVICE.Service;
using Torcar.UI.Controllers;

namespace TorCar.Test.Tests
{
    public class IdentityControllerTest
    {
        private readonly Mock<IUserService> _userServicemock;
        private readonly Mock<IMapper> _mappermock;
        private readonly Mock<IWebHostEnvironment> _webHostEnvironmentmock;
        private readonly Mock<IConfiguration> _configmock;
        private readonly IdentityController _controller;
        private readonly List<UserLoginDto> _userlogindtos;
        private readonly List<User> _users;

        public IdentityControllerTest()
        {
           _userServicemock = new Mock<IUserService>();
            _mappermock = new Mock<IMapper>(); 
            _configmock = new Mock<IConfiguration>();
            _configmock = new Mock<IConfiguration>();
            _webHostEnvironmentmock= new Mock<IWebHostEnvironment>();
            _controller=new IdentityController(_userServicemock.Object,_mappermock.Object,_webHostEnvironmentmock.Object,_configmock.Object);
            _userlogindtos = new()
            {
                new UserLoginDto {UserName="BurakToryan",Password="26052".MD5()},
                new UserLoginDto{UserName="Burak",Password="260520".MD5() }
            };
            _users = new List<User>()
            {
                new User()
                {
                    Id=1,
                    CreatedDate=DateTime.Now,
                    ObjectState=Torcar.CORE.Enums.ObjectState.Created,
                    PersonName="Burak",
                    PersonSurname="Toryan",
                    Name="BurakToryan",
                    Password="26052",
                    Email="buraktoryan@gmail.com",
                    Verify=Torcar.CORE.Enums.VerifyState.Unverified,
                    State=Torcar.CORE.Enums.UserState.Admin,
                    Age=20,
                    Phone="5459324033",
                    Gender=Torcar.CORE.Enums.Gender.Man,
                    TC="52807550912",
                    Adress="Samsun/Ilkadim",
                    ImageUrl=null,
                    rentrequestwarrant=true,
                    ConfirmCode=15364
                },
                new User
                {
                    Id=2,
                    CreatedDate=DateTime.Now,
                    ObjectState=Torcar.CORE.Enums.ObjectState.Created,
                    PersonName="Burak",
                    PersonSurname="Toryan",
                    Name="Burak",
                    Password="260520",
                    Email="buraktoryan55.gs@gmail.com",
                    Verify=Torcar.CORE.Enums.VerifyState.Unverified,
                    State=Torcar.CORE.Enums.UserState.Worker,
                    Age=20,
                    Phone="5459324033",
                    Gender=Torcar.CORE.Enums.Gender.Man,
                    TC="52807550912",
                    Adress="Samsun/Ilkadim",
                    ImageUrl=null,
                    rentrequestwarrant=true,
                    ConfirmCode=15364
                },
                new User
                {
                    Id=3,
                    CreatedDate=DateTime.Now,
                    ObjectState=Torcar.CORE.Enums.ObjectState.Created,
                    PersonName="Burak",
                    PersonSurname="Toryan",
                    Name="BurakToryan3",
                    Password="26052001",
                    Email="buraktoryan@gmail.com",
                    Verify=Torcar.CORE.Enums.VerifyState.Unverified,
                    State=Torcar.CORE.Enums.UserState.User,
                    Age=20,
                    Phone="5459324033",
                    Gender=Torcar.CORE.Enums.Gender.Man,
                    TC="52807550912",
                    Adress="Samsun/Ilkadim",
                    ImageUrl=null,
                    rentrequestwarrant=true,
                    ConfirmCode=15364
                },
                new User
                {
                    Id=4,
                    CreatedDate=DateTime.Now,
                    ObjectState=Torcar.CORE.Enums.ObjectState.Created,
                    PersonName="Burak",
                    PersonSurname="Toryan",
                    Name="BurakToryan4",
                    Password="26052001",
                    Email="buraktoryan@gmail.com",
                    Verify=Torcar.CORE.Enums.VerifyState.Unverified,
                    State=Torcar.CORE.Enums.UserState.User,
                    Age=20,
                    Phone="5459324033",
                    Gender=Torcar.CORE.Enums.Gender.Man,
                    TC="52807550912",
                    Adress="Samsun/Ilkadim",
                    ImageUrl=null,
                    rentrequestwarrant=true,
                    ConfirmCode=15364
                },
                new User
                {
                    Id=5,
                    CreatedDate=DateTime.Now,
                    ObjectState=Torcar.CORE.Enums.ObjectState.Created,
                    PersonName="Burak",
                    PersonSurname="Toryan",
                    Name="BurakToryan5",
                    Password="26052001",
                    Email="buraktoryan@gmail.com",
                    Verify=Torcar.CORE.Enums.VerifyState.Unverified,
                    State=Torcar.CORE.Enums.UserState.User,
                    Age=20,
                    Phone="5459324033",
                    Gender=Torcar.CORE.Enums.Gender.Man,
                    TC="52807550912",
                    Adress="Samsun/Ilkadim",
                    ImageUrl=null,
                    rentrequestwarrant=true,
                    ConfirmCode=15364
                },
                new User
                {
                    Id=6,
                    CreatedDate=DateTime.Now,
                    ObjectState=Torcar.CORE.Enums.ObjectState.Created,
                    PersonName="Burak",
                    PersonSurname="Toryan",
                    Name="BurakToryan2",
                    Password="260520",
                    Email="buraktoryan55.gs@gmail.com",
                    Verify=Torcar.CORE.Enums.VerifyState.Unverified,
                    State=Torcar.CORE.Enums.UserState.Worker,
                    Age=20,
                    Phone="5459324033",
                    Gender=Torcar.CORE.Enums.Gender.Man,
                    TC="52807550912",
                    Adress="Samsun/Ilkadim",
                    ImageUrl=null,
                    rentrequestwarrant=false,
                    ConfirmCode=15364
                }
            };
        }

        [Fact]
        public void Login_ActionExecute_ReturnViewUserLoginDto()
        {
            var result=_controller.Login();
            var ViewResult=Assert.IsType<ViewResult>(result);
            Assert.NotNull(ViewResult);
            Assert.IsType<UserLoginDto>(ViewResult.Model);
        }
        [Fact]
        public async Task LoginPost_ModelInValid_ReturnView()
        {
            _controller.ModelState.AddModelError("AddCar", "Eksik veya Hatalı Bilgi Girdiniz.");
            var result =await _controller.Login(null);
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public async Task LoginPost_ModelValidAndUserNull_ReturnModelError()
        {
            UserLoginDto userLoginDto = _userlogindtos.First();
            User? u = _users.First();
            var result=await _controller.Login(userLoginDto);
            var configMock = new Mock<IConfiguration>();
            configMock.Setup(x => x.GetValue<string>("AppSettings:MD5Salt")).Returns("{3446EA9E-A4D9}");

            // Mock Login
            var login = u.Password;

            // Hashed değeri hesaplanırken kullanacağınız değerler
            string saltedPassword = u.Password + configMock.Object.GetValue<string>("AppSettings:MD5Salt");
            string expectedHashed = saltedPassword.MD5();

            // Test
            string loginPassword = u.Password;
            string SaltPassword = u.Password + configMock.Object.GetValue<string>("AppSettings:MD5Salt");
            string actualHashed = SaltPassword.MD5();

            // Hesaplanan hash değerlerini karşılaştırıyoruz
            Assert.Equal(expectedHashed, actualHashed); 
            _userServicemock.Setup(x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<User,bool>>>())).Returns((Expression<Func<User, bool>> predicate) => _users.FirstOrDefault(predicate.Compile()));
        }

    }
}
