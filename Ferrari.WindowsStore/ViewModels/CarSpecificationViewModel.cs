using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ferrari.Contracts;
using Ferrari.Models;
using Ferrari.Repositories;
using Ferrari.ViewModels;
using Microsoft.Practices.Unity;

namespace Ferrari.ViewModels
{
	public class CarSpecificationViewModel : BaseViewModel
	{
		private Car _selectedCar;

		public Car SelectedCar
		{
			get
			{ return _selectedCar; }
			set
			{
				_selectedCar = value;
				OnPropertyChanged();
			}
		}

		public CarSpecificationViewModel(Car selectedCar)
		{

			SelectedCar = selectedCar;   //carsRepository.GetAll();

#if WINDOWS_PHONE
			if (System.ComponentModel.DesignerProperties.IsInDesignTool)
#endif
//#if NETFX_CORE
//			if (DesignMode.DesignModeEnabled)
//#endif
			{
				SelectedCar = new CarsRepository().GetAll()[0];
			}
		}
	}
}
