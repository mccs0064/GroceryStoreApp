using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Grocery.API.Models;

namespace Grocery.API.Controllers
{
    public class ItemListsController : ApiController
    {
        private GroceryAPIContext db = new GroceryAPIContext();

        // GET: api/ItemLists
        public IQueryable<ItemList> GetItemLists()
        {
            return db.ItemLists;
        }

        // GET: api/ItemLists/5
        [ResponseType(typeof(ItemList))]
        public IHttpActionResult GetItemList(int id)
        {
            ItemList itemList = db.ItemLists.Find(id);
            if (itemList == null)
            {
                return NotFound();
            }

            return Ok(itemList);
        }

        // PUT: api/ItemLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutItemList(int id, ItemList itemList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != itemList.Id)
            {
                return BadRequest();
            }

            db.Entry(itemList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ItemLists
        [ResponseType(typeof(ItemList))]
        public IHttpActionResult PostItemList(ItemList itemList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ItemLists.Add(itemList);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = itemList.Id }, itemList);
        }

        // DELETE: api/ItemLists/5
        [ResponseType(typeof(ItemList))]
        public IHttpActionResult DeleteItemList(int id)
        {
            ItemList itemList = db.ItemLists.Find(id);
            if (itemList == null)
            {
                return NotFound();
            }

            db.ItemLists.Remove(itemList);
            db.SaveChanges();

            return Ok(itemList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemListExists(int id)
        {
            return db.ItemLists.Count(e => e.Id == id) > 0;
        }
    }
}