using System.Collections.Generic;
using System.Threading.Tasks;
using Ferrari.Models;
using Ferrari.Repositories;
using Ferrari.Configurations;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Ferrari.WindowsStore.Tests.Services
{
	[TestClass]
	public class DataServiceTest
	{
		[TestMethod]
		public async Task DataService_GetItemsAsync_FormulaOne_Test()
		{
			// Arrange
			var sut = new ItemsRepository();

			// Act
			var items = await sut.GetItemsCollectionByCategoryAsync(Constants.FormulaOneLink);

			// Assert
			VerifyItemsGotValidImageUrlsAndTitlesAndDescription(items);
		}

		[TestMethod]
		public async Task DataService_GetItemsAsync_NewsCorporate_Test()
		{
			// Arrange
            var sut = new ItemsRepository();

			// Act
			var items = await sut.GetItemsCollectionByCategoryAsync(Constants.RacingLink);

			// Assert
			VerifyItemsGotValidImageUrlsAndTitlesAndDescription(items);
		}

		[TestMethod]
		public async Task DataService_GetItemsAsync_NewsCorse_Test()
		{
			// Arrange
            var sut = new ItemsRepository();

			// Act
			var items = await sut.GetItemsCollectionByCategoryAsync(Constants.NewsLink);

			// Assert
			VerifyItemsGotValidImageUrlsAndTitlesAndDescription(items);
		}

		private void VerifyItemsGotValidImageUrlsAndTitlesAndDescription(List<Item> items)
		{
			// Assert
			Assert.IsNotNull(items);
			Assert.IsTrue(items.Count > 0);
			Assert.IsTrue(items.Count > 10);

			foreach (var item in items)
			{
				// Check images urls
				Assert.IsTrue(item.ImageUrl.Contains(".jpg")
							 || item.ImageUrl.Contains(".png")
							 || item.ImageUrl.Contains(".jpeg"));

				// Check Title
				Assert.IsTrue(!string.IsNullOrEmpty(item.Title));

				// Check Description
				Assert.IsTrue(!string.IsNullOrEmpty(item.Description));

				// Check TextNews
				Assert.IsTrue(!string.IsNullOrEmpty(item.TextNews));
			}
		}
	}
}
