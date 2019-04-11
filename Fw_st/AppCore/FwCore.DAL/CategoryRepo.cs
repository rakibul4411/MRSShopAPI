using DTO;
using FwCore.DAL.Interface;
using FwCore.DBContext;
using FwCore.DBContext.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FwCore.DAL
{
    public class CategoryRepo : Repository<Category>, ICategoryRep
    {        
        public CategoryRepo(AppDataDbContext context): base(context)
        {
            
        }

        public AppDataDbContext db
        {
            get { return _context as AppDataDbContext; }
        }

        public void Delete(int cId)
        {
            Category ca = db.pCategory.Find(cId);
            db.pCategory.Remove(ca);
            db.SaveChanges();
        }

        public CategoryVM FindById(int? id)
        {
            CategoryVM vm = (from c in db.pCategory
                             join pc in db.pCategory
                             on c.CategoryID equals pc.ParentCatID
                             select new CategoryVM
                             {
                                 CategoryID = c.CategoryID,
                                 CatName = c.CatName,
                                 DisplayOrder = c.DisplayOrder,
                                 InsseredDate = c.InsseredDate,
                                 IsActive = c.IsActive,
                                 IsVisiable = c.IsVisiable,
                                 ParentCatName = pc.CatName
                             }).Where(i => i.CategoryID == id).FirstOrDefault();
            return vm;
        }

        public IEnumerable<CategoryVM> GetAllCat()
        {
            IEnumerable<CategoryVM> vm = (from c in db.pCategory
                                          join pc in db.pCategory
                                          on c.ParentCatID equals pc.CategoryID
                                          select new CategoryVM
                                          {
                                              CategoryID = c.CategoryID,
                                              CatName = c.CatName,
                                              DisplayOrder = c.DisplayOrder,
                                              InsseredDate = c.InsseredDate,
                                              IsActive = c.IsActive,
                                              IsVisiable = c.IsVisiable,
                                              //ParentCatID = pc.ParentCatID,
                                              ParentCatName = pc.CatName
                                          });
            return vm;
        }

        public void Insert(CategoryVM cvm)
        {
            Category category = new Category();
            category.CategoryID = cvm.CategoryID;
            category.CatName = cvm.CatName;
            category.DisplayOrder = cvm.DisplayOrder;
            category.InsseredDate = DateTime.Now;
            category.IsActive = cvm.IsActive;
            category.IsVisiable = cvm.IsVisiable;
            category.ParentCatID = cvm.ParentCatID;
            db.pCategory.Add(category);
            db.SaveChanges();
        }

        public void Update(CategoryVM cvm, int id)
        {
            Category category = new Category();
            category.CategoryID = cvm.CategoryID;
            category.CatName = cvm.CatName;
            category.DisplayOrder = cvm.DisplayOrder;
            category.InsseredDate = DateTime.Now;
            category.IsActive = cvm.IsActive;
            category.IsVisiable = cvm.IsVisiable;
            category.ParentCatID = cvm.ParentCatID;
            db.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        //public CategoryVM Add(CategoryVM vm)
        //{
        //    Category category = new Category();
        //    category.CategoryID = vm.CategoryID;
        //    category.CatName = vm.CatName;
        //    category.DisplayOrder = vm.DisplayOrder;
        //    category.InsseredDate = DateTime.Now;
        //    category.IsActive = vm.IsActive;
        //    category.IsVisiable = vm.IsVisiable;
        //    category.ParentCatID = vm.ParentCatID;
        //    db.pCategory.Add(category);
        //    db.SaveChanges();
        //    return vm;
        //}

        //public CategoryVM Get(int? id)
        //{
        //    CategoryVM vm = (from c in db.pCategory
        //                     join pc in db.pCategory
        //                     on c.CategoryID equals pc.ParentCatID
        //                     select new CategoryVM
        //                     {
        //                         CategoryID = c.CategoryID,
        //                         CatName = c.CatName,
        //                         DisplayOrder = c.DisplayOrder,
        //                         InsseredDate = c.InsseredDate,
        //                         IsActive = c.IsActive,
        //                         IsVisiable = c.IsVisiable,
        //                         ParentCatName = pc.CatName
        //                     }).FirstOrDefault(i => i.CategoryID == id);
        //    return vm;
        //}

        //public IEnumerable<CategoryVM> GetAll()
        //{
        //    IEnumerable<CategoryVM> vm = (from c in db.pCategory
        //                                  join pc in db.pCategory
        //                                  on c.CategoryID equals pc.ParentCatID
        //                                  select new CategoryVM
        //                                  {
        //                                      CategoryID = c.CategoryID,
        //                                      CatName = c.CatName,
        //                                      DisplayOrder = c.DisplayOrder,
        //                                      InsseredDate = c.InsseredDate,
        //                                      IsActive = c.IsActive,
        //                                      IsVisiable = c.IsVisiable,
        //                                      ParentCatName = pc.CatName
        //                                  });
        //    return vm;
        //}

        //public bool Remove(int id)
        //{
        //    Category ca = db.pCategory.Find(id);
        //    db.pCategory.Remove(ca);
        //    db.SaveChanges();
        //    return true;
        //}

        //public bool Remove(CategoryVM vm)
        //{
        //    Category ca = db.pCategory.Find(vm.CategoryID);
        //    db.pCategory.Remove(ca);
        //    db.SaveChanges();
        //    return true;
        //}

        //public CategoryVM Update(CategoryVM vm)
        //{
        //    Category category = new Category();
        //    category.CategoryID = vm.CategoryID;
        //    category.CatName = vm.CatName;
        //    category.DisplayOrder = vm.DisplayOrder;
        //    category.InsseredDate = DateTime.Now;
        //    category.IsActive = vm.IsActive;
        //    category.IsVisiable = vm.IsVisiable;
        //    category.ParentCatID = vm.ParentCatID;
        //    db.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //    db.SaveChanges();
        //    return vm;
        //}
    }
}
