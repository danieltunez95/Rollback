
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************************************************|
|*  Autor :  Marc Trallero García							*|
|*  Fecha : 26 - 11 - 2016						 			*|
|* **********************************************************|
|* **************  ÚLTIMA MODIFICACIÓN	*********************|
|* Pers. ||	Núm. mod ||				Fecha					*|
|* 		 ||			 ||										*|
|************************************************************/

///<summary>
///Clase principal de los NPC's.
///</summary>
///<remarks>
///Contiene los métodos y comportamientos principales de los NPC's.
///</remarks>
public class Npc
{
	// Variables de clase.
	public int vida = 100;
	public string reaccion = "Neutral";
	public string nombre = "";

	// Constructor.
	public Npc (string nombre, string reaccion)
	{
		
		this.nombre = nombre;
		this.reaccion = reaccion;

	}
		

}
