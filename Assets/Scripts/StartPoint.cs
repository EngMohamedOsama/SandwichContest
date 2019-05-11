using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour {
    private ParticleSystem pointEffect;
    private ContestManager contestManager;
	// Use this for initialization
	void Start () {
        pointEffect = GetComponentInChildren<ParticleSystem>();
        contestManager = GameObject.Find("ContestManager").GetComponent<ContestManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (contestManager.ContestState()) return;
            contestManager.StartContest();
            pointEffect.Stop();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            pointEffect.Play();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            pointEffect.Stop();
        }
    }
}
