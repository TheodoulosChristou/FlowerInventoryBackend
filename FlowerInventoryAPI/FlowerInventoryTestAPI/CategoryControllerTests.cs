using AutoFixture;
using FlowerInventoryAPI.Controllers;
using FlowerInventoryAPI.Entities;
using FlowerInventoryAPI.Services.CategoryService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerInventoryTestAPI
{
    [TestClass]
    public class CategoryControllerTests
    {
        private readonly Mock<ICategoryService> _service;
        private readonly Fixture _fixture;
        private CategoryController _controller;

        public CategoryControllerTests()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _service = new Mock<ICategoryService>();
            _controller = new CategoryController(_service.Object);
        }

        [TestMethod]
        public async Task GetAllCategories_ReturnsOk()
        {
            var categoryList = _fixture.CreateMany<Category>(4).ToList();
            _service.Setup(ser => ser.GetAllCategories()).ReturnsAsync(categoryList);
            

            var result = await _controller.GetAllCategories();
            var okResult = result.Result as OkObjectResult;
            var returnList = okResult.Value as List<Category>;

            Assert.IsNotNull(returnList);
            Assert.AreEqual(categoryList.Count, returnList.Count);
        }

        [TestMethod]
        public async Task GetCategoryByCategoryId_ReturnsOk()
        {
            var category = _fixture.Create<Category>();
            var catId = category.CategoryId;

            _service.Setup(ser=>ser.GetCategoryByCategoryId(catId)).ReturnsAsync(category);

            var result = await _controller.GetCategoryByCategoryId(catId);
            var okResult = result.Result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task CreateCategory_ReturnsOk()
        {
            var category = _fixture.Create<Category> ();
            _service.Setup(ser=>ser.CreateCategory(category)).ReturnsAsync(category);   
            _controller = new CategoryController (_service.Object);

            var result = await _controller.CreateCategory(category);
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task UpdateCategory_ReturnsOk()
        {
            var category = _fixture.Create<Category>();
            _service.Setup(ser => ser.UpdateCategory(category)).ReturnsAsync(category);

            var result = await _controller.UpdateCategory(category);
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200,okResult.StatusCode);
        }

        [TestMethod]
        public async Task DeleteCategory_ReturnsOk()
        {
            
            var category = _fixture.Create<Category>();
            BaseCommandResponse response = new BaseCommandResponse
            {
                Id = category.CategoryId,
                Entity = "Category",
                Message = "Category Object has been deleted"
            };

            _service.Setup(ser => ser.DeleteCategory(category)).ReturnsAsync(response);

            var result = await _controller.DeleteCategory(category);
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);  
        }
    }

}
