using GroceryDelivery.BusinessLayer.Interfaces;
using GroceryDelivery.BusinessLayer.Services;
using GroceryDelivery.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryDelivery.Controllers
{
    public class GroceryController : Controller
    {
        private readonly IGroceryServices _groceryServices;

        public GroceryController(IGroceryServices services)
        {
            _groceryServices = services;
        }
        // GET: GroceryController
        public async Task<IActionResult> Index()
        {
            var prod = await _groceryServices.GetAllProduct();
            return View(prod);
        }

        // GET: GroceryController/Details/5
        [HttpGet]
        [Route("/Grocery/Details/{productId:int}")]
        public async Task<IActionResult> Details([FromRoute] int? productId)
        {
            var prod = await _groceryServices.GetProductById(productId);
            return View(prod);
        }

        [HttpGet]

        public ActionResult Create()

        {

            return View();

        }

        [HttpPost]

        public ActionResult Create(Product model)

        {

            _groceryServices.AddProduct(model);

            ViewBag.Message = "Data Insert Successfully";

            return View();

        }

        [HttpGet]

        public async Task<ActionResult> Edit(int id)

        {

            var data =await _groceryServices.GetProductById(id);

            return View(data);

        }

        [HttpPost]

        public async Task<ActionResult> Edit(Product Model)

        {

            var data = await _groceryServices.GetProductById(Model.ProductId);

            if (data != null)

            {

                data.ProductName = Model.ProductName;

                data.Description = Model.Description;

                data.stock = Model.stock;

                data.Amount = Model.Amount;

                data.CatId = Model.CatId;

                data.photo = Model.photo;

                _groceryServices.UpdateProduct(data);

            }

            return RedirectToAction("index");

        }

        // GET: Employees/Delete/1
        [HttpGet]
        [Route("/Grocery/Delete/{productId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int? productId)
        {
            var prod = await _groceryServices.GetProductById(productId);
            return View(prod);
        }

        // POST: Employees/Delete/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int productId)
        {
            if (productId == null)
            {
                return NotFound();
            }
            await _groceryServices.DeleteProductById(productId);
            return RedirectToAction("Index", "Grocery");
        }
    }
}
