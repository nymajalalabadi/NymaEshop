using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NymaEshop2.Data;
using NymaEshop2.Models;
using NymaEshop2.Data.Repository;



namespace NymaEshop2.Component
{
    public class ProductGroupsComponets:ViewComponent
    {
        private IGroupRepository _grouprepository;

        public ProductGroupsComponets(IGroupRepository grouprepository)
        {
            _grouprepository = grouprepository;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View("/Views/Components/ProductGroupCompnets.cshtml", _grouprepository.GetGroupForShow());
        }
    }
}
