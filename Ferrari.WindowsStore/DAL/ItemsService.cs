using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Ferrari.Contracts;
using Ferrari.Models;
using Ferrari.Configurations;
using Newtonsoft.Json;

namespace Ferrari.WindowsStore.DAL
{
	public class ItemsService : IItemsService
	{

		public async Task<List<Item>> GetItemsAsync(string link)
		{
			//var result = new List<Item>();

			var client = new HttpClient();

			try
			{
				var content = await client.GetStringAsync(link);

				var items = await JsonConvert.DeserializeObjectAsync<List<Item>>(content);

				ChangeItemsCategory(items, link);

				return items;

				//var xml = XElement.Parse(content);

				//var items = xml.Element("channel").Elements("item");

				//foreach (var item in items)
				//{
				//	var itm = new Item
				//	{
				//		Title = item.Element("title").Value,
				//		Link = item.Element("link").Value,
				//		Description = item.Element("description").Value,
				//		Category = item.Element("category").Value,
				//		PublishDate = item.Element("pubDate").Value,
				//		ImageThumbnailUrl = item.Element("urlthumbnail").Value,
				//		ImageUrl = "http://www.ferrari.com" + item.Element("urlimage").Value,
				//		TextNews = item.Element("textnews").Value,
				//	};

				//	result.Add(itm);
				//}

				//return result;
			}
			catch (Exception)
			{
				return null;
			}
		}

		private void ChangeItemsCategory(IEnumerable<Item> items, string link)
		{
			var category = string.Empty;

			if (link == Constants.CarsLink)
			{
				category = Constants.SectionNames[1];
			}
			else if (link == Constants.NewsLink)
			{
				category = Constants.SectionNames[2];
			}
			else if (link == Constants.FormulaOneLink)
			{
				category = Constants.SectionNames[3];
			}
			else if (link == Constants.RacingLink)
			{
				category = Constants.SectionNames[4];
			}

			try
			{
				foreach (var item in items)
				{
					item.Category = category;
				}
			}
			catch (Exception)
			{
				// skip..
			}
		}
	}
}
