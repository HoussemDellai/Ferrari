using System.Collections.Generic;

namespace Ferrari.Utilities
{
    public static class PreviousAndNextFromListUtilities<TEntity> where TEntity : class
    {
        /// <summary>
        ///     Looks for and returns the previous object in a given collection.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="objectsCollection"></param>
        /// <returns></returns>
        public static TEntity GetPreviousObjectFromCollection(TEntity obj, List<TEntity> objectsCollection)
        {
            if (obj == null || objectsCollection == null)
                return null;

            int selectedItemIndex = objectsCollection.IndexOf(obj);

            TEntity previousObject;

            if (selectedItemIndex == 0)
            {
                previousObject = objectsCollection[objectsCollection.Count - 1];
            }
            else
            {
                previousObject = objectsCollection[selectedItemIndex - 1];
            }

            return previousObject;
        }

        /// <summary>
        ///     Looks for and returns the previous object in a given collection.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="objectsCollection"></param>
        /// <returns></returns>
        public static TEntity GetNextObjectFromCollection(TEntity obj, List<TEntity> objectsCollection)
        {
            if (obj == null || objectsCollection == null)
                return null;

            int selectedItemIndex = objectsCollection.IndexOf(obj);

            TEntity previousObject;

            if (selectedItemIndex == objectsCollection.Count - 1)
            {
                previousObject = objectsCollection[0];
            }
            else
            {
                previousObject = objectsCollection[selectedItemIndex + 1];
            }

            return previousObject;
        }
    }
}