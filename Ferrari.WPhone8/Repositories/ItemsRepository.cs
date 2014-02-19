using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ferrari.Contracts;
using Ferrari.Models;
using Ferrari.WindowsStore.Contracts;
using Ferrari.WPhone8.SqlCeDataContext;

namespace Ferrari.Repositories
{
    public class ItemsRepository : IItemsRepository
    {

        #region IItemsRepository Members

        public Task<List<Item>> GetItemsCollectionByCategoryAsync(string itemCategory)
        {
            try
            {
                List<Item> items;

                using (var context = new FerrariDataContext())
                {
                    IQueryable<Item> itemsCollection = from itms
                        in context.GetTable<Item>()
                        select itms;

                    items = itemsCollection.Where(item => item.Category == itemCategory).ToList();
                }

                return Task.FromResult(items);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task<bool> SaveItemsCollectionAsync(List<Item> items)
        {
            if (items == null || items.Count == 0)
                return Task.FromResult<bool>(false);

            try
            {
                //Adding data to the local database 
                using (var context = new FerrariDataContext())
                {
                    var oldItems = context.GetTable<Item>().Where(entity => entity.Category == items.FirstOrDefault().Category);
                    context.GetTable<Item>().DeleteAllOnSubmit(oldItems);
                    context.SubmitChanges();

                    foreach (Item item in items)
                    {
                        context.GetTable<Item>().InsertOnSubmit(item);
                    }
                    context.SubmitChanges();
                }

                return Task.FromResult<bool>(true);
            }
            catch (Exception exc)
            {
                return Task.FromResult<bool>(false);
            }
        }

        #endregion
    }
}