using UnityEngine;
using System.Collections;

public class StartWallMovement : MonoBehaviour 
{
    public MoveWall wall1;
    public MoveWall wall2;
    public float movementTime = 20f;
    public int numStopWallMovement = 0;
    public float waitTime = 3f;
    public float shakeDuration;
    public float shakeMagnitude;

    private int stopTime;
    private bool triggered = false; //ensures event is only triggered once

    void OnTriggerEnter (Collider other)
    {
        if (!triggered)
        {
            wall1.initialize(movementTime);
            wall2.initialize(movementTime);

            wall1.startMovement();
            wall2.startMovement();
            StartCoroutine(ShakeCamera());

            StartCoroutine(StopWalls());
            
            triggered = true;
        }
    }

    private IEnumerator StopWalls()
    {
        var timeSpentMoving = 0f;
        if(numStopWallMovement > 0)
        {
            timeSpentMoving = movementTime / (numStopWallMovement + 1);
        }
        else
        {
            timeSpentMoving = movementTime;
        }
        for(var i = 0; i < numStopWallMovement; i++)
        {
            yield return new WaitForSeconds(timeSpentMoving);
            wall1.stopMovement();
            wall2.stopMovement();
            StartCoroutine(ShakeCamera());
            yield return new WaitForSeconds(waitTime);
            wall1.startMovement();
            wall2.startMovement();
            StartCoroutine(ShakeCamera());
        }

        yield return new WaitForSeconds(timeSpentMoving);
        wall1.stopMovement();
        wall2.stopMovement();
        Application.LoadLevel("DiscoVR");
        //StartCoroutine(ShakeCamera());
    }

    private IEnumerator ShakeCamera()
    {
        float elapsed = 0.0f;

        Vector3 originalCamPos = Camera.main.transform.position;


        float x = 0;
        float y = 0;
        float z = 0;

        while (elapsed < shakeDuration)
        {
            originalCamPos = Camera.main.transform.position;

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / shakeDuration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            x = Random.value * 2.0f - 1.0f;
            y = Random.value * 2.0f - 1.0f;
            z = Random.value * 2.0f - 1.0f;
            x *= shakeMagnitude * damper;
            y *= shakeMagnitude * damper;
            z *= shakeMagnitude * damper;

            Camera.main.transform.position = new Vector3(originalCamPos.x + x, originalCamPos.y + y, originalCamPos.z);

            yield return null;
        }

        Camera.main.transform.position = originalCamPos;
    }
}
