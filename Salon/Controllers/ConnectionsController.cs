﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Salon.Models;

namespace Salon.Controllers
{
    public class ConnectionsController : Controller
    {
        private SalonEntities db = new SalonEntities();

        // GET: Connections
        public ActionResult Index()
        {
            var connections = db.Connections.Include(c => c.ConnectionTypes).Include(c => c.Customers);
            return View(connections.ToList());
            
        }

        // GET: Connections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Connections connections = db.Connections.Find(id);
            if (connections == null)
            {
                return HttpNotFound();
            }
            return View(connections);
        }

        // GET: Connections/Create
        public ActionResult Create()
        {
            ViewBag.ConnectionTypeId = new SelectList(db.ConnectionTypes, "ConnectionTypeId", "Title");
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "NameFull");

            return View();
        }

        //public ActionResult CreateCon()
        //{
        //    ViewBag.ConnectionTypeId = new SelectList(db.ConnectionTypes, "ConnectionTypeId", "Title");
        //    ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "NameFull");

        //    return View();
        //}

        // POST: Connections/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConnectionId,ConnectionTypeId,CustomerId,Title,Description")] Connections connections)
        {
            if (ModelState.IsValid)
            {
                db.Connections.Add(connections);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ConnectionTypeId = new SelectList(db.ConnectionTypes, "ConnectionTypeId", "Title", connections.ConnectionTypeId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "NameFull", connections.CustomerId);
            return View(connections);
        }

        //// POST: Connections/Create
        //// Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        //// finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CreateCon([Bind(Include = "ConnectionId,ConnectionTypeId,CustomerId,Title,Description")] Connections connections)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Connections.Add(connections);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ConnectionTypeId = new SelectList(db.ConnectionTypes, "ConnectionTypeId", "Title", connections.ConnectionTypeId);
        //    ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "NameFull", connections.CustomerId);
        //    return View(connections);
        //}

        // GET: Connections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Connections connections = db.Connections.Find(id);
            if (connections == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConnectionTypeId = new SelectList(db.ConnectionTypes, "ConnectionTypeId", "Title", connections.ConnectionTypeId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "NameFull", connections.CustomerId);
            return View(connections);
        }


        public ActionResult ConnectionsOverview(string searchstring = null)
        {
            var cons = db.Connections.Include(p => p.Customers).Include(p => p.ConnectionTypes);
            IEnumerable<ConnectionViewModel> ConVM = (
                from c in cons
                where c.Customers.FName.Contains(searchstring) || c.Customers.LName.Contains(searchstring) || c.Title.Contains(searchstring) || c.ConnectionTypes.Title.Contains(searchstring) || c.Description.Contains(searchstring)
                orderby c.Title
                select new ConnectionViewModel
                {
                    ConnectionId = c.ConnectionId,
                    Title = c.Title,
                    TypTitle = c.ConnectionTypes.Title,
                    FName = c.Customers.FName,
                    LName = c.Customers.LName,
                    Description = c.Description
                }
                ).ToList();

            return PartialView("_ConnectionsOverview", ConVM);
        }



        // POST: Connections/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConnectionId,ConnectionTypeId,CustomerId,Title,Description")] Connections connections)
        {
            if (ModelState.IsValid)
            {
                db.Entry(connections).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConnectionTypeId = new SelectList(db.ConnectionTypes, "ConnectionTypeId", "Title", connections.ConnectionTypeId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "NameFull", connections.CustomerId);
            return View(connections);
        }

        // GET: Connections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Connections connections = db.Connections.Find(id);
            if (connections == null)
            {
                return HttpNotFound();
            }
            return View(connections);
        }

        // POST: Connections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Connections connections = db.Connections.Find(id);
            db.Connections.Remove(connections);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
