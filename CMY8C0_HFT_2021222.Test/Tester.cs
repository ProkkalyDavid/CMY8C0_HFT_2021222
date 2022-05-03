using CMY8C0_HFT_2021222.Logic;
using CMY8C0_HFT_2021222.Models;
using CMY8C0_HFT_2021222.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMY8C0_HFT_2021222.Test
{
    [TestFixture]
    class Tester
    {
        public CarLogic CarLogic { get; set; }
        public BrandLogic BrandLogic { get; set; }
        public EngineLogic EngineLogic { get; set; }

        [SetUp]
        public void TestSetup()
        {
            Mock<IRepository<Car>> MockedCarRepo = new Mock<IRepository<Car>>();
            Mock<IRepository<Brand>> MockedBrandRepo = new Mock<IRepository<Brand>>();
            Mock<IRepository<Engine>> MockedEngineRepo = new Mock<IRepository<Engine>>();
            /*Engine jz = new Engine() { Id = 1, Name = "2jz", Hp = 200, Torqe = 300,Cylinders = 6 };
            Brand toyota = new Brand() { Id = 1, Name = "Toyota", Country = "Japan" };*/


            /*
            MockedEngineRepo.Setup(x => x.Read(It.IsAny<int>())).Returns(
                new Engine()
                {
                    Id = 1,
                    Name = "2jz",
                    Hp = 200,
                    Torqe = 300,
                    Cylinders = 6
                }); ;

            MockedBrandRepo.Setup(x => x.Read(It.IsAny<int>())).Returns(
                new Brand()
                {
                    Id = 1,
                    Name = "Toyota",
                    Country = "Japan"
                }); ;

            MockedCarRepo.Setup(x => x.Read(It.IsAny<int>())).Returns(
                new Car()
                {
                    Id = 1,
                    EngineId = jz.Id,
                    Km = 300,
                    BrandId = toyota.Id,
                    Year = 1998,
                    Name = "Supra"
                }); ;*/




            MockedCarRepo.Setup(x => x.ReadAll()).Returns(this.FakeCarObjects);
            MockedEngineRepo.Setup(x => x.ReadAll()).Returns(this.FakeEngineObjects);
            MockedBrandRepo.Setup(x => x.ReadAll()).Returns(this.FakeBrandObjects);

            this.CarLogic = new CarLogic(MockedCarRepo.Object);
            this.EngineLogic = new EngineLogic(MockedEngineRepo.Object);
            this.BrandLogic = new BrandLogic(MockedBrandRepo.Object);
        }


        [Test]
        public void CarLogicCreateTest1()
        {
            Assert.That(() => CarLogic.Create(new Car()
            {
                Km = -1
            }), Throws.Exception);
        }

        [Test]
        public void CarLogicCreateTest2()
        {
            Assert.That(() => CarLogic.Create(new Car()
            {
                Name = null
            }),Throws.Exception);
        }

        [TestCase(230)]
        public void MostHp(int expected)
        {
            var mostHp = EngineLogic.MostHps();
            Assert.That(mostHp.ToArray()[0].Hp,Is.EqualTo(expected));
        }

        [Test]
        public void EngineLogicCreate()
        {
            Assert.That(() => EngineLogic.Create(new Engine()
            {
                Hp = 0
            }), Throws.Exception);
        }

        [Test]
        public void DeleteTest()
        {
            Assert.That(() => CarLogic.Delete(1), Throws.Nothing);
        }

        [Test]
        public void DeleteTest2()
        {
            Assert.That(() => BrandLogic.Delete(1), Throws.Nothing);
        }

        [TestCase(6)]
        public void V8Test()
        {
            var cars = CarLogic.CasWithV8();
            Assert.That(cars.AsEnumerable<Car>().ToArray()[0].Id, Is.EqualTo(6));
        }


        private IQueryable<Engine> FakeEngineObjects()
        {
            Engine jz = new Engine() { Id = 1, Name = "2jz", Hp = 230, Torqe = 300, Cylinders = 6 };
            Engine rb26 = new Engine() { Id = 2, Name = "rb26", Hp = 150, Torqe = 200, Cylinders = 6 };
            Engine azd = new Engine() { Id = 3, Name = "azd", Hp = 105, Torqe = 150, Cylinders = 4 };
            Engine hdi = new Engine() { Id = 4, Name = "hdi", Hp = 140, Torqe = 300, Cylinders = 4 };
            Engine tdci = new Engine() { Id = 5, Name = "tdci", Hp = 140, Torqe = 300, Cylinders = 4 };

            List<Engine> engines = new List<Engine>();
            engines.Add(jz);
            engines.Add(rb26);
            engines.Add(azd);
            engines.Add(hdi);
            engines.Add(tdci);

            return engines.AsQueryable();
        }
        private IQueryable<Car> FakeCarObjects()
        {
            Brand toyota = new Brand() { Id = 1, Name = "Toyota", Country = "Japan" };
            Brand vw = new Brand() { Id = 2, Name = "Volswagen", Country = "Germany" };
            Brand nissan = new Brand() { Id = 3, Name = "Nissan", Country = "Japan" };
            Brand citroen = new Brand() { Id = 4, Name = "Citroen", Country = "France" };
            Brand ford = new Brand() { Id = 5, Name = "Ford", Country = "USA" };
            Brand BMW = new Brand() { Id = 6, Name = "BMW", Country = "germany" };
            Engine jz = new Engine() { Id = 1, Name = "2jz", Hp = 200, Torqe = 300, Cylinders = 6 };
            Engine rb26 = new Engine() { Id = 2, Name = "rb26", Hp = 150, Torqe = 200, Cylinders = 6 };
            Engine azd = new Engine() { Id = 3, Name = "azd", Hp = 105, Torqe = 150, Cylinders = 4 };
            Engine hdi = new Engine() { Id = 4, Name = "hdi", Hp = 140, Torqe = 300, Cylinders = 4 };
            Engine tdci = new Engine() { Id = 5, Name = "tdci", Hp = 140, Torqe = 300, Cylinders = 4 };
            Engine S63 = new Engine() { Id = 6, Name = "S63", Hp = 670, Torqe = 800, Cylinders = 8 };
            Car supra = new Car() { Id = 1, EngineId = jz.Id, Km = 300, BrandId = toyota.Id, Year = 1998, Name = "Supra" };
            Car gtr = new Car() { Id = 2, EngineId = rb26.Id, Km = 240, BrandId = nissan.Id, Year = 1998, Name = "GTR32" };
            Car bora = new Car() { Id = 3, EngineId = azd.Id, Km = 300000, BrandId = vw.Id, Year = 2001, Name = "Bora" };
            Car jumper = new Car() { Id = 4, EngineId = hdi.Id, Km = 85000, BrandId = citroen.Id, Year = 2018, Name = "Jumper" };
            Car transit = new Car() { Id = 5, EngineId = tdci.Id, Km = 60000, BrandId = ford.Id, Year = 2019, Name = "Transit" };
            Car M5 = new Car() { Id = 6, EngineId = S63.Id, Km = 2500, BrandId = BMW.Id, Year = 2020, Name = "M5 Competition" };

            List<Car> models = new List<Car>();
            models.Add(supra);
            models.Add(gtr);
            models.Add(bora);
            models.Add(jumper);
            models.Add(transit);
            return models.AsQueryable();
        }
        private IQueryable<Brand> FakeBrandObjects()
        {
            Brand toyota = new Brand() { Id = 1, Name = "Toyota", Country = "Japan" };
            Brand vw = new Brand() { Id = 2, Name = "Volswagen", Country = "Germany" };
            Brand nissan = new Brand() { Id = 3, Name = "Nissan", Country = "Japan" };
            Brand citroen = new Brand() { Id = 4, Name = "Citroen", Country = "France" };
            Brand ford = new Brand() { Id = 5, Name = "Ford", Country = "USA" };

            List<Brand> manufacturers = new List<Brand>();
            manufacturers.Add(toyota);
            manufacturers.Add(vw);
            manufacturers.Add(nissan);
            manufacturers.Add(citroen);
            manufacturers.Add(ford);


            return manufacturers.AsQueryable();
        }
    }
}
