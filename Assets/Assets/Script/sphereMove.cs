using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class sphereMove : MonoBehaviour
{

    public GameObject ManagerObject;
    private ManagerScript _managerScript;
    private Rigidbody rigidbody;

    void Start()
    {
        _managerScript = GameObject.Find("Manager").GetComponent<ManagerScript>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        

        if (_managerScript.canMove == false) {
            //Debug.Log("Shutdown Physix Engine");
            rigidbody.velocity = new Vector3(0, 0, 0);
            rigidbody.angularVelocity = new Vector3(0, 0, 0);
            rigidbody.useGravity = false;
        }
    }
}

