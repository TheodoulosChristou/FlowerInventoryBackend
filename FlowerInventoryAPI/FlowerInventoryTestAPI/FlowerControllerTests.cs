using AutoFixture;
using FlowerInventoryAPI.Controllers;
using FlowerInventoryAPI.Entities;
using FlowerInventoryAPI.Services.FlowerService;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerInventoryTestAPI
{
    [TestClass]
    public class FlowerControllerTests
    {
        private readonly Mock<IFlowerService> _service;
        private readonly Fixture _fixture;
        private FlowerController _controller;

        public FlowerControllerTests()
        {
            _fixture = new Fixture();

            // Prevent circular reference issues
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
               .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _service = new Mock<IFlowerService>();
            _controller = new FlowerController(_service.Object);
        }

        /**
         * This is the Test method for Get All Flowers
         */
        [TestMethod]
        public async Task Get_Flowers_ReturnOk()
        {
            // Arrange
            var flowerList = _fixture.CreateMany<Flower>(4).ToList();
            _service.Setup(ser => ser.GetAllFlowers()).ReturnsAsync(flowerList);
            

            // Act
            var result = await _controller.GetAllFlowers();

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var returnValue = okResult.Value as List<Flower>;
            Assert.IsNotNull(returnValue);
            Assert.AreEqual(flowerList.Count, returnValue.Count);
        }

        [TestMethod]
        public async Task Get_FlowerById_ReturnsOk()
        {
            // Arrange
            var flower = _fixture.Create<Flower>();
            var id = flower.FlowerId;

            _service.Setup(s => s.GetFlowerByFlowerId(id)).ReturnsAsync(flower);

            // Act
            var result = await _controller.GetFlowerByFlowerId(id);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var returnValue = okResult.Value as Flower;
            Assert.IsNotNull(returnValue);
            Assert.AreEqual(flower.FlowerId, returnValue.FlowerId);
        }


        [TestMethod]
        public async Task Create_Flower_ReturnsCreatedAtAction()
        {
            var flower = _fixture.Create<Flower>();
            _service.Setup(s => s.CreateFlower(It.IsAny<Flower>())).ReturnsAsync(flower);

            var result = await _controller.CreateFlower(flower);
            var createdResult = result.Result as OkObjectResult;

            Assert.AreEqual(200, createdResult.StatusCode);
            Assert.AreEqual(flower, createdResult.Value);
        }

        [TestMethod]
        public async Task Update_Flower_WithObjectOnly_ReturnsNoContent()
        {
            var flower = _fixture.Create<Flower>();
            _service.Setup(s => s.UpdateFlower(It.IsAny<Flower>())).ReturnsAsync(flower);

            var result = await _controller.UpdateFlower(flower);

            var okResult = result.Result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(flower, okResult.Value);
        }

        [TestMethod]
        public async Task Delete_Flower_WithObjectOnly_ReturnsOkWithResponse()
        {
            // Arrange
            var flower = _fixture.Create<Flower>();
            var response = new BaseCommandResponse
            {
                Id = flower.FlowerId,
                Entity = "Flower",
                Message = "Flower deleted successfully"
            };

            _service.Setup(s => s.DeleteFlower(It.IsAny<Flower>())).ReturnsAsync(response);

            // Act
            var result = await _controller.DeleteFlower(flower);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var returnValue = okResult.Value as BaseCommandResponse;
            Assert.IsNotNull(returnValue);
            Assert.AreEqual("Flower deleted successfully", returnValue.Message);
        }

    }
}
