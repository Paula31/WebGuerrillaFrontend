using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGuerrillaFrontEnd.Models
{
	public class Resources
	{

		private int oil;
		public int Oil
		{
			get
			{
				return oil;
			}
			set
			{
				if (value < 0) throw new Exception("El aceite en Recursos debe ser positivo.");
				oil = value;
			}
		}

		private int money;
		public int Money
		{
			get
			{
				return money;
			}
			set
			{
				if (value < 0) throw new Exception("El dinero en Recursos debe ser positivo.");
				money = value;
			}
		}

		private int people;
		public int People
		{
			get
			{
				return people;
			}
			set
			{
				if (value < 0) throw new Exception("Las personas en Recursos debe ser positivo.");
				people = value;
			}
		}
	}
}