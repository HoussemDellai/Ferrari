using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ferrari.Contracts;
using Ferrari.Models;
using Ferrari.Repositories;
using Ferrari.ViewModels;

namespace Ferrari.ViewModels
{
	public class CarSpecificationViewModel : BaseViewModel
	{
		private List<Car> _carsCollection;

		public List<Car> CarsCollection
		{
			get { return _carsCollection; }
			set
			{
				_carsCollection = value; 
				OnPropertyChanged();
			}
		}

		public CarSpecificationViewModel(ICarsRepository carsRepository)
		{

			CarsCollection = carsRepository.GetAll();
		}
	}
}
