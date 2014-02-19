using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Ferrari.Contracts;
using Ferrari.Models;
using Ferrari.WindowsStore.Contracts;
using Newtonsoft.Json;

namespace Ferrari.WindowsStore.DAL
{
	public class FlickrService : IFlickrService
	{

		//api/flickr/62461882@N04/20

		public async Task<List<FlickrImage>> GetFlickrImagesAsync(string serviceLink)
		{
			var client = new HttpClient();

			try
			{
				var imagesJson = await client.GetStringAsync(serviceLink);

				return await JsonConvert.DeserializeObjectAsync<List<FlickrImage>>(imagesJson);
			}
			catch (Exception exc)
			{
				return null;
			}
		}
	}
}
