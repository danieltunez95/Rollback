using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayer : Photon.MonoBehaviour {
    public GameObject myCamera;

	// Use this for initialization
	void Start ()
    {
        if (photonView.isMine)
        {
            myCamera.SetActive(true);
            GetComponent<ClickToMove>().enabled = true;
            GetComponent<SpellManager>().enabled = true;
            GetComponent<PlayerManager>().enabled = true;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
    }
}
