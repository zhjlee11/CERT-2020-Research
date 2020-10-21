using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLinear : MonoBehaviour
{
    public GameObject ManagerObject;
    private ManagerScript _managerScript;
    
    private float power;
    private Vector3 selfPos;
    private Transform selfTr;
    private float RealparT;
    
    public GameObject piece;
    public GameObject linearParent;
    
    private bool stopmove = false;

    
    // Start is called before the first frame update
    void Start()
    {
        selfTr = GetComponent<Transform>();
        ManagerObject = GameObject.Find("Manager");
        _managerScript = ManagerObject.GetComponent<ManagerScript>();
        power = _managerScript.getSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_managerScript.canMove)
        {
            return;
        }
        
        if (stopmove)
        {
            return;
        }
        
        Debug.Log(gameObject.transform.position.y);

        if (isSimilar(gameObject.transform.position.y, -2, _managerScript.getDeltaNum()))
        {
            Debug.Log("Draw 완료");
            stopmove = true;
            return;
        }
        
        GameObject pice = Instantiate(piece, gameObject.transform.position, gameObject.transform.rotation);
        pice.transform.parent = linearParent.transform;
        
        selfPos = selfTr.position;
        RealparT += Time.deltaTime;

        float parT = RealparT * power;

        float x = parT;
        float y = -2.0f*parT/Mathf.PI;

        Vector3 newVector = new Vector3(x, y, selfPos.z);
        StartCoroutine(MoveTo(gameObject, newVector));
    }
    
    
    public bool isSimilar(float x1, float x2, float loss)
    {
        float sub = x1 - x2;
        if (sub < 0.0f)
        {
            sub *= -1.0f;
        }

        //Debug.Log(sub);
        if (sub<=loss)
        {
            return true;
        } else
        {
            return false;
        }
    }
    
    IEnumerator MoveTo(GameObject a, Vector3 toPos)
    {
        float count = 0;
        Vector3 wasPos = a.transform.position;
        while (true)
        {
            count += Time.deltaTime;
            a.transform.position = Vector3.Lerp(wasPos, toPos, count);

            if (count >= 1)
            {
                a.transform.position = toPos;
                break;
            }
            yield return null;
        }
    }
}
