using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class ShopRepo
    {
      
            SMSContext db;

            public ShopRepo()
            {

                db = new SMSContext();

            }

            public void Create(Shops s)

            {

                db.Shops.Add(s);

                db.SaveChanges();

            }

            public List<Shops> Get()

            {

                return db.Shops.ToList();

            }

            public void Update(Shops s)

            {

                var exobj = Get(s.Id);

                if (exobj != null)

                {

                    db.Entry(exobj).CurrentValues.SetValues(s);

                    db.SaveChanges();

                }

            }

            public void Delete(int id)

            {

                var exobj = Get(id);

                if (exobj != null)

                {

                    db.Shops.Remove(exobj);

                    db.SaveChanges();

                }

            }

            public Shops Get(int id)

            {

                return db.Shops.Find(id);

            }


        }

    }
