using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onion : MonoBehaviour, IIngredient {


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject controllerEffect()
    {
        return Instantiate(gameObject);
    }

    public GameObject sandwichEffect()
    {
        throw new System.NotImplementedException();
    }
}
