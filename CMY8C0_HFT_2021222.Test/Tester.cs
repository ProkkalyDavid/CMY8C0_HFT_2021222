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
        CarLogic carLogic;
        BrandLogic brandLogic;
        EngineLogic engineLogic;

        [SetUp]
        public void Init()
        {
            Mock<IRepository<Brand>> mockBrandRepo = new Mock<IRepository<Brand>>();
            Mock<IRepository<Engine>> mockEngineRepo = new Mock<IRepository<Engine>>();
            Mock<IRepository<Car>> mockCarRepo = new Mock<IRepository<Car>>();

            mockBrandRepo.Setup(x => x.ReadAll()).Returns(this.FakeBrandObjects);
            mockEngineRepo.Setup(x => x.ReadAll()).Returns(this.FakeEngineObjects);
            mockCarRepo.Setup(x => x.ReadAll()).Returns(this.FakeCarObjects);

            this.brandLogic = new BrandLogic(mockBrandRepo.Object);
            this.engineLogic = new EngineLogic(mockEngineRepo.Object);
            this.carLogic = new CarLogic(mockCarRepo.Object);
        }



        [Test]
        public void CarCrateTest()
        {
            Assert.That(() => this.carLogic.Create(new Car()
            {
                Km = -1
            }),Throws.Exception);
        }

        [Test]
        public void BrandCreateTest()
        {
            Assert.That(() => this.brandLogic.Create(new Brand()
            {
                Name = null
            }), Throws.Exception);
        }

        [Test]
        public void EngineCreateTest()
        {
            Assert.That(() => this.engineLogic.Create(new Engine()
            {
                Hp = 0
            }), Throws.Exception);
        }

        [Test]
        public void CarReadTest()
        {
            Assert.That(() => this.carLogic.Read(7), Throws.Exception);
        }

        [Test]
        public void EngineUpdateTest()
        {
            Assert.That(() => this.engineLogic.Update(new Engine()
            {
                Hp = 0
            }), Throws.Exception);
        }

        [TestCase(670)]
        public void MostHp(int expected)
        {
            var mostHp = engineLogic.MostHps();
            Assert.That(mostHp.ToArray()[0].Hp, Is.EqualTo(expected));
        }


        private IQueryable<Engine> FakeEngineObjects()
        {
            Engine jz = new Engine() { Id = 1, Name = "2jz", Hp = 200, Torqe = 300, Cylinders = 6 };
            Engine rb26 = new Engine() { Id = 2, Name = "rb26", Hp = 150, Torqe = 200, Cylinders = 6 };
            Engine azd = new Engine() { Id = 3, Name = "azd", Hp = 105, Torqe = 150, Cylinders = 4 };
            Engine hdi = new Engine() { Id = 4, Name = "hdi", Hp = 140, Torqe = 300, Cylinders = 4 };
            Engine tdci = new Engine() { Id = 5, Name = "tdci", Hp = 140, Torqe = 300, Cylinders = 4 };
            Engine s63 = new Engine() { Id = 6, Name = "S63", Hp = 670, Torqe = 800, Cylinders = 8 };

            List<Engine> engines = new List<Engine>();
            engines.Add(jz);
            engines.Add(rb26);
            engines.Add(azd);
            engines.Add(hdi);
            engines.Add(tdci);
            engines.Add(s63);

            return engines.AsQueryable();
        }
        private IQueryable<Car> FakeCarObjects()
        {
            Brand toyota = new Brand() { Id = 1, Name = "Toyota", Country = "Japan" };
            Brand vw = new Brand() { Id = 2, Name = "Volswagen", Country = "Germany" };
            Brand nissan = new Brand() { Id = 3, Name = "Nissan", Country = "Japan" };
            Brand citroen = new Brand() { Id = 4, Name = "Citroen", Country = "France" };
            Brand ford = new Brand() { Id = 5, Name = "Ford", Country = "USA" };
            Brand BMW = new Brand() { Id = 6, Name = "BMW", Country = "Germany" };
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
            Car m5 = new Car() { Id = 6, EngineId = S63.Id, Km = 2500, BrandId = BMW.Id, Year = 2020, Name = "M5 Competition" };

            List<Car> cars = new List<Car>();
            cars.Add(supra);
            cars.Add(gtr);
            cars.Add(bora);
            cars.Add(jumper);
            cars.Add(transit);
            cars.Add(m5);
            return cars.AsQueryable();
        }
        private IQueryable<Brand> FakeBrandObjects()
        {
            Brand toyota = new Brand() { Id = 1, Name = "Toyota", Country = "Japan" };
            Brand vw = new Brand() { Id = 2, Name = "Volswagen", Country = "Germany" };
            Brand nissan = new Brand() { Id = 3, Name = "Nissan", Country = "Japan" };
            Brand citroen = new Brand() { Id = 4, Name = "Citroen", Country = "France" };
            Brand ford = new Brand() { Id = 5, Name = "Ford", Country = "USA" };
            Brand bmw = new Brand() { Id = 6, Name = "BMW", Country = "Germany" };

            List<Brand> brands = new List<Brand>();
            brands.Add(toyota);
            brands.Add(vw);
            brands.Add(nissan);
            brands.Add(citroen);
            brands.Add(ford);
            brands.Add(bmw);


            return brands.AsQueryable();
        }
    }
}
