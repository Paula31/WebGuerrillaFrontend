using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGuerrillaFrontEnd.Models
{
	public class Results
	{

		private string name;
		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				if (string.IsNullOrEmpty(value)) throw new Exception("Nombre de la results es requerido.");
				name = value;
			}
		}

		private Resources resources;
		public Resources Resources
		{
			get
			{
				return resources;
			}
			set
			{
				if (null == value) throw new Exception("Recursos de results es requerido.");
				resources = value;
			}
		}

		private Buildings buildings;
		public Buildings Buildings
		{
			get
			{
				return buildings;
			}
			set
			{
				if (null == value) throw new Exception("buildings de results es requerido.");
				buildings = value;
			}
		}

		private Army army;
		public Army Army
		{
			get
			{
				return army;
			}
			set
			{
				if (null == value) throw new Exception("army de results es requerido.");
				army = value;
			}
		}
	}
}