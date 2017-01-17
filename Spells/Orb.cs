using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Orb : Photon.MonoBehaviour
{
    private static Vector3 destination;
    private static Vector3 actualPosition;
    private static float speed = 0.20f;
    public static GameObject orb;
    private static Spell orbSpell;
    private static Vector3 startPosition;

    public static void InitializeOrb(Vector3 startPosition, Vector3 endPosition, Spell orbSpell)
    {
        startPosition.y = 1f;
        endPosition.y = 1f;
        destination = endPosition;
        orb.transform.position = startPosition;
        orb.transform.LookAt(destination);
    }

    void Start()
    {
        destination = Helper.GetMousePosition();
    }

    void Update()
    {
        if (orb != null && destination != null)
            UpdatePosition();
    }

    public void UpdatePosition()
    {
        actualPosition = Vector3.MoveTowards(orb.transform.position, destination, speed);
        actualPosition.y = 1f;

        orb.transform.position = actualPosition;
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.tag.ToLower() == "enemy")
        {
            other.transform.SendMessage("Damage", 50);
        }
    }
}

