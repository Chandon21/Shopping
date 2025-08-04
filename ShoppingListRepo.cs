using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class ShoppingListRepo
    {
        private SMSContext db;

        public ShoppingListRepo()
        {
            db = new SMSContext();
        }

      

        public List<ShoppingList> GetAll()
        {
            return db.ShoppingLists.Include("Items").ToList();
        }

        public ShoppingList Get(int id)
        {
            return db.ShoppingLists.Include("Items").FirstOrDefault(sl => sl.Id == id);
        }

        public void Delete(int id)
        {
            var shoppingList = Get(id);
            if (shoppingList != null)
            {
                db.ShoppingLists.Remove(shoppingList);
                db.SaveChanges();
            }
        }
        public void Create(ShoppingList shoppingList)
        {
            db.ShoppingLists.Add(shoppingList);
            db.SaveChanges();
        }
        public List<ShoppingList> GetByCategory(string category)
        {
            return db.ShoppingLists.Include("Items")
                                   .Where(sl => sl.Category == category)
                                   .ToList();
        }

    }
}
