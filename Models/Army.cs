using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGuerrillaFrontEnd.Models
{
	public class Army
	{

		public Army(int assault, int engineer, int tank)
		{
			Assault = assault;
			Engineer = engineer;
			Tank = tank;
		}

		public Army()
		{

		}
		private int assault = 0;
		public int Assault
		{
			get
			{
				return assault;
			}
			set
			{
				if (value < 0) throw new Exception("Los asaltos en Armamento debe ser positivo.");
				assault = value;
			}
		}

		private int engineer = 0;
		public int Engineer
		{
			get
			{
				return engineer;
			}
			set
			{
				if (value < 0) throw new Exception("Los ingenieros en Armamento debe ser positivo.");
				engineer = value;
			}
		}

		private int tank = 0;
		public int Tank
		{
			get
			{
				return tank;
			}
			set
			{
				if (value < 0) throw new Exception("Los tanques en Armamento debe ser positivo.");
				tank = value;
			}
		}
	}
}