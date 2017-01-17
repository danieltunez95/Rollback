using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Spell
{
    public string name;
    public string description;
    public KeyCode key;
    public GameObject gameObject;
    public string prefab;

    public float castTime;
    public float enhanceTime;
    public float timer;
    public float cooldown;
    public int damage;
    public bool isAOE;
    public float AOERadius;
    public float AOEReduction;

    private float actualTime;
    private float actualCooldown;

    public Texture2D icon;
    public Texture2D iconCD;

    public Spell()
    {
        this.timer = 0;
    }
    public Spell(string name
        , float castTime
        , float enhanceTime
        , float cooldown
        , KeyCode key
        , Texture2D icon
        , Texture2D iconCD)
    {
        this.name = name;
        this.castTime = castTime;
        this.enhanceTime = enhanceTime;
        this.cooldown = cooldown;
        this.key = key;
        this.icon = icon;
        this.iconCD = iconCD;
        this.timer = 0;
    }
}

