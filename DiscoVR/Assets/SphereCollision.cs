using UnityEngine;
using System.Collections;

public class SphereCollision : MonoBehaviour {

    public int level = 1;

    void OnTriggerEnter(Collider col)
    {
        Application.LoadLevel(level);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
