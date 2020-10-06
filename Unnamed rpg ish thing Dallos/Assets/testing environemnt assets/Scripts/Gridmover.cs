using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gridmover : MonoBehaviour
{

    Vector3 up = Vector3.zero,
    right = new Vector3(0, 90, 0),
    down = new Vector3(0, 180, 0),
    left = new Vector3(0, 270, 0),
    currentDir = Vector3.zero;

    Vector3 nextPos = Vector3.zero,
    destination = Vector3.zero,
    direction = Vector3.zero;

    bool canmove;
    
    private float speed = 5;

    void Start()
    {
        currentDir = up;
        nextPos = Vector3.forward;
        destination = transform.position;
    }

   
    void Update()
    {
        move();
    }


    void move()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            nextPos = Vector3.forward;
            currentDir = up;
            canmove = true;
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            nextPos = Vector3.back;
            currentDir = down;
            canmove = true;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            nextPos = Vector3.left;
            currentDir = left;
            canmove = true;
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            nextPos = Vector3.right;
            currentDir = right;
            canmove = true;
        }

        if (Vector3.Distance(destination,transform.position) <= 0.00001f)
        {
            transform.localEulerAngles = currentDir;

            if (canmove)
            {
                destination = transform.position + nextPos;
                canmove = !canmove;
            }
            
        }



    }


}
