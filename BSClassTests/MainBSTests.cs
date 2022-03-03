using Microsoft.VisualStudio.TestTools.UnitTesting;
using BSClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSClass.Tests
{
    [TestClass()]
    public class MainBSTests
    {
        [TestMethod()]
        public void poRaionamTest()
        {
            //Arrange
            var mod = new BaseStation { idBaseStation = 10 };
            Raion raion = null;
            double R0 = 2;

            //Act
            var response = MainBS.modding(mod, R0, raion);
            var result = (Microsoft.AspNetCore.Mvc.NotFoundObjectResult)response.Result.Result;
            
            //assert
            Assert.AreEqual(result.Value, "Не найдена базовая станция с указанным id");
        }
        [TestMethod()]
        public void test2()
        {
            //Arrange
            var mod = new BaseStation { idBaseStation = 1 };
            var raion = new Raion { typeBuild = "Вот такой" };
            double R0 = 2;

            //Act
            var response = MainBS.modding(mod, R0, raion);
            var result = (Microsoft.AspNetCore.Mvc.NotFoundObjectResult)response.Result.Result;

            //Assert
            Assert.AreEqual(result.Value, "Тип постройки не найден");
        }
        [TestMethod()]
        public void test3()
        {
            //Arrange
            var mod = new BaseStation { idBaseStation = 1 };
            var raion = new Raion { typeBuild = "Вот такой" };
            double R0 = 0;

            //Act
            var response = MainBS.modding(mod, R0, raion);
            var result = (Microsoft.AspNetCore.Mvc.NotFoundObjectResult)response.Result.Result;

            //Assert
            Assert.AreEqual(result.Value, "Радиус не может быть меньше нуля");
        }
        [TestMethod()]
        public void test4()
        {
            //Arrange
            var mod = new BaseStation { area = 2, idBaseStation = 1, begin = 4, end = 5 };
            var raion = new Raion { typeBuild = "Плотная городская застройка" };
            double R0 = 2;

            //Act
            var response = MainBS.modding(mod, R0, raion);
            var result = (Microsoft.AspNetCore.Mvc.NotFoundObjectResult)response.Result.Result;

            //Assert
            Assert.AreEqual(result.Value, "Показания хэндовера превышают допустимые");
        }
        [TestMethod()]
        public void test5()
        {
            //Arrange
            var raion = new Raion { typeBuild = "Плотная городская застройка" };

            //Act
            var response = MainBS.mainRaschet(raion);
            var result = (Microsoft.AspNetCore.Mvc.NotFoundObjectResult)response.Result.Result;

            //Assert
            Assert.AreEqual(result.Value, "Радиус района не может быть меньше нуля");
        }
        [TestMethod()]
        public void test6()
        {
            //Arrange
            double c = 0;
            double L = 2;
            bool hand = false;

            //Act
            var response = MainBS.getN(L, c, hand);
            var result = (Microsoft.AspNetCore.Mvc.NotFoundObjectResult)response.Result.Result;

            //Assert
            Assert.AreEqual(result.Value, "Количество базовых станций в одном кластере не может равняться нулю");
        }
        [TestMethod()]
        public void test7()
        {
            //Arrange
            double c = 2;
            double L = 0;
            bool hand = false;

            //Act
            var response = MainBS.getN(L, c, hand);
            var result = (Microsoft.AspNetCore.Mvc.NotFoundObjectResult)response.Result.Result;

            //Assert
            Assert.AreEqual(result.Value, "Соты не могут равняться нулю, проверьте правильность введенных данных");
        }
        [TestMethod()]
        public void test8()
        {
            //Arrange
            double c = 2;
            double L = 2;
            bool hand = true;

            //Act
            var response = MainBS.getN(L, c, hand);
            var result = (Microsoft.AspNetCore.Mvc.NotFoundObjectResult)response.Result.Result;

            //Assert
            Assert.AreEqual(result.Value, "Показания одной из базовых станций низкое, поэтому конечное количество базовых станций будет умножено на 1.4");
        }
        [TestMethod()]
        public void test9()
        {
            //Arrange
            int i = 1;

            //Act
            var response = MainBS.ras(i);
            var result = response.Result;

            //Assert
            Assert.AreEqual(result, "В настоящий момент сервер недоступен, пожалуйста повторите попытку позднее");
        }
        [TestMethod()]
        public void test10()
        {
            //Arrange
            int i = 1;

            //Act
            string result = MainBS.poRaionam();

            //Assert
            Assert.AreEqual(result, "Ошибка в подключении к базе данных");
        }
    }
}