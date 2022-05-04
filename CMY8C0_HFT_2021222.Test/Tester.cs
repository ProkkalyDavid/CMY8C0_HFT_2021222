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
        Mock<IRepository<Brand>> mockBrandRepo = new Mock<IRepository<Brand>>();
        Mock<IRepository<Engine>> mockEngineRepo = new Mock<IRepository<Engine>>();
        Mock<IRepository<Car>> mockCarRepo = new Mock<IRepository<Car>>();

        private IQueryable<Brand> FakeBrandObjects()
        {
            Brand BMW = new Brand() { Id = 1, Name = "BMW", Country = "Germany" };
            Brand Opel = new Brand { Id = 2, Name = "Opel", Country = "France" };
            Brand Honda = new Brand { Id = 3, Name = "Honda", Country = "Japan" };
            Brand Mercedes = new Brand { Id = 4, Name = "Mercedes-Benz", Country = "Germany" };
            Brand Ford = new Brand { Id = 5, Name = "Ford", Country = "United States of Amrica" };

            List<Brand> brands = new List<Brand>();
            brands.Add(BMW);
            brands.Add(Opel);
            brands.Add(Honda);
            brands.Add(Mercedes);
            brands.Add(Ford);

            return brands.AsQueryable();
        }
        private IQueryable<Engine> FakeEngineObjects()
        {
            Engine S63 = new Engine() { Id = 1, Name = "S63", Hp = 617, Torqe = 750, Cylinders = 8 };
            Engine EB2DTS = new Engine() { Id = 2, Name = " EB2ADTD/EB2DTS", Hp = 182, Torqe = 230, Cylinders = 4 };
            Engine K20C1 = new Engine() { Id = 3, Name = "K20C1 turbocharged I4", Hp = 316, Torqe = 350, Cylinders = 4 };
            Engine OM654 = new Engine() { Id = 4, Name = "OM654 DE20 SCR", Hp = 194, Torqe = 400, Cylinders = 4 };
            Engine TDCi = new Engine() { Id = 5, Name = "Duratorq TDCi", Hp = 170, Torqe = 400, Cylinders = 4 };

            List<Engine> engines = new List<Engine>();
            engines.Add(S63);
            engines.Add(EB2DTS);
            engines.Add(K20C1);
            engines.Add(OM654);
            engines.Add(TDCi);

            return engines.AsQueryable();
        }
        private IQueryable<Car> FakeCarObjects()
        {
            Brand BMW = new Brand() { Id = 1, Name = "BMW", Country = "Germany" };
            Brand Opel = new Brand { Id = 2, Name = "Opel", Country = "France" };
            Brand Honda = new Brand { Id = 3, Name = "Honda", Country = "Japan" };
            Brand Mercedes = new Brand { Id = 4, Name = "Mercedes-Benz", Country = "Germany" };
            Brand Ford = new Brand { Id = 5, Name = "Ford", Country = "United States of Amrica" };
            Engine S63 = new Engine() { Id = 1, Name = "S63", Hp = 617, Torqe = 750, Cylinders = 8 };
            Engine EB2DTS = new Engine() { Id = 2, Name = " EB2ADTD/EB2DTS", Hp = 182, Torqe = 230, Cylinders = 4 };
            Engine K20C1 = new Engine() { Id = 3, Name = "K20C1 turbocharged I4", Hp = 316, Torqe = 350, Cylinders = 4 };
            Engine OM654 = new Engine() { Id = 4, Name = "OM654 DE20 SCR", Hp = 194, Torqe = 400, Cylinders = 4 };
            Engine TDCi = new Engine() { Id = 5, Name = "Duratorq TDCi", Hp = 170, Torqe = 400, Cylinders = 4 };
            Car X6 = new Car() { Id = 1, Name = "X6", Year = 2022, Km = 8763, BrandId = BMW.Id, EngineId = S63.Id };
            Car Mokka = new Car() { Id = 2, Name = "Mokka", Year = 2020, Km = 27504, BrandId = Opel.Id, EngineId = EB2DTS.Id };
            Car Civic = new Car() { Id = 3, Name = "Civic Type R", Year = 2021, Km = 13400, BrandId = Honda.Id, EngineId = K20C1.Id };
            Car EClass = new Car() { Id = 4, Name = "E220d", Year = 2019, Km = 58640, BrandId = Mercedes.Id, EngineId = OM654.Id };
            Car Transit = new Car() { Id = 5, Name = "Transit Custom Sport", Year = 2022, Km = 670, BrandId = Ford.Id, EngineId = TDCi.Id };

            List<Car> cars = new List<Car>();
            cars.Add(X6);
            cars.Add(Mokka);
            cars.Add(Civic);
            cars.Add(EClass);
            cars.Add(Transit);

            return cars.AsQueryable();
        }

        [SetUp]
        public void Init()
        {


            mockBrandRepo.Setup(x => x.ReadAll()).Returns(this.FakeBrandObjects);
            mockEngineRepo.Setup(x => x.ReadAll()).Returns(this.FakeEngineObjects);
            mockCarRepo.Setup(x => x.ReadAll()).Returns(this.FakeCarObjects);

            this.brandLogic = new BrandLogic(mockBrandRepo.Object);
            this.engineLogic = new EngineLogic(mockEngineRepo.Object);
            this.carLogic = new CarLogic(mockCarRepo.Object);
        }


        [Test]
        public void V8Test()
        {
            Assert.That(() => carLogic.CarsWithV8(), Throws.Nothing);
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
        public void CarsByBrands()
        {
            Assert.That(() => carLogic.CarsByBrands(), Throws.Nothing);
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
        public void HighestMileageTest()
        {
            Assert.That(() => carLogic.HighestMileage(), Throws.Nothing);
        }

        [Test]
        public void EngineUpdateTest()
        {
            Assert.That(() => this.engineLogic.Update(new Engine()
            {
                Hp = 0
            }), Throws.Exception);
        }

        [TestCase(617)]
        public void MostHp(int expected)
        {
            var mostHp = engineLogic.MostHps();
            Assert.That(mostHp.ToArray()[0].Hp, Is.EqualTo(expected));
        }

        [Test]
        public void OldestTest()
        {
            Assert.That(() => carLogic.OldestCar(), Throws.Nothing);
        }
    }
}
