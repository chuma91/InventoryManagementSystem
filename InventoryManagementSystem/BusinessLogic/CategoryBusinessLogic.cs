using InventoryManagementSystem.Models;
using InventoryManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.BusinessLogic
{
    public class CategoryBusinessLogic
    {

        InventoryManagementDatabaseEntities db = new InventoryManagementDatabaseEntities();
        public List<Category> GetAllCategories()
    {
        List<Category> cat = new List<Category>();
        try
        {
           cat = db.Categories.ToList().FindAll(x=>x.IsDeleted == false);

        }
        catch (Exception ex)
        {
            return null;
        }

        return cat;
    }
    public bool RemoveCategoryById(int CategoryId)
    {
        bool result = false;
        try
        {
            var Find = db.Categories.ToList().FirstOrDefault(x => x.Category_ID == CategoryId && x.IsDeleted == false);
            if (Find != null)
            {
                Find.IsDeleted = true;
                db.SaveChanges();
                result = true;
            }
        }
        catch (Exception ex)
        {

        }

        return result;
    }

    public Category GetCategoryById(int CategoryId)
    {
            Category category = new Category();
        try
        {
            category = db.Categories.ToList().FirstOrDefault(x => x.Category_ID == CategoryId && x.IsDeleted == false);
        }
        catch
        {
            return null;
        }
        return category;
    }

    public bool UpdateCategoriesById(CategoriesViewModel categoriesViewModel)
    {
        bool result = false;
        try
        {
            var Find = db.Categories.ToList().FirstOrDefault(x => x.Category_ID == categoriesViewModel.CategoryID && x.IsDeleted == false);
            if (Find != null)
            {
                Find.CategoryName = categoriesViewModel.CategoryName;
                Find.Description = categoriesViewModel.Description;
                db.SaveChanges();
                result = true;
            }
        }
        catch (Exception ex)
        {

        }

        return result;
    }

    public bool AddNewCategories(CategoriesViewModel categoriesViewModel)
    {
        bool result = false;
        try
        {
            Category obj = new Category();
            obj.CategoryName = categoriesViewModel.CategoryName;
            obj.Description = categoriesViewModel.Description;
            obj.IsDeleted = false;

            db.Categories.Add(obj);
            db.SaveChanges();
            result = true;
        }
        catch (Exception ex)
        {

        }

        return result;
    }
    
    }
}