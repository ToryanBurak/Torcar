using AutoMapper;
using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Torcar.CORE.DTOs;
using Torcar.CORE.Entity;
using Torcar.CORE.Enums;
using Torcar.CORE.Service;
using Torcar.UI.Controllers;
using Xunit.Sdk;

namespace TorCar.Test.Tests
{
    public class AdminControllerTest
    {
        private readonly Mock<IUserService> _userServicemock;
        private readonly Mock<ICarService> _carServicemock;
        private readonly Mock<ICarMarkService> _carMarkServicemock;
        private readonly Mock<ICarModelService> _carModelServicemock;
        private readonly Mock<ICarSerialService> _carSerialServicemock;
        private readonly Mock<IMapper> _mappermock;
        private readonly Mock<IRentService> _rentServicemock;
        private readonly AdminController _controller;
        private readonly List<User> _users;
        private readonly List<UserDto> _userdtos;
        private readonly List<Rent> _rents;
        private readonly List<RentDto> _rentdtos;
        private readonly List<Car> _cars;
        private readonly List<CarDto> _cardtos;
        private readonly List<CarMark> _carmarks;
        private readonly List<CarMarkDto> _carmarkdtos;
        private readonly List<CarModel> _carModels;
        private readonly List<CarModelDto> _carModeldtos;
        private readonly List<CarSerial> _carSerials;
        private readonly List<CarSerialDto> _carSerialdtos;
        private readonly List<Advert> _adverts;
        private readonly List<AdvertDto> _advertdtos;
        private readonly List<RentRequest> _rentrequests;
        private readonly List<RequestDto> _rentrequestdtos;

        public AdminControllerTest()
        {
            _userServicemock = new Mock<IUserService>(MockBehavior.Loose);
            _carMarkServicemock = new Mock<ICarMarkService>(MockBehavior.Loose);
            _carMarkServicemock = new Mock<ICarMarkService>(MockBehavior.Loose);
            _carModelServicemock = new Mock<ICarModelService>(MockBehavior.Loose);
            _carSerialServicemock = new Mock<ICarSerialService>(MockBehavior.Loose);
            _mappermock = new Mock<IMapper>();
            _rentServicemock = new Mock<IRentService>();
            _carServicemock = new Mock<ICarService>();
            _controller = new AdminController(_userServicemock.Object, _carServicemock.Object, _mappermock.Object, _carMarkServicemock.Object, _carModelServicemock.Object, _carSerialServicemock.Object, _rentServicemock.Object);
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
            _carmarks = new List<CarMark>()
            {
                new CarMark
                {
                    Id=1,
                    Name="Renault",
                    CreatedDate= DateTime.Now,
                },
                new CarMark
                {
                    Id=2,
                    Name="Dacia",
                    CreatedDate= DateTime.Now,
                },
                new CarMark
                {
                    Id=3,
                    Name="Fiat",
                    CreatedDate= DateTime.Now,
                }
            };
            _carmarkdtos = new List<CarMarkDto>()
            {
                new CarMarkDto
                {
                    Id=1,
                    Name="Renault",
                },
                new CarMarkDto
                {
                    Id=2,
                    Name="Dacia",
                    
                },
                new CarMarkDto
                {
                    Id=3,
                    Name="Fiat",
                    
                }
            };
            _carModels = new List<CarModel>()
            {
                new CarModel
                {
                    Id=1,
                    Name="Clio",
                    CarMarkId=1,
                    CreatedDate= DateTime.Now,

                },
                new CarModel
                {
                    Id=2,
                    Name="Duster",
                    CarMarkId=2,
                    CreatedDate= DateTime.Now,
                },
                new CarModel
                {
                    Id=3,
                    Name="Egea",
                    CarMarkId=3,
                    CreatedDate= DateTime.Now,

                }
            };
            _carModeldtos = new List<CarModelDto>()
            {
                new CarModelDto
                {
                    Id=1,
                    Name="Clio",
                    CarMarkId=1,
                    

                },
                new CarModelDto
                {
                    Id=2,
                    Name="Duster",
                    CarMarkId=2,
                    
                },
                new CarModelDto
                {
                    Id=3,
                    Name="Egea",
                    CarMarkId=3,
                    

                }
            };
            _carSerials = new List<CarSerial>()
            {
                new CarSerial
                {
                    Id = 1,
                    Name="Touch",
                    CarModelId=1,
                    CreatedDate= DateTime.Now,
                },
                new CarSerial
                {
                    Id=2,
                    Name="DusterSeri",
                    CarModelId=2,
                    CreatedDate= DateTime.Now,
                },
                new CarSerial
                {
                    Id=3,
                    Name="Urban",
                    CarModelId=3,
                    CreatedDate= DateTime.Now,
                }
            };
            _carSerialdtos = new List<CarSerialDto>()
            {
                new CarSerialDto
                {
                    Id = 1,
                    Name="Touch",
                    CarModelId=1,
                    
                },
                new CarSerialDto
                {
                    Id=2,
                    Name="DusterSeri",
                    CarModelId=2,
                   
                },
                new CarSerialDto
                {
                    Id=3,
                    Name="Urban",
                    CarModelId=3,
                    
                }
            };
            _cars = new List<Car>()
            {
                new Car
                {
                    Id=1,
                    CreatedDate = DateTime.Now,
                    Description="Güzel",
                    CarSerialId=1,
                    Year="2023",
                    Fuel=Torcar.CORE.Enums.Fuel.Dizel,
                    Gear=Torcar.CORE.Enums.Gear.Manuel,
                    KM="1000",
                    Case=Torcar.CORE.Enums.CaseType.Hatcback,
                    HP=120,
                    CC=1500,
                    Color=Torcar.CORE.Enums.Color.Beyaz,
                    Image=null,
                    ImageUrl=null,
                    ActiveState=Torcar.CORE.Enums.ActivityState.Active,
                    RentState=Torcar.CORE.Enums.RentState.Not_Rented

                },
                new Car
                {
                    Id=2,
                    CreatedDate = DateTime.Now,
                    Description="Güzel2",
                    CarSerialId=2,
                    Year="2023",
                    Fuel=Torcar.CORE.Enums.Fuel.Dizel,
                    Gear=Torcar.CORE.Enums.Gear.Manuel,
                    KM="1520",
                    Case=Torcar.CORE.Enums.CaseType.Hatcback,
                    HP=130,
                    CC=1600,
                    Color=Torcar.CORE.Enums.Color.Beyaz,
                    Image=null,
                    ImageUrl=null,
                    ActiveState=Torcar.CORE.Enums.ActivityState.Active,
                    RentState=Torcar.CORE.Enums.RentState.Not_Rented

                },
                new Car
                {
                    Id=3,
                    CreatedDate = DateTime.Now,
                    Description="Güzel3",
                    CarSerialId=3,
                    Year="2023",
                    Fuel=Torcar.CORE.Enums.Fuel.Dizel,
                    Gear=Torcar.CORE.Enums.Gear.Manuel,
                    KM="50",
                    Case=Torcar.CORE.Enums.CaseType.Hatcback,
                    HP=140,
                    CC=2000,
                    Color=Torcar.CORE.Enums.Color.Mor,
                    Image=null,
                    ImageUrl=null,
                    ActiveState=Torcar.CORE.Enums.ActivityState.Active,
                    RentState=Torcar.CORE.Enums.RentState.Not_Rented

                }
            };
            _cardtos = new List<CarDto>()
            {
                new CarDto
                {
                    Id=1,
                    Description="Güzel",
                    CarSerialId=1,
                    Year="2023",
                    Fuel=Torcar.CORE.Enums.Fuel.Dizel,
                    Gear=Torcar.CORE.Enums.Gear.Manuel,
                    KM="1000",
                    Case=Torcar.CORE.Enums.CaseType.Hatcback,
                    HP=120,
                    CC=1500,
                    Color=Torcar.CORE.Enums.Color.Beyaz,
                    Image=null,
                    ImageUrl=null,
                    ActiveState=Torcar.CORE.Enums.ActivityState.Active,
                    RentState=Torcar.CORE.Enums.RentState.Not_Rented,
                    
                    

                },
                new CarDto
                {
                    Id=2,
                    Description="Güzel2",
                    CarSerialId=2,
                    Year="2023",
                    Fuel=Torcar.CORE.Enums.Fuel.Dizel,
                    Gear=Torcar.CORE.Enums.Gear.Manuel,
                    KM="1520",
                    Case=Torcar.CORE.Enums.CaseType.Hatcback,
                    HP=130,
                    CC=1600,
                    Color=Torcar.CORE.Enums.Color.Beyaz,
                    Image=null,
                    ImageUrl=null,
                    ActiveState=Torcar.CORE.Enums.ActivityState.Active,
                    RentState=Torcar.CORE.Enums.RentState.Not_Rented

                },
                new CarDto
                {
                    Id=3,
                    Description="Güzel3",
                    CarSerialId=3,
                    Year="2023",
                    Fuel=Torcar.CORE.Enums.Fuel.Dizel,
                    Gear=Torcar.CORE.Enums.Gear.Manuel,
                    KM="50",
                    Case=Torcar.CORE.Enums.CaseType.Hatcback,
                    HP=140,
                    CC=2000,
                    Color=Torcar.CORE.Enums.Color.Mor,
                    Image=null,
                    ImageUrl=null,
                    ActiveState=Torcar.CORE.Enums.ActivityState.Active,
                    RentState=Torcar.CORE.Enums.RentState.Not_Rented
                    
                    

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
            _rentrequests = new List<RentRequest>
            {
                new RentRequest
                {
                    Id = 1,
                    CreatedDate= DateTime.Now,
                    AdvertId=1,
                    UserId=3,
                    RentDay=2,
                    RentStart=DateTime.Now.AddDays(-3),
                    RentEnd=DateTime.Now.AddDays(-1),
                    ConfirmState=Torcar.CORE.Enums.ConfirmState.Success,
                    TotalPrice=1000

                },
                new RentRequest
                {
                    Id = 2,
                    CreatedDate= DateTime.Now,
                    AdvertId=2,
                    UserId=4,
                    RentDay=2,
                    RentStart=DateTime.Now.AddDays(-1),
                    RentEnd=DateTime.Now.AddDays(1),
                    ConfirmState=Torcar.CORE.Enums.ConfirmState.Success,
                    TotalPrice=1200

                },
                new RentRequest
                {
                    Id = 3,
                    CreatedDate= DateTime.Now,
                    AdvertId=3,
                    UserId=5,
                    RentDay=2,
                    RentStart=DateTime.Now.AddDays(1),
                    RentEnd=DateTime.Now.AddDays(3),
                    ConfirmState=Torcar.CORE.Enums.ConfirmState.Success,
                    TotalPrice=1600

                }
            };
            _rentrequestdtos = new List<RequestDto>
            {
                new RequestDto
                {
                    Id = 1,
                    AdvertId=1,
                    UserId=3,
                    RentDay=2,
                    RentStart=DateTime.Now.AddDays(-3),
                    RentEnd=DateTime.Now.AddDays(-1),
                    ConfirmState=Torcar.CORE.Enums.ConfirmState.Success,
                    TotalPrice=1000

                },
                new RequestDto
                {
                    Id = 2,
                    AdvertId=2,
                    UserId=4,
                    RentDay=2,
                    RentStart=DateTime.Now.AddDays(-1),
                    RentEnd=DateTime.Now.AddDays(1),
                    ConfirmState=Torcar.CORE.Enums.ConfirmState.Success,
                    TotalPrice=1200

                },
                new RequestDto
                {
                    Id = 3,
                    AdvertId=3,
                    UserId=5,
                    RentDay=2,
                    RentStart=DateTime.Now.AddDays(1),
                    RentEnd=DateTime.Now.AddDays(3),
                    ConfirmState=Torcar.CORE.Enums.ConfirmState.Success,
                    TotalPrice=1600

                }
            };
            _rents = new List<Rent>
            {
                new Rent
                {
                    Id=1,
                    CreatedDate= DateTime.Now,
                    RentRequestId=1,
                    RentDateState=Torcar.CORE.Enums.RentDateState.Finished
                },
                new Rent
                {
                    Id=2,
                    CreatedDate= DateTime.Now,
                    RentRequestId=2,
                    RentDateState=Torcar.CORE.Enums.RentDateState.Rented
                },
                new Rent
                {
                    Id=3,
                    CreatedDate= DateTime.Now,
                    RentRequestId=3,
                    RentDateState=Torcar.CORE.Enums.RentDateState.Not_Started
                }

            };
            _rentdtos = new List<RentDto>
            {
                new RentDto
                {
                    Id=1,
                    RentRequestId=1,
                    RentDateState=Torcar.CORE.Enums.RentDateState.Finished
                },
                new RentDto
                {
                    Id=2,
                    RentRequestId=2,
                    RentDateState=Torcar.CORE.Enums.RentDateState.Rented
                },
                new RentDto
                {
                    Id=3,
                    RentRequestId=3,
                    RentDateState=Torcar.CORE.Enums.RentDateState.Not_Started
                }

            };
        }

        [Fact]
        public async void Index_ActionExecutes_ReturnView()
        {
            var result =await _controller.Index();
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public async void UpdateMember_IdIsNull_RedirectToAction()
        {
            var result = await _controller.UpdateMember(null);
            var redirect=Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirect.ActionName);
        }
        [Theory]
        [InlineData(3)]
        public async Task Update_Member_IdIsNotNull_ReturnView(int id)
        {
            User u =_users.FirstOrDefault(x => x.Id == id);
            UserDto udto=_userdtos.Find(x => x.Id == id);
            var utest=  _userServicemock.Setup(x => x.FirstOrDefault(y => y.Id == id)).Returns(u);
            var udtotest=_mappermock.Setup(x => x.Map<UserDto>(u)).Returns(udto);
            var result= await _controller.UpdateMember(id);
            var ViewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(u.Id,udto.Id);
        }
        [Fact]
        public async Task ToMember_IdIsNull_ReturnView()
        {
            var result = await _controller.ToMember(null);
            Assert.IsType<ViewResult>(result);
        }
        [Theory]
        [InlineData(2)]
        public async Task ToMember_IdIsNotNull_NotNullUser(int id)
        {
            User u=_users.FirstOrDefault(x => x.Id==id);
            var utest = _userServicemock.Setup(x => x.FirstOrDefault(y => y.Id == id)).Returns(u);
            Assert.NotNull(utest);

        }
        [Theory]
        [InlineData(2)]
        public async Task ToMember_IdIsNotNullAndWarrantTrue_RedirectToWorkers(int id)
        {
            _userServicemock.Setup(x => x.FirstOrDefault(It.IsAny<Expression<Func<User, bool>>>()))
                    .Returns((Expression<Func<User, bool>> predicate) => _users.FirstOrDefault(predicate.Compile()));
            var result = await _controller.ToMember(id);
            var Redirect=Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Workers", Redirect.ActionName);
        }
        [Theory]
        [InlineData(6)]
        public async Task ToMember_IdIsNotNullAndWarrantFalse_RedirectToCustomError(int id)
        {
            _userServicemock.Setup(x => x.FirstOrDefault(It.IsAny<Expression<Func<User, bool>>>()))
                    .Returns((Expression<Func<User, bool>> predicate) => _users.FirstOrDefault(predicate.Compile()));
            var result=await _controller.ToMember(id);
            var redirect=Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("CustomError", redirect.ActionName);
        }
        [Fact]
        public async Task ToWorker_IdIsNull_ReturnRedirectToCustomError()
        {
            var result= await _controller.ToWorker(null);
            var redirect= Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("CustomError", redirect.ActionName);
        }
        [Theory]
        [InlineData(3)]
        public async Task ToWorker_IdIsNotNull_ReturnRedirectToMembers(int id)
        {
            _userServicemock.Setup(x => x.FirstOrDefault(It.IsAny<Expression<Func<User, bool>>>()))
                   .Returns((Expression<Func<User, bool>> predicate) => _users.FirstOrDefault(predicate.Compile()));
            var result=await _controller.ToWorker(id);
            var redirect=Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Members",redirect.ActionName);
        }

        [Fact]
        public async Task AddCar_ActionExecutes_ReturnView()
        {
            var result =await _controller.AddCar();
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public async Task AddCarPost_CarInValid_ReturnView()
        {
            _controller.ModelState.AddModelError("AddCar", "Eksik veya Hatalı Bilgi Girdiniz.");
            var result=await _controller.AddCar(_cardtos.First());
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public async Task AddCarPost_CarValid_ReturnRedirectToCars()
        {
            CarDto carDto = _cardtos.First();
            carDto.CarSerial = _carSerialdtos.First();
            carDto.CarSerial.CarModel = _carModeldtos.First();
            carDto.CarSerial.CarModel.CarMark = _carmarkdtos.First();
            _mappermock.Setup(x => x.Map<CarMark>(It.IsAny<CarMarkDto>())).Returns(_carmarks.First());
            _mappermock.Setup(x => x.Map<CarModel>(It.IsAny<CarModelDto>())).Returns(_carModels.First());
            _mappermock.Setup(x => x.Map<CarSerial>(It.IsAny<CarSerialDto>())).Returns(_carSerials.First());
            _carModelServicemock.Setup(x => x.FirstOrDefault(It.IsAny<Expression<Func<CarModel, bool>>>()))
                   .Returns((Expression<Func<CarModel, bool>> predicate) => _carModels.FirstOrDefault(predicate.Compile()));
            _mappermock.Setup(x => x.Map<Car>(It.IsAny<CarDto>())).Returns(_cars.First());
            _carSerialServicemock.Setup(x => x.FirstOrDefault(It.IsAny<Expression<Func<CarSerial, bool>>>()))
                   .Returns((Expression<Func<CarSerial, bool>> predicate) => _carSerials.FirstOrDefault(predicate.Compile()));
            var result = await _controller.AddCar(carDto);
            Assert.IsType<RedirectToActionResult>(result);
        }
        [Fact]
        public void AddCarPost_CarValidAndMarkNameNotUnique_NeverAddExecute()
        {
            CarDto carDto = _cardtos.First();
            carDto.CarSerial = _carSerialdtos.First();
            carDto.CarSerial.CarModel = _carModeldtos.First();
            carDto.CarSerial.CarModel.CarMark = _carmarkdtos.First();
            CarMark mark = _carmarks.First();
            Assert.True(_carmarks.Any(x => x.Name == mark.Name));
            var result = _controller.AddCar(carDto);
            _carMarkServicemock.Verify(x => x.AddAsync(mark), Times.Never());
        }
        





    }
}
