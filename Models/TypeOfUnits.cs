using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGuerrillaFrontEnd.Models
{
	public class TypeOfUnit
	{

		public TypeOfUnit(int idTipeOfUnit, string nameTypeOfUnit, int loot, int ofense, int defense, int quantity)
		{
			if (idTipeOfUnit <= 0) throw new Exception("El id del Tipo Unidad debe ser positivo.");
			if (string.IsNullOrEmpty(nameTypeOfUnit)) throw new Exception("Nombre del Tipo Unidad es requerido.");
			if (loot < 0) throw new Exception("El pillaje Tipo Unidad debe ser positivo.");
			if (ofense < 0) throw new Exception("La ofensa de Tipo Unidad debe ser positivo.");
			if (defense < 0) throw new Exception("La defensa de Tipo Unidad debe ser positivo.");
			if (quantity < 0) throw new Exception("La cantidad de Tipo Unidad debe ser positivo.");


			IdTipeOfUnit = idTipeOfUnit;
			NameUnit = nameTypeOfUnit;
			Loot = loot;
			Ofense = ofense;
			Defense = defense;
			Quantity = quantity;
		}

		//Contructor que se usara para la actualizacion de las unidades despues de una batalla.
		public TypeOfUnit(int idTipeOfUnit, int quantity)
		{
			if (idTipeOfUnit <= 0) throw new Exception("El id del Tipo Unidad debe ser positivo.");
			if (quantity <= 0) throw new Exception("La cantidad de Tipo Unidad debe ser positivo.");

			IdTipeOfUnit = idTipeOfUnit;
			Quantity = quantity;
		}

		private int idTipeOfUnit;
		public int IdTipeOfUnit
		{
			get
			{
				return idTipeOfUnit;
			}
			set
			{
				if (value <= 0) throw new Exception("El id del tipo unidad debe ser positivo.");
				idTipeOfUnit = value;
			}
		}

		private string nameUnit;
		public string NameUnit
		{
			get
			{
				return nameUnit;
			}
			set
			{
				if (string.IsNullOrEmpty(value)) throw new Exception("Nombre del tipo de unidad es requerido.");
				nameUnit = value;
			}
		}

		private int loot;
		public int Loot
		{
			get
			{
				return loot;
			}
			set
			{
				if (value < 0) throw new Exception("El pillaje al tipo unidad debe ser positivo.");
				loot = value;
			}
		}

		private int ofense;
		public int Ofense
		{
			get
			{
				return ofense;
			}
			set
			{
				if (value < 0) throw new Exception("La Ofensa de unidad debe ser positivo.");
				ofense = value;
			}
		}

		private int defense;
		public int Defense
		{
			get
			{
				return defense;
			}
			set
			{
				if (value < 0) throw new Exception("La defensa de unidad debe ser positivo.");
				defense = value;
			}
		}

		private int quantity;
		public int Quantity
		{
			get
			{
				return quantity;
			}
			set
			{
				if (value < 0) throw new Exception("La cantidad de unidad debe ser positivo.");
				quantity = value;
			}
		}

	



		private int costMoney;
		public int CostMoney
		{
			get
			{
				return costMoney;
			}
			set
			{
				if (value < 0) throw new Exception("El costo de tipo unidad debe ser positivo.");
				costMoney = value;
			}
		}

		private int costPeople;
		public int CostPeople
		{
			get
			{
				return costPeople;
			}
			set
			{
				if (value < 0) throw new Exception("El costo de personas de tipo unidad debe ser positivo.");
				costPeople = value;
			}
		}

		private int costOil;
		public int CostOil
		{
			get
			{
				return costOil;
			}
			set
			{
				if (value < 0) throw new Exception("El costo de petroleo de tipo unidad debe ser positivo.");
				costOil = value;
			}
		}
	}
}