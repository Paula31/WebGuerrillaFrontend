using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGuerrillaFrontEnd.Models
{
	public class Buildings
	{
		public Buildings(int bunker)
		{
			Bunker = bunker;
		}

		public Buildings()
		{
		}
		private int bunker = 0;
		public int Bunker
		{
			get
			{
				return bunker;
			}
			set
			{
				if (value < 0) throw new Exception("Los en building debe ser positivo.");
				bunker = value;
			}
		}

	}
}