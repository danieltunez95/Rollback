using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject enemy;

    public int healthBase;
    public int defenseBase;
    public int shieldBase;
    public int speedBase;
    public int damageBase;

    private int health;
    private int defense;
    private int shield;
    private int speed;
    private int damage;

    //timers
    private float stun;
    private float damageTime;
    private float speedTime;
    private float shieldTime;

	// Use this for initialization
	void Start () {
        stun = 0f;

        health = healthBase;
        defense = defenseBase;
        shield = shieldBase;
        speed = speedBase;
        damage = damageBase;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (stun > 0)
            stun -= Time.fixedDeltaTime;

        if (damageTime > 0)
            damageTime -= Time.fixedDeltaTime;
        else
            damage = damageBase;

        if (speedTime > 0)
            speedTime -= Time.fixedDeltaTime;
        else
            speed = speedBase;

        if (shieldTime > 0)
            shieldTime -= Time.fixedDeltaTime;
        else
            shield = shieldBase;
    }

    public void Damage(int quantity)
    {
        health -= quantity;

        if (health <= 0)
            Destroy(enemy);
    }
    public void Heal(int quantity)
    {
        health += quantity;
    }

    public void Shield(int quantity, float time)
    {
        shield += quantity;
        shieldTime = time;
    }

    public void IncreaseDamage(int percent, float time)
    {
        damage = damage + damage * percent / 100;
        damageTime = time;
    }

    public void DecreaseDamage(int percent, float time)
    {
        
    }

    public void IncreaseSpeed(int percent, float time)
    {

    }

    public void DecreaseSpeed(int percent)
    {

    }

    public void Stun(float seconds)
    {

    }
}
