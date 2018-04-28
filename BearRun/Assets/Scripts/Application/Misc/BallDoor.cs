using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDoor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    int itest = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.ball)
        {
            other.transform.parent.parent.SendMessage("HitBallDoor", SendMessageOptions.RequireReceiver);
            gameObject.transform.parent.parent.SendMessage("GetGoal", (int)other.transform.position.x);
            itest++;
            Debug.Log("Got Count: " + itest);
        }
    }
}
