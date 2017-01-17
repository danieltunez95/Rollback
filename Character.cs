using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    GameObject character;
    public bool isEnemy;
    public bool isFriendly;
    public int health;
   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
            Destroy(character);
	}

    public void Damage(int dmg)
    {
        health -= dmg;
    } 

    public void Heal(int heal)
    {
        health += heal;
    }
}
