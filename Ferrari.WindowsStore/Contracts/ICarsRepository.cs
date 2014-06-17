using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ferrari.Models;
using Ferrari.Repositories;

namespace Ferrari.Contracts
{
	public interface ICarsRepository
	{
		List<Car> GetAll();
	}
}
