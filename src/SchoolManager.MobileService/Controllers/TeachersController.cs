using Microsoft.WindowsAzure.Mobile.Service;
using SchoolManager.MobileService.DataObjects;
using SchoolManager.MobileService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace SchoolManager.MobileService.Controllers
{
    
    public class TeachersController : TableController<Teacher>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Teacher>(context, Request, Services);
        }

        public IQueryable<Teacher> GetAllTeachers()
        {
            return Query();
        }

        public SingleResult<Teacher> GetTeacher(string id)
        {
            return Lookup(id);
        }
    }
}