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




        [TestCase(200)]
        public void MostHp(int expected)
        {
            var mostHp = EngineLogic.MostHps();
            Assert.That(mostHp.ToArray()[0].Hp,Is.EqualTo(230));
        }

        [Test]
        public void EngineCreate()
        {
            Assert.That(() => EngineLogic.Create(new Engine()
            {
                Hp = 0
            }), Throws.Exception);
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
            Engine jz = new Engine() { Id = 1, Name = "2jz", Hp = 200, Torqe = 300, Cylinders = 6 };
            Engine rb26 = new Engine() { Id = 2, Name = "rb26", Hp = 150, Torqe = 200, Cylinders = 6 };
            Engine azd = new Engine() { Id = 3, Name = "azd", Hp = 105, Torqe = 150, Cylinders = 4 };
            Engine hdi = new Engine() { Id = 4, Name = "hdi", Hp = 140, Torqe = 300, Cylinders = 4 };
            Engine tdci = new Engine() { Id = 5, Name = "tdci", Hp = 140, Torqe = 300, Cylinders = 4 };
            Car supra = new Car() { Id = 1, EngineId = jz.Id, Km = 300, BrandId = toyota.Id, Year = 1998, Name = "Supra" };
            Car gtr = new Car() { Id = 2, EngineId = rb26.Id, Km = 240, BrandId = nissan.Id, Year = 1998, Name = "GTR32" };
            Car bora = new Car() { Id = 3, EngineId = azd.Id, Km = 300000, BrandId = vw.Id, Year = 2001, Name = "Bora" };
            Car jumper = new Car() { Id = 4, EngineId = hdi.Id, Km = 85000, BrandId = citroen.Id, Year = 2018, Name = "Jumper" };
            Car transit = new Car() { Id = 5, EngineId = tdci.Id, Km = 60000, BrandId = ford.Id, Year = 2019, Name = "Transit" };

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
