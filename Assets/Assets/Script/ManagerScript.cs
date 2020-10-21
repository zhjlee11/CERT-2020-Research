using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public int cycloidScore = 0;
    public int sinScore = 0;
    public int linearScore = 0;

    public bool canMove = true;
    private bool doAlreadyPrint = false;
    public double timer;

    private float deltaNum = 0.000075f;
    private float speed  = 0.005f;

    public float getDeltaNum()
    {
        return deltaNum;
    }

    public float getSpeed()
    {
        return speed;
    }

    void Update() {
        if (this.timer > 0) {
            this.timer -= Time.deltaTime;
        } else {
            this.canMove = false;
            if (!this.doAlreadyPrint) {
                Debug.Log("Cycloid : " + this.cycloidScore);
                Debug.Log("Sin : " + this.sinScore);
                Debug.Log("Linear : " + this.linearScore);

                this.doAlreadyPrint = true;
            }
        }
    }

}
