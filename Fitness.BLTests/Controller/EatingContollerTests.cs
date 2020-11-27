using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness.BL.Model;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class EatingContollerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var userName = new Guid().ToString();
            var foodName = new Guid().ToString();

            var rnd = new Random();

            var userController = new UserController(userName);
            var eatingController = new EatingContoller(userController.CurrentUser);
            var food = new Food(foodName, rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));

            //Act
            eatingController.Add(food, 100);

            //Assert
            Assert.AreEqual(food.Name, eatingController.Eating.Portions.First().Food.Name);
        }
    }
}