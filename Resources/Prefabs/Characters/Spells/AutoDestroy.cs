using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {

    public GameObject obj;
    public float destroyTime;
    private float actualTime;

	// Use this for initialization
	void Start ()
    {
        actualTime = destroyTime;
    }
	
	// Update is called once per frame
	void Update ()
    {
        actualTime -= Time.deltaTime;
        if (actualTime <= 0)
            Destroy(obj);
    }
}
