using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Torcar.CORE.DTOs;
using Torcar.CORE.Entity;
using Torcar.CORE.Service;
using Torcar.UI.Controllers;

namespace TorCar.Test.Tests
{
    public class HomeControllerTest
    {
        private readonly Mock<IUserService> _userservicemock;
        private readonly Mock<IAdvertService> _advertServicemock;
        private readonly Mock<IMapper> _mappermock;
        private readonly Mock<ClaimsPrincipal> _principalmock;
        private readonly HomeController _controller;
        private readonly List<User> _users;
        private readonly List<UserDto> _userdtos;
        private readonly List<Advert> _adverts;
        private readonly List<AdvertDto> _advertdtos;

        public HomeControllerTest()
        {
            _userservicemock= new Mock<IUserService>();
            _advertServicemock= new Mock<IAdvertService>();
            _mappermock= new Mock<IMapper>();
            _principalmock= new Mock<ClaimsPrincipal>();
            _controller = new HomeController(_userservicemock.Object,_advertServicemock.Object,_mappermock.Object);
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
            _userdtos = new List<UserDto>()
            {
                new UserDto()
                {
                    Id=1,
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
                new UserDto
                {
                    Id=2,
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
                    rentrequestwarrant=true,
                    ConfirmCode=15364
                },
                new UserDto
                {
                    Id=3,
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
                new UserDto
                {
                    Id=4,
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
                new UserDto
                {
                    Id=5,
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
                }
            };
            _adverts = new List<Advert>
            {
                new Advert
                {
                    Id=1,
                    CreatedDate = DateTime.Now,
                    PriceOfDay=500,
                    PublishDate=DateTime.Now,
                    ActiveState=Torcar.CORE.Enums.ActivityState.Active,
                    CarId=1,
                },
                new Advert
                {
                    Id=2,
                    CreatedDate = DateTime.Now,
                    PriceOfDay=600,
                    PublishDate=DateTime.Now,
                    ActiveState=Torcar.CORE.Enums.ActivityState.Active,
                    CarId=2,
                },
                new Advert
                {
                    Id=3,
                    CreatedDate = DateTime.Now,
                    PriceOfDay=800,
                    PublishDate=DateTime.Now,
                    ActiveState=Torcar.CORE.Enums.ActivityState.Active,
                    CarId=3,
                },
            };
            _advertdtos = new List<AdvertDto>
            {
                new AdvertDto
                {
                    Id=1,
                    PriceOfDay=500,
                    PublishDate=DateTime.Now,
                    ActiveState=Torcar.CORE.Enums.ActivityState.Active,
                    CarId=1,
                },
                new AdvertDto
                {
                    Id=2,
                    PriceOfDay=600,
                    PublishDate=DateTime.Now,
                    ActiveState=Torcar.CORE.Enums.ActivityState.Active,
                    CarId=2,
                },
                new AdvertDto
                {
                    Id=3,
                    PriceOfDay=800,
                    PublishDate=DateTime.Now,
                    ActiveState=Torcar.CORE.Enums.ActivityState.Active,
                    CarId=3,
                },
            };
        }

        [Fact]
        public void  Index_ActionExecutes_ReturnView()
        {
           var result= _controller.Index();
           Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void AccessDenied_ActionExecutes_ReturnView()
        {
            
            var result = _controller.AccessDenied();
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void Adverts_ActionExecutes_ReturnView()
        {
            List<Advert> adverts= _adverts.Where(x => x.ActiveState == Torcar.CORE.Enums.ActivityState.Active).ToList();
            _advertServicemock.Setup(x => x.GetAll()).Returns(adverts);
            List<AdvertDto> advertdtos=_advertdtos.Where(x=>x.ActiveState==Torcar.CORE.Enums.ActivityState.Active).ToList();
            _mappermock.Setup(x => x.Map<IEnumerable<AdvertDto>>(It.IsAny<IEnumerable<Advert>>)).Returns(advertdtos);
            var result=_controller.Adverts();
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void CustomError_ActionExecutes_ReturnView()
        {
            var result = _controller.CustomError();

            Assert.IsType<ViewResult>(result);  
        }
    }
}
