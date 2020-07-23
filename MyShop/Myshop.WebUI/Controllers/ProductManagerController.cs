using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Myshop.Core.Models;
using Myshop.Core.ViewModels;
using Myshop.DataAccess.InMemory;


namespace Myshop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {

        InMemoryRepository<Product> context;
        // GET: ProductManager
        InMemoryRepository<ProductCategory> productCategories;
        

        public ProductManagerController()
        {
            context = new InMemoryRepository<Product>();
            productCategories = new InMemoryRepository<ProductCategory>();

        }
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }

        public ActionResult Create()
        {
            ProductManagerViewModel viewModel = new ProductManagerViewModel();

            viewModel.Product = new Product();
            viewModel.ProductCategories = productCategories.Collection();



            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                context.Insert(product);
                context.Commit();
            }
            return RedirectToAction("Index");
        }




        public ActionResult Edit(string Id)
        {
            Product product = context.Find(Id);
            if (product == null)
            {
                return HttpNotFound();

            }
            else
            {

                ProductManagerViewModel viewModel = new ProductManagerViewModel();
                viewModel.Product = product;
                viewModel.ProductCategories = productCategories.Collection();

                return View(viewModel);

            }
        }


        [HttpPost]
        public ActionResult Edit(Product product, String Id)
        {
            Product productToFind = context.Find(Id);

            if (productToFind == null)
            {
                return HttpNotFound();

            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }

                productToFind.Category = product.Category;
                productToFind.Description = product.Description;
                productToFind.Image = product.Image;
                productToFind.Name = product.Name;
                productToFind.Price = product.Price;

                context.Commit();

                return RedirectToAction("Index");

            }
        }

        public ActionResult Delete(Product product, String Id)
        {
            Product productToDelete = context.Find(Id);

            if (productToDelete == null)
            {
                return HttpNotFound();

            }
            else
            {
                return View(productToDelete);

            }
        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(String Id)
        {
            Product productToDelete = context.Find(Id);

            if (productToDelete == null)
            {
                return HttpNotFound();

            }
            else
            {
                 context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");

            }
            
        }
    }

}