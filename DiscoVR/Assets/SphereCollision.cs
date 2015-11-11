using UnityEngine;
using System.Collections;

public class SphereCollision : MonoBehaviour {


    void OnTriggerEnter(Collider col)
    {
        Application.LoadLevel(1);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
