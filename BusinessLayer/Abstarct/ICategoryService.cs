﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstarct
{
    public interface ICategoryService
    {
        List<Category> GetList();

        void CategoryAdd(Category category);
        Category GetByID(int id);
        void CategoryDelete(Category category);
        void CategoryUpdate(Category category);
        //int GetCategoryCount();
        //int CategoryCountYl(string categoryName);
        //int CategoryWriterACount();
     //   string GetCategoryWithMostHeadings();
        int CategoryStatusFark();

    }
}
