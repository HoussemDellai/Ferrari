using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ferrari.Contracts;

namespace Ferrari.Repositories
{
	public class CarsRepository : ICarsRepository
	{

		public List<Car> GetAll()
		{
			
			var f12Berlinetta = new Car
			{
				Name = "f12berlinetta",
				EngineCylinders = 12,
				EnginePower = 740,
				EngineRpm = 8700,
				EngineTorque = 545,
				Speed = 340,
				FromZeroTo100 = 3.1,
				FromZeroTo200 = 8.5,
				FuelConsumption = 15,
ImagesUrlCollection = new List<string>
{
	"/Cars.Images/f12berlinetta1int.jpg",
"/Cars.Images/f12berlinetta2int.jpg",
"/Cars.Images/f12berlinetta1ext.jpg",
"/Cars.Images/f12berlinetta2ext.jpg",
"/Cars.Images/f12berlinetta3ext.jpg",
"/Cars.Images/f12berlinetta4ext.jpg",
"/Cars.Images/f12berlinetta5ext.jpg",
},
				PromotionalDescription = "THE MOST POWERFUL FERRARI OF THE RANGE PRODUCT",
				Description =
					"It has a maximum power output of 740 CV at 8250 rpm, while its specific power output is 118 CV/l, a record for this kind of engine. Responsiveness and strong pick-up are assured by maximum torque of 690 Nm, 80 per cent of which is already on tap at 2500 rpm."
					+
					"Exceptional strides have also been made with regard to fuel consumption and emissions both of which have been slashed by 30% to 15l/100 km and 350 g/km of CO2, making the F12berlinetta a benchmark for its reference segment."
					+
					"Its wheelbase is also shorter, the engine and driver seat have been lowered and the rear in more compact thanks to the new suspension and gearbox layout. It is a shorter, lower and narrower car than the previous V12 coupé."
					+
					"Weight distribution is ideal too (54% at the rear) while the centre of gravity is lower and has been moved rearwards in the chassis. The F12berlinetta’s spaceframe chassis and bodyshell are both entirely new. In fact, they incorporate no less than 12 different aluminium alloys, some of which have never been used before in the automotive industry.",
			};
var ff = new Car
{
	Name = "ff",
EngineCylinders = 12,
EnginePower = 660,
EngineRpm = 8000,
EngineTorque = 486,
FromZeroTo100 = 3.7,
FromZeroTo200 = 11,
Speed = 335,
FuelConsumption = 15,
ImagesUrlCollection = new List<string>
{
"/Cars.Images/ff1int.jpg",
"/Cars.Images/ff2int.jpg",
"/Cars.Images/ff3int.jpg",
"/Cars.Images/ff4int.jpg",
"/Cars.Images/ff1ext.jpg",
"/Cars.Images/ff2ext.jpg",
"/Cars.Images/ff3ext.jpg",
"/Cars.Images/ff4ext.jpg",
"/Cars.Images/ff5ext.jpg",
},
PromotionalDescription = "UR AS IN FOUR WHEEL-DRIVE",
Description = "Unlike a conventional four-wheel drive system fitted to a front-engined car, it allows the retention of the traditional mid-front engine architecture, with rear transaxle connected to the engine by a single driveshaft. Added to this is the new Power Transfer Unit or PTU for the front wheels, which is connected directly to the engine and located over the front axle."

+ "This layout permits: "
+ "- a 50% saving in weight compared to a traditional four-wheel drive system. This greatly benefits the FF’s weight-to-power ratio and thus its performance;"

+ "- a low centre of gravity to be maintained and the retention of Ferrari’s sports car weight distribution with more than 50% of weight over the rear axle despite it being a front-engined car.",
			
			};

			var laferrari = new Car
			{
Name = "LaFerrari",
EngineCylinders = 12,
EnginePower = 963,
EngineRpm = 9250,
EngineTorque = 900,
FromZeroTo100 = 3.0,
FromZeroTo200 = 7.0,
Speed = 350,
//FuelConsumption = 
ImagesUrlCollection = new List<string>
{
"/Cars.Images/laferrari1int.jpg",
"/Cars.Images/laferrari2int.jpg",
"/Cars.Images/laferrari1ext.jpg",
"/Cars.Images/laferrari2ext.jpg",
"/Cars.Images/laferrari3ext.jpg",
"/Cars.Images/laferrari4ext.jpg",
"/Cars.Images/laferrari5ext.jpg",
"/Cars.Images/laferrari6ext.jpg",
},
PromotionalDescription = "FERRARI’S  MOST AMBITIOUS PROJECT",
Description = "IT BOASTS THE MOST EXTREME PERFORMANCE EVER ACHIEVED BY A FERRARI PRODUCTION CAR AND FEATURES THE MOST ADVANCED AND INNOVATIVE TECHNICAL SOLUTIONS WHICH WILL, IN THE FUTURE, FILTER DOWN TO THE REST OF THE FERRARI RANGE."
+ "The LaFerrari represents Ferrari’s most ambitious project yet to push the boundaries of technology on a road car, drawing together the finest expression of the marque’s technical capabilities in both GT and Formula 1 engineering."
			};

			var californiaT = new Car
			{
Name = "California T",
EngineCylinders = 8,
EnginePower = 560,
EngineRpm = 7500,
EngineTorque = 412,
Speed = 312,
FromZeroTo100 = 3.6,
FromZeroTo200 = 11.2,
FuelConsumption = 10,
				ImagesUrlCollection = new List<string>
{
"/Cars.Images/californiaT1int.jpg",
"/Cars.Images/californiaT2int.jpg",
"/Cars.Images/californiaT3int.jpg",
"/Cars.Images/californiaT1ext.jpg",
"/Cars.Images/californiaT2ext.jpg",
"/Cars.Images/californiaT3ext.jpg",
"/Cars.Images/californiaT4ext.jpg",
"/Cars.Images/californiaT5ext.jpg",
},
				PromotionalDescription = "E PERFECT SYNTHESIS OF INNOVATION AND TECHNOLOGY",
Description = "The Ferrari California T epitomises the sublime elegance, sportiness, versatility and exclusivity that have distinguished every California model since the 1950s. It is a car brimming with innovation that will more than meet the expectations of discerning clients for whom fun behind the wheel is a priority, but who also demand a sumptuously comfortable Grand Tourer they can use every day."
			};

			var f458italia = new Car
			{
Name = "458 italia",
EngineCylinders = 8,
EnginePower = 570,
EngineRpm = 9000,
EngineTorque = 419,
FromZeroTo100 = 3.4,
FromZeroTo200 = 10.8,
FuelConsumption = 13,
Speed = 325,
ImagesUrlCollection = new List<string>
{
"/Cars.Images/f458italia1int.jpg",
"/Cars.Images/f458italia2int.jpg",
"/Cars.Images/f458italia1ext.jpg",
"/Cars.Images/f458italia2ext.jpg",
"/Cars.Images/f458italia3ext.jpg",
"/Cars.Images/f458italia4ext.jpg",
"/Cars.Images/f458italia5ext.jpg",
},
PromotionalDescription = "OVER 30 INTERNATIONAL AWARDS",
Description = "THE FERRARI 458 ITALIA CONTINUES TO GO FROM STRENGTH TO STRENGTH AND HAS GARNERED OVER 30 INTERNATIONAL AWARDS IN ITS SHORT CAREER."
+ "It added two further plaudits to that collection at the International Engine of the Year Awards when its V8 was voted “Best Performance Engine” and “Best Engine Above 4 Litres”."
			};

			var f458spider = new Car
			{
Name = "458 italia",
EngineCylinders = 8,
EnginePower = 570,
EngineRpm = 9000,
EngineTorque = 419,
FromZeroTo100 = 3.4,
FromZeroTo200 = 10.8,
FuelConsumption = 20,
Speed = 325,
ImagesUrlCollection = new List<string>
{
"/Cars.Images/f458spider1int.jpg",
"/Cars.Images/f458spider2int.jpg",
"/Cars.Images/f458spider1ext.jpg",
"/Cars.Images/f458spider2ext.jpg",
"/Cars.Images/f458spider3ext.jpg",
"/Cars.Images/f458spider4ext.jpg",
"/Cars.Images/f458spider5ext.jpg",
},
PromotionalDescription = "THE 458 SPIDER USHERS IN A WHOLE NEW GENERATION OF FERRARI CONVERTIBLE",
Description = "AN EFFORTLESS MARRIAGE OF TECHNOLOGY, DESIGN AND BEAUTY"
+ "The 458 Spider is the first car ever to combine a mid-rear engine with a retractable folding hard top that delivers both unprecedented in-cabin comfort when closed and unparalleled Spider performance.",
			};

			var carsCollection = new List<Car>
			{
				californiaT, f12Berlinetta, f458italia, f458spider, ff, laferrari
			};

			return carsCollection;
		}
	}

	public class Car
	{
		public string Name { get; set; }

		public string PromotionalDescription { get; set; }

		public string Description { get; set; }

		public List<string> ImagesUrlCollection { get; set; }

		public int Speed { get; set; }

		public double FromZeroTo100 { get; set; }

		public double FromZeroTo200 { get; set; }

///
// l/100 km
///
		public int FuelConsumption { get; set; }

		public int EnginePower { get; set; }

		public int EngineTorque { get; set; }

		public int EngineRpm { get; set; }

		public int EngineCylinders { get; set; }
	}
}
