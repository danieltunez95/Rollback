using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPoint : MonoBehaviour {
    /* TYPE
     * 0 = none
     * 1 = health
     * 2 = damage
     * 3 = defense
     */
    public int type;
    public float secondsToNeutralize;
    public float secondsToCapture;
    public GameObject point;
    private float actualSeconds = 0f;
    public Renderer rend;
    public ParticleSystem particles;

    /* team
     * 0 = none
     * 1 = team 1
     * n = team n
     */
    public int team;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		if (team != 0)
        {

        }
	}

    void OnTriggerStay(Collider other)
    {
        if (team == 0)
        {
            actualSeconds += Time.fixedDeltaTime;
            rend.material.SetColor("_EmissionColor", Color.red * actualSeconds / 15);
            if (actualSeconds > secondsToCapture)
            {
                team = 1;
                particles.Play();
            }
        }
    }
}
