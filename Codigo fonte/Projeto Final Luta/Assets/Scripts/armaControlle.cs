using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armaControlle : MonoBehaviour {


	void Start () {
		
	}
	
	
    void Update () {
        transform.Rotate(0, 0, -800f * Time.deltaTime, Space.Self);

        if (transform.position.x > 13f || transform.position.x < -13f)
            Destroy(transform.gameObject);
    }
}
