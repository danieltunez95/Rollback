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

public class Enemigo : MonoBehaviour {

	public Npc npc1;

	void Awake ()	{

		// Hace un array de GameObjects por su tag.
		GameObject[] enemigos = GameObject.FindGameObjectsWithTag ("Enemigo");
		//Debug.Log ("Tengo enemigos en pantalla: " + enemigos.Length + " : " + enemigos[0]);
		npc1 = new Npc (enemigos[0].name, enemigos[0].tag);
	}
		
	void Start () {
		Debug.Log ("Este NPC se llama: " + npc1.nombre + "y es :" + npc1.reaccion);
	}

	void Update () {
		
	}

}
