using cosmos_db_todo_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace cosmos_db_todo_app.Controllers
{
    public class ItemsController : Controller
    {
        // GET: Items
        [ActionName("Index")]
        public async Task<ActionResult> Index()
        {
            var items = await DocumentDBRepository<Item>.GetItemsAsync(d => !d.Completed);
            return View(items);
        }
    }
}