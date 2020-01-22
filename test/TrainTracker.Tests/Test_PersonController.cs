using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TrainTracker.Core.Entities;
using TrainTracker.Core.Services;
using TrainTracker.Tests.Fakes;
using TrainTracker.WebAPI.Controllers;
using Xunit;

namespace TrainTracker.Tests
{
    public class Test_PersonController
    {
        private InMemoryPersonService _InMemoryPersonService;
        private PersonController _testPersonController;


        public Test_PersonController()
        {
            _InMemoryPersonService = new InMemoryPersonService();
            _testPersonController = new PersonController(_InMemoryPersonService);
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
        public void Get_WhenCalled_ReturnsObjectLocation()
        {
             var fakePerson = new FakePerson() { Id = 200, FirstName = "Daisy"};
            var result =  _testPersonController.Post(fakePerson) as CreatedAtActionResult;
            Assert.Equal(201, result.StatusCode); 
        }

        [Fact]
        public void Get_WhenCalled_ReturnsPerson()
        {
            var result = _testPersonController.GetById(1);
            Assert.IsType<ActionResult<Person>>(result);
            
        }

             [Fact]
        public void Get_WhenCalled_NotFound()
        {
            var result = _testPersonController.GetById(123456789);
            Assert.IsType<NotFoundResult>(result.Result);
            
        }

        [Fact]
        public void Post_WhenCalled_Returns201ObjectCreatedResult()
        {
            //Arrange
            var fakePerson = new FakePerson() { Id = 2, FirstName = "Alice", LastName = "Norton" };
            //Act
            var result = (CreatedAtActionResult)_testPersonController.Post(fakePerson);

            //Assert
            Assert.Equal(201, result.StatusCode);
        }

        [Fact]
        public void Post_WhenCalledWithoutLastName_GeneratesBadRequestResponse()
        {
            //Arrange
            _testPersonController.ModelState.AddModelError("LastName", "Required");
            var fakePerson = new FakePerson() { Id = 200, FirstName = "Daisy" };
            var result = _testPersonController.Post(fakePerson);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Delete_WhenCalled_GeneratesNotFoundResponse()
        {
            //Arrange
            int Id = 2;
            ActionResult result = _testPersonController.Delete(Id);
            Assert.IsType<NotFoundResult>(result);
        }


        [Fact]
        public void Delete_WhenCalled_GeneratesNoContentResponse()
        {
            //Arrange
            int Id = 1;
            ActionResult result = _testPersonController.Delete(Id);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Put_WhenCalled_GeneratesNotFoundRequest()
        {
            //Arrange
            //Act
            ActionResult result = _testPersonController.Put(new Person() { Id = 2, FirstName = "Geoff", LastName = "Norton" });
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Put_WhenCalled_GeneratesNoContent()
        {
            //Arrange
            //Act
            ActionResult result = _testPersonController.Put(new Person() { Id = 1, FirstName = "Geoff", LastName = "Norton" });
            //Assert
            Assert.IsType<NoContentResult>(result);
        }



        //TODO test Overwrite



    }
}
