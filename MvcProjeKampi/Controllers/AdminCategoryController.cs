﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory
        CategoryManager cm = new CategoryManager(new EfCategoryDal()/*, new EfHeadingDal(), new EfWriterDal()*/);
        public ActionResult Index()
        {
            var categoryValues = cm.GetList();
            return View(categoryValues);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result= categoryValidator.Validate(p);
            if (result.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            var categoryValue=cm.GetByID(id);
            cm.CategoryDelete(categoryValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryValue =cm.GetByID(id);
            return View(categoryValue);
        }
        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    cm.CategoryUpdate(p);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Güncelleme işlemi sırasında bir hata oluştu: " + ex.Message);
                }
            }
            return View(p);
        }




    }
}