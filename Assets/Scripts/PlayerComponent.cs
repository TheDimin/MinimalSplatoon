using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent : MonoBehaviour
{
    [SerializeField] Color color;
    [SerializeField] int playerIndex = 1;
    [SerializeField] float maxSpeed = 10;
    [SerializeField] float accelerator = 1;
    [SerializeField] float Drag = 4;
    [SerializeField] Vector2 velocity = new Vector2();
    private Transform transform;


    void Start()
    {
        transform = GetComponent<Transform>();
    }



    void Update()
    {

        Vector2 input = new Vector2(Input.GetAxis("Horizontal" + playerIndex), Input.GetAxis("Vertical" + playerIndex));
        velocity += input.normalized * accelerator;

        if (velocity.magnitude > maxSpeed)
            velocity = velocity.normalized * new Vector2(maxSpeed, maxSpeed);

        if (velocity.magnitude < -maxSpeed)
            velocity = velocity.normalized * new Vector2(-maxSpeed, -maxSpeed);

        transform.position += (new Vector3(velocity.x, velocity.y) * Time.deltaTime);

        bool pos = velocity.magnitude > 0;

        for (int i = 0; i < 2; i++)
            if (velocity[i] > 0)
            {
                velocity[i] -= Drag;
                if (velocity[i] < 0)
                    velocity[i] = 0;
            }
            else if (velocity[i] < 0)
            {
                velocity[i] += Drag;
                if (velocity[i] > 0)
                    velocity[i] = 0;
            }
    }
}