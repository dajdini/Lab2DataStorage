using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2DataStorage.Controllers
{
    public class ApartmentsController : Controller
    {
        // GET: Apartments
        public ActionResult Index()
        {
            return View();
        }

        // GET: Apartments/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Apartments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Apartments/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Models.MongoDBClass.ConnectToMongoService();
                Models.MongoDBClass.apartments_collection =
                    Models.MongoDBClass.database.GetCollection<Models.Apartments>("apartments");

                Object id = GenerateRandomId(24);

                Models.MongoDBClass.apartments_collection.InsertOneAsync(new Models.Apartments { 
                    _id = id,
                    ApartName = collection["ApartName"],
                    ApartAdress = collection["ApartAdress"]
                
                });;  

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private static Random random = new Random();
        private object GenerateRandomId(int v)
        {
            string strarray = "abcdefghijklmnopqrstuvwxyz123456789";
            return new string(Enumerable.Repeat(strarray, v).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // GET: Apartments/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Apartments/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Apartments/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Apartments/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
