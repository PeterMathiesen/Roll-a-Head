using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    private Rigidbody target;

    // Use this for initialization
    void Start ()
    {
        target = GetComponent<Rigidbody>();
        MoveToNewPosition();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MoveToNewPosition()
    {
        target.velocity = Vector3.zero;
        target.position = new Vector3(Random.Range(-8.0f, 8.0f), 2.0f, Random.Range(-5.0f, -8.0f));
        target.position = new Vector3(Random.Range(-8.0f, 8.0f), 2.0f, Random.Range(5.0f, 8.0f));
    }
}
