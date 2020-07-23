using Myshop.Core.Contracts;
using Myshop.Core.Models;
using Myshop.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Myshop.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        // GET: ProductCategory
        IRepository<ProductCategory> context;
        public ProductCategoryManagerController(IRepository<ProductCategory> context) 
        {
            this.context = context;

        }
        public ActionResult Index()
        {
            List<ProductCategory> productCategories = context.Collection().ToList();
            return View(productCategories);
        }

        public ActionResult Create()
        {
            ProductCategory productCategory = new ProductCategory();
            return View(productCategory);
        }

        [HttpPost]
        public ActionResult Create(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(productCategory);
            }
            else
            {
                context.Insert(productCategory);
                context.Commit();
            }
            return RedirectToAction("Index");
        }




        public ActionResult Edit(string Id)
        {
            ProductCategory productCategory = context.Find(Id);
            if (productCategory == null)
            {
                return HttpNotFound();

            }
            else
            {
                return View(productCategory);

            }
        }


        [HttpPost]
        public ActionResult Edit(ProductCategory productCategory, String Id)
        {
            ProductCategory productCategoryToFind = context.Find(Id);

            if (productCategoryToFind == null)
            {
                return HttpNotFound();

            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productCategory);
                }

                productCategoryToFind.Category = productCategory.Category;
             

                context.Commit();

                return RedirectToAction("Index");

            }
        }

        public ActionResult Delete(ProductCategory productCategory, String Id)
        {
            ProductCategory productCategoryToDelete = context.Find(Id);

            if (productCategoryToDelete == null)
            {
                return HttpNotFound();

            }
            else
            {
                return View(productCategoryToDelete);

            }
        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(String Id)
        {
            ProductCategory productCategoryToDelete = context.Find(Id);

            if (productCategoryToDelete == null)
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