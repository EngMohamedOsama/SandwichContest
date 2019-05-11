using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salad : MonoBehaviour,IIngredient {
    [SerializeField] private GameObject sandwichObject;

    public GameObject controllerEffect()
    {
        return Instantiate(gameObject);
    }

    public GameObject sandwichEffect()
    {
        return Instantiate(sandwichObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
