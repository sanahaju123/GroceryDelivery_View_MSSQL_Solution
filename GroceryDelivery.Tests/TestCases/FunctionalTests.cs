using GroceryDelivery.Tests;
using GroceryDelivery.BusinessLayer.Interfaces;
using GroceryDelivery.BusinessLayer.Services;
using GroceryDelivery.BusinessLayer.Services.Repository;
using GroceryDelivery.Entites;
using Moq;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace GroceryDelivery.Tests.TestCases
{
    public class FunctionalTests
    {
        /// <summary>
        /// Creating Referance Variable of Service Interface and Mocking Repository Interface and class
        /// </summary>
        private readonly ITestOutputHelper _output;
        private readonly IGroceryServices _GroceryServices;
        public readonly Mock<IGroceryRepository> service = new Mock<IGroceryRepository>();
        private readonly Product _product;
        private readonly ProductOrder _productOrder;
        private readonly ApplicationUser _user;
        private readonly ProductOrder _order;
        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
        {
            //Creating New mock Object with value.
            _output = output;
            _GroceryServices = new GroceryServices(service.Object);
            _product = new Product
            {
                ProductId = 2,
                ProductName = "Samsung - TV",
                Description = "Size - 72, SSD-128 GB, Processor-Snap Dragon 805, Screen - 4500X3000PX",
                Amount = 12990,
                stock = 13,
                CatId = 2
            };
            _productOrder = new ProductOrder
            {
                ProductId = 2,
                OrderId = 1,
                UserId = 3,
            };
            _user = new ApplicationUser()
            {
                UserId = 2,
                Name = "Name1",
                Email = "namelast@gmail.com",
                MobileNumber = 9631438113,
                PinCode = 823311,
                HouseNo_Building_Name = "9/11",
                Road_area = "Manpur Gaya",
                City = "Gaya",
                State = "Bihar"
            };
            _order = new ProductOrder()
            {
                OrderId=1,
                ProductId = 1,
                UserId = 1
            };
        }
        
        /// <summary>
        /// Testfor_Validate_ValidUserPlacing Order and product id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_ValidPlaceOrder()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                service.Setup(repo => repo.PlaceOrder(_productOrder));
                var result = await _GroceryServices.PlaceOrder(_productOrder);
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }

            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            //final result save in text file, Call rest API to save test result
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


        /// <summary>
        /// Get All product by id and without id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetAllProduct()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                service.Setup(repos => repos.GetAllProduct());
                var result = await _GroceryServices.GetAllProduct();
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            //final result save in text file, Call rest API to save test result
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


        /// <summary>
        /// Get One Product by id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetOneProduct()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                service.Setup(repos => repos.GetProductById(_product.ProductId)).ReturnsAsync(_product);
                var result = await _GroceryServices.GetProductById(_product.ProductId);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch(Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
          //final result save in text file, Call rest API to save test result
          await CallAPI.saveTestResult(testName, status, type);
          return res;
        }
        /// <summary>
        /// Get Order by Order Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_OrderByuserId()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                service.Setup(repos => repos.OrderByuserId(_user.UserId));
                var result = await _GroceryServices.OrderByuserId(_user.UserId);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch(Exception)
            {
              //Assert
              //final result save in text file if exception raised
              status = Convert.ToString(res);
              _output.WriteLine(testName + ":Failed");
              await CallAPI.saveTestResult(testName, status, type);
              return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            //final result save in text file, Call rest API to save test result
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


        /// <summary>
        /// Get Product By Name
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetProductByName()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                service.Setup(repos => repos.ProductByName(_product.ProductName));
                var result = await _GroceryServices.ProductByName(_product.ProductName);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch(Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
          //final result save in text file, Call rest API to save test result
          await CallAPI.saveTestResult(testName, status, type);
          return res;
        }


        /// <summary>
        /// Add New Product
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_AddProduct()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                service.Setup(repos => repos.AddProduct(_product)).ReturnsAsync(_product);
                var result = _GroceryServices.AddProduct(_product);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch(Exception)
            {
                  //Assert
                  //final result save in text file if exception raised
                  status = Convert.ToString(res);
                  _output.WriteLine(testName + ":Failed");
                  await CallAPI.saveTestResult(testName, status, type);
                  return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }
    }
}
