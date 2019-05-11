using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    public bool release = false;
    private Transform InstantiatedItem = null;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z) ||  OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)  )
        {

            var colliders = Physics.OverlapSphere(transform.position, 1f);
            if (colliders.Length == 0) return;
            IIngredient pickedItem = null;
            for (int i = 0; i < colliders.Length; i++)
            {
              
                pickedItem = colliders[i].GetComponent<IIngredient>();
                if (pickedItem != null) break;
              
            }
            if (pickedItem == null) return;

            InstantiatedItem = pickedItem.controllerEffect().transform;
            InstantiatedItem.SetParent(this.transform);
            InstantiatedItem.localScale = new Vector3(3f, 3f, 3f);
            InstantiatedItem.localPosition = Vector3.zero;
            InstantiatedItem.GetComponent<Rigidbody>().isKinematic = true;
            InstantiatedItem.GetComponent<Collider>().isTrigger = true;
        }
        if (Input.GetKeyUp(KeyCode.Z) ||  OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)  || release == true || Input.GetKeyDown(KeyCode.X))
        {
            if (InstantiatedItem == null) return;
            InstantiatedItem.SetParent(null);
            InstantiatedItem.GetComponent<Rigidbody>().isKinematic = false;
            InstantiatedItem.GetComponent<Collider>().isTrigger = false;
            release = false;


        }
    }
}
