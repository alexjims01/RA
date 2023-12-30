using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPeces : MonoBehaviour
{
    private float swimSpeed;       // Adjust the swim speed as needed
    private float rotationSpeed;   // Adjust the rotation speed as needed
    private float circleRadius;    // Adjust the radius of the circle

    private float angle = 0f;
    private int direction = 1;

    void Start()
    {
        swimSpeed = Random.Range(1f, 2f);            
        rotationSpeed = Random.Range(0.5f, 2f);        
        circleRadius = Random.Range(0.5f, 4f); 

        float initialX = Mathf.Cos(angle) * circleRadius;
        float initialZ = Mathf.Sin(angle) * circleRadius;

        transform.position = new Vector3(initialX, transform.position.y, initialZ);

        direction = Random.Range(0, 2) * 2 - 1;
    }
    void Update()
    {
        // Calculate the new position in a circle
        float x = Mathf.Cos(angle) * circleRadius;
        float z = Mathf.Sin(angle) * circleRadius;


        // Set the new position
        transform.position = new Vector3(x, transform.position.y, z);

        angle += rotationSpeed * Time.deltaTime * direction;

        // Limitar el ángulo dentro de un rango específico (por ejemplo, 0 a 360 grados)
        if (angle >= 360f)
        {
            angle -= 360f;
        }

        // Rotate the fish to face the direction of motion
        if(direction == 1)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(x, 0f, z));
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(-x, 0f, -z));
        }

        // Optionally, you can add the forward movement
        // transform.Translate(Vector3.forward * swimSpeed * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, circleRadius);
    }
}