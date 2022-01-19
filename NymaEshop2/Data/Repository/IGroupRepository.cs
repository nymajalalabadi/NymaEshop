using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NymaEshop2.Data;
using NymaEshop2.Models;

namespace NymaEshop2.Data.Repository
{
    public interface IGroupRepository
    {
        IEnumerable<Category> GetAllCategories();


        IEnumerable<ProdcutGroupViewModel> GetGroupForShow();

    }






    public class GroupRepository : IGroupRepository
    {

        private MyEshopContext _context;

        public GroupRepository(MyEshopContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories;
        }

        public IEnumerable<ProdcutGroupViewModel> GetGroupForShow()
        {
            return _context.Categories.Select(c => new ProdcutGroupViewModel()
            {
                GroupId=c.Id,
                Name=c.NameCT,
                ProductCount=_context.CategoryToProducts.Count(i=>i.Categoryid==c.Id)
            }).ToList();
        }


    }


}


