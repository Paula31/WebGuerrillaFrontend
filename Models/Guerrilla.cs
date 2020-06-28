using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGuerrillaFrontEnd.Models
{

	public class Guerrillas
	{
		private GuerrillaCompleted[] guerrillas;
		public GuerrillaCompleted[] GuerrillasC
		{
			get
			{
				return guerrillas;
			}
			set
			{
				if (value == null) throw new Exception("Guerilla Completed en guerrilas es requerido.");
				guerrillas = value;
			}
		}

		private Results[] results;
		public Results[] Results
		{
			get
			{
				return results;
			}
			set
			{
				if (value == null) throw new Exception("Guerilla Completed en guerrilas es requerido.");
				results = value;
			}
		}
	}


	public class GuerrillaAll
	{
		private string guerrillaName;
		public string GuerrillaName
		{
			get
			{
				return guerrillaName;
			}
			set
			{
				if (string.IsNullOrEmpty(value)) throw new Exception("Nombre de la guerrillaAll es requerido.");
				guerrillaName = value;
			}
		}

		public string faction;
		public string Faction
		{
			get
			{
				return faction;
			}
			set
			{
				if (string.IsNullOrEmpty(value)) throw new Exception("Faction de la guerrillaAll es requerido.");
				faction = value;
			}
		}

		private int rank;
		public int Rank
		{
			get
			{
				return rank;
			}
			set
			{
				if (value < 0) throw new Exception("La posicion rankin GuerrillaAll debe ser positivo.");
				rank = value;
			}
		}
	}

	public class GuerrillaCompleted
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
				if (string.IsNullOrEmpty(value)) throw new Exception("Nombre de la guerrillaCompleted es requerido.");
				name = value;
			}
		}

		private string email;
		public string Email
		{
			get
			{
				return email;
			}
			set
			{
				if (string.IsNullOrEmpty(value)) throw new Exception("email de la guerrillaCompleted es requerido.");
				email = value;
			}
		}

		private int rank;
		public int Rank
		{
			get { return rank; }
			set
			{
				if (value < 0) throw new Exception("El rank en GuerrillaCompleted debe ser igual o mayor a.");
				rank = value;
			}
		}

		private string faction;
		public string Faction
		{
			get
			{
				return faction;
			}
			set
			{
				if (string.IsNullOrEmpty(value)) throw new Exception("faction de la guerrillaCompleted es requerido.");
				faction = value;
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
				if (null == value) throw new Exception("Recursos de la guerrillaCompleted es requerido.");
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
				if (null == value) throw new Exception("buildings de la guerrillaCompleted es requerido.");
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
				if (null == value) throw new Exception("army de la guerrillaCompleted es requerido.");
				army = value;
			}
		}
	}

	public class Guerrilla
	{
		public Guerrilla(int idGuerrilla, string email, string guerrillaName, int rank, int ofense, int defense, double iA, double id,
			int money = 300, int people = 50, int oil = 300)
		{
			IdGuerrilla = idGuerrilla;
			GuerrillaName = guerrillaName;
			Email = email;
			Rank = rank;
			Ofense = ofense;
			Defense = defense;
			IA = iA;
			ID = id;
			Money = money;
			People = people;
			Oil = oil;
			typeOfUnits = new List<TypeOfUnit>();
		}

		public Guerrilla(int idGuerrilla, string email, string nameGuerrilla, string faction, int rank = 0, int money = 300, int people = 50, int oil = 300)
		{
			IdGuerrilla = idGuerrilla;
			GuerrillaName = nameGuerrilla;
			Email = email;
			Faction = faction;
			Rank = rank;
			Money = money;
			People = people;
			Oil = oil;
			typeOfUnits = new List<TypeOfUnit>();
		}

		public Guerrilla()
		{
		}

		private int idGuerrilla;
		public int IdGuerrilla
		{
			get
			{
				return idGuerrilla;
			}
			set
			{
				if (value < 0) throw new Exception("La idguerrilla debe ser positivo.");
				idGuerrilla = value;
			}
		}

		public string guerrillaName;
		public string GuerrillaName
		{
			get
			{
				return guerrillaName;
			}
			set
			{
				if (string.IsNullOrEmpty(value)) throw new Exception("Nombre de la guerrilla es requerido.");
				guerrillaName = value;
			}
		}

		public string email;
		public string Email
		{
			get
			{
				return email;
			}
			set
			{
				//if (string.IsNullOrEmpty(value)) throw new Exception("El email de la guerrilla es requerido.");
				email = value;
			}
		}

		public int rank;
		public int Rank
		{
			get
			{
				return rank;
			}
			set
			{
				if (value < 0) throw new Exception("La posicio debe ser positivo.");
				rank = value;
			}
		}

		public string faction;
		public string Faction
		{
			get
			{
				return faction;
			}
			set
			{
				//if (string.IsNullOrEmpty(value)) throw new Exception("El faction de la guerrilla es requerido.");
				faction = value;
			}
		}

		private int money = 300;
		public int Money
		{
			get { return money; }
			set
			{
				if (value <= 0) throw new Exception("El dinero de la guerrilla debe ser positivo.");
				money = value;
			}
		}

		private int people = 50;
		public int People
		{
			get { return people; }
			set
			{
				if (value <= 0) throw new Exception("El recurso humano de la guerrilla debe ser positivo.");
				people = value;
			}
		}

		private int oil = 300;
		public int Oil
		{
			get { return oil; }
			set
			{
				if (value <= 0) throw new Exception("La cantidad de petroleo de la guerrilla debe ser positivo.");
				oil = value;
			}
		}

		private int ofense;
		public int Ofense
		{
			get { return ofense; }
			set
			{
				if (value < 0) throw new Exception("La cantidad de ataque de la guerrilla debe ser positivo.");
				ofense = value;
			}
		}

		private int defense;
		public int Defense
		{
			get { return defense; }
			set
			{
				if (value < 0) throw new Exception("La cantidad de defensa de la guerrilla debe ser positivo.");
				defense = value;
			}
		}

		private double iA;
		public double IA
		{
			get { return iA; }
			set
			{
				if (value < 0) throw new Exception("El indice de Ataque de la guerrilla debe ser positivo.");
				iA = value;
			}
		}

		private double iD;
		public double ID
		{
			get { return iD; }
			set
			{
				if (value < 0) throw new Exception("El indice de Defensa de la guerrilla debe ser positivo.");
				iD = value;
			}
		}

		private List<TypeOfUnit> typeOfUnits;

		public List<TypeOfUnit> ListTypeOfUnits()
		{
			return typeOfUnits;
		}

		public void AddTypeOfUnits(TypeOfUnit tipeUnit)
		{
			if (tipeUnit == null) throw new Exception("El tipo de unidad es requerido.");
			typeOfUnits.Add(tipeUnit);
		}

		public void TypeOfUnitsList(List<TypeOfUnit> tipeUnitList)
		{
			if (tipeUnitList == null) throw new Exception("La lista de tipo de unidad es requerido.");
			typeOfUnits = tipeUnitList;
		}
	}
}