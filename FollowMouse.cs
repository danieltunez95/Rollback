using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour {

    public GameObject obj;
    public ParticleSystem areaParticle;

	// Use this for initialization
	void Start ()
    {
        //areaParticle.Stop();
    }
	
	// Update is called once per frame
	void Update () {
            Vector3 position = Input.mousePosition;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000))
            {
                position.x = hit.point.x;
                position.y = 0.1f;
                position.z = hit.point.z;
            }
            obj.transform.position = position;
	}
}
