using UnityEngine;
using System.Collections;

public class MoveWall : MonoBehaviour {
    public Transform target;
    
    private float speed = 1.0f;
	private bool movementStarted = false;

    public void initialize(float time)
    {
        var distance = Vector3.Distance(transform.position, target.position);
        speed = distance / time;
    }

	public void startMovement()
	{
        movementStarted = true;
    }

    public void stopMovement()
    {
        movementStarted = false;
    }

	void Update ()
    {
		if (movementStarted) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target.position, step);
		}
	}
}
