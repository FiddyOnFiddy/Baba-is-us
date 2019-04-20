using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float timeBetweenMoves = 0.3333f;
    private float timestamp;
    public float interpolationSpeed = 10.0F;
    public float boxInterpolationSpeed = 10.0F;

    public Vector3 desiredPosition;
    public Vector3 boxDesiredPosition;
    public GameObject box;

    public Rigidbody2D rb;


    void Start()
    {
        desiredPosition = transform.position;

        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerMovement();
        transform.position = Vector3.Lerp(transform.position, desiredPosition, interpolationSpeed * Time.deltaTime);
        

        if(box != null)
        {
            box.transform.position = Vector3.Lerp(box.transform.position, boxDesiredPosition, boxInterpolationSpeed * Time.deltaTime);
        }

        Mathf.Round(boxDesiredPosition.x);
        Mathf.Round(boxDesiredPosition.y);

        


    }

    void PlayerMovement()
    {
        if (Time.time >= timestamp)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.0f)
            {
                desiredPosition += Vector3.right;
                timestamp = Time.time + timeBetweenMoves;
            }
            else if (Input.GetAxisRaw("Horizontal") < 0.0f)
            {
                desiredPosition += Vector3.left;
                timestamp = Time.time + timeBetweenMoves;
            }
            else if (Input.GetAxisRaw("Vertical") > 0.0f)
            {
                desiredPosition += Vector3.up;
                timestamp = Time.time + timeBetweenMoves;
            }
            else if (Input.GetAxisRaw("Vertical") < 0.0f)
            {
                desiredPosition += Vector3.down;
                timestamp = Time.time + timeBetweenMoves;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            boxDesiredPosition = collision.gameObject.transform.position;
            box = collision.gameObject;

            if (Input.GetAxisRaw("Horizontal") > 0.0f)
            {
                boxDesiredPosition += Vector3.right;
            }
            if (Input.GetAxisRaw("Horizontal") < 0.0f)
            {
                boxDesiredPosition += Vector3.left;
            }
            if (Input.GetAxisRaw("Vertical") > 0.0f)
            {
                boxDesiredPosition += Vector3.up;
            }
            if (Input.GetAxisRaw("Vertical") < 0.0f)
            {
                boxDesiredPosition += Vector3.down;
            }
            Mathf.Round(box.transform.position.x);
            Mathf.Round(box.transform.position.y);
        }
    }
}


