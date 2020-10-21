using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isArrived : MonoBehaviour
{
    public GameObject ManagerObject;
    private ManagerScript _managerScript;

    public GameObject cycloidPrefab;
    public GameObject sinPrefab;
    public GameObject linearPrefab;

    // Start is called before the first frame update
    void Start()
    {
        _managerScript = ManagerObject.GetComponent<ManagerScript>();
    }

    void OnTriggerEnter(Collider other)
    {
        string name = other.gameObject.tag;
        if (name == "Cycloid")
        {
            _managerScript.cycloidScore += 1;
            Destroy(other.gameObject);
            Instantiate(cycloidPrefab, new Vector3(0.01f, 0, 0), new Quaternion(0, 0, 0, 0));
            //Debug.Log("Cycloid : " );
        } else if (name == "Sin")
        {
            _managerScript.sinScore += 1;
            Destroy(other.gameObject);
            Instantiate(sinPrefab, new Vector3(0.01f, 0, 5.05f), new Quaternion(0, 0, 0, 0));
            //Debug.Log("Sin : " );
        } else if (name == "Linear")
        {
            _managerScript.linearScore += 1;
            Destroy(other.gameObject);
            Instantiate(linearPrefab, new Vector3(0.01f, 0, -5.05f), new Quaternion(0, 0, 0, 0));
            //Debug.Log("Linear : ");
        }
    }
}
