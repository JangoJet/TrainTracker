using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TrainTracker.Core.Entities;
using TrainTracker.Tests.Fakes;
using TrainTracker.WebAPI.Controllers;
using Xunit;

namespace TrainTracker.Tests
{
    public class Test_PersonController
    {
        private FakeInMemoryPersonService _fakeInMemoryPersonService;
        private PersonController _testPersonController;


        public Test_PersonController()
        {
            _fakeInMemoryPersonService = new FakeInMemoryPersonService();
            _testPersonController = new PersonController(_fakeInMemoryPersonService);
        }
        [Fact]
        public void Get_WhenCalled_Returns200OKResult()
        {
            //Arrange
            //Act
            var result = _testPersonController.Get();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAListOfPersons()
        {
            //Arrange
            //Act
            var persons = _testPersonController.Get();
            //Assert
            Assert.IsType<ActionResult<IEnumerable<Person>>>(persons);
      
        }

        [Fact]
        public void Get_WhenCalled_Returns201ObjectCreatedResult()
        {
            //Arrange
            //Act
            var result = (StatusCodeResult) _testPersonController.Post();
            //Assert
            Assert.Equal(201, result.StatusCode);
        }
    }
}
