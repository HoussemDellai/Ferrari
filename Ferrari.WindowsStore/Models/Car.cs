using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferrari.Models
{
	public class Car
	{
		public string Name
		{ get; set; }

		public string PromotionalDescription
		{ get; set; }

		public string Description
		{ get; set; }

		public List<string> ImagesUrlCollection
		{ get; set; }

		public int Speed
		{ get; set; }

		public double FromZeroTo100
		{ get; set; }

		public double FromZeroTo200
		{ get; set; }

		///
		// l/100 km
		///
		public int FuelConsumption
		{ get; set; }

		public int EnginePower
		{ get; set; }

		public int EngineTorque
		{ get; set; }

		public int EngineRpm
		{ get; set; }

		public int EngineCylinders
		{ get; set; }
	}
}
