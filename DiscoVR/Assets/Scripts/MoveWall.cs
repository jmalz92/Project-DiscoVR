using UnityEngine;
using System.Collections;

public class MoveWall : MonoBehaviour {
    public Transform target;
    public float speed = 1.0f;

	void Update ()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}
}
