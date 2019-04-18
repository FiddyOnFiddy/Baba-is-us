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

    public Vector2 dir;

    public float left = -1.0f;
    public float right = 1.0f;
    public float up = 1.0f;
    public float down = -1.0f;

    public Rigidbody2D rb;


    void Start()
    {
        desiredPosition = transform.position;

        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerMovement();
        BoxMovement();

        //transform.position = Vector3.Lerp(transform.position, desiredPosition, interpolationSpeed * Time.deltaTime);

        rb.MovePosition(Vector3.Lerp(transform.position, desiredPosition, interpolationSpeed * Time.deltaTime));

        

       // Debug.Log(dir);

        if(box != null)
        {

            dir = (gameObject.transform.position - box.transform.position).normalized;

            box.transform.position = Vector3.Lerp(box.transform.position, boxDesiredPosition, boxInterpolationSpeed * Time.deltaTime);


        }


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
            if (Input.GetAxisRaw("Horizontal") < 0.0f)
            {
                desiredPosition += Vector3.left;
                timestamp = Time.time + timeBetweenMoves;
            }
            if (Input.GetAxisRaw("Vertical") > 0.0f)
            {
                desiredPosition += Vector3.up;
                timestamp = Time.time + timeBetweenMoves;
            }
            if (Input.GetAxisRaw("Vertical") < 0.0f)
            {
                desiredPosition += Vector3.down;
                timestamp = Time.time + timeBetweenMoves;
            }
        }
    }

    void BoxMovement()
    {
        /* 
         *RaycastHit2D hitRight = Physics2D.Raycast(gameObject.transform.position, Vector2.right, 0.5f);
         Debug.DrawRay(gameObject.transform.position, Vector3.right / 2, Color.white);

         if(hitRight.collider != null)
         {
             if (hitRight.collider.tag == "Box" && Input.GetAxisRaw("Horizontal") > 0.0f)
             {
                 boxPosition = hitRight.collider.transform.position;
                 boxPosition += Vector3.right;
                 hitRight.collider.transform.position = boxPosition;
             }
         }

         RaycastHit2D hitLeft = Physics2D.Raycast(gameObject.transform.position, Vector2.left, 0.5f);
         Debug.DrawRay(gameObject.transform.position, Vector3.left / 2, Color.white);

         if (hitLeft.collider != null)
         {
             if (hitLeft.collider.tag == "Box" && Input.GetAxisRaw("Horizontal") < 0.0f)
             {
                 boxPosition = hitLeft.collider.transform.position;
                 boxPosition += Vector3.left;
                 hitLeft.collider.transform.position = boxPosition;
             }
         }

         RaycastHit2D hitUp = Physics2D.Raycast(gameObject.transform.position, Vector2.up, 0.5f);
         Debug.DrawRay(gameObject.transform.position, Vector3.up / 2, Color.white);

         if (hitUp.collider != null)
         {
             if (hitUp.collider.tag == "Box" && Input.GetAxisRaw("Vertical") > 0.0f)
             {
                 boxPosition = hitUp.collider.transform.position;
                 boxPosition += Vector3.up;
                 hitUp.collider.transform.position = boxPosition;
             }
         }

         RaycastHit2D hitDown = Physics2D.Raycast(gameObject.transform.position, Vector2.down, 0.5f);
         Debug.DrawRay(gameObject.transform.position, Vector3.down / 2, Color.white);

         if (hitDown.collider != null)
         {
             if (hitDown.collider.tag == "Box" && Input.GetAxisRaw("Vertical") < 0.0f)
             {
                 boxPosition = hitDown.collider.transform.position;
                 boxPosition += Vector3.down;
                 hitDown.collider.transform.position = boxPosition;
             }
         }
         */



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
           // dir = (gameObject.transform.position - collision.transform.position).normalized;

            boxDesiredPosition = collision.gameObject.transform.position;
            box = collision.gameObject;
        
            if (Mathf.Approximately(dir.x, left))
            {
                boxDesiredPosition += Vector3.right;
                //collision.gameObject.transform.position = boxDesiredPosition;
                Debug.Log(dir);
            }

            if (Mathf.Approximately(dir.x, right))
            {
                boxDesiredPosition += Vector3.left;
                //collision.gameObject.transform.position = boxDesiredPosition;
            }
            if (Mathf.Approximately(dir.y, up))
            {
                boxDesiredPosition += Vector3.down;
                //collision.gameObject.transform.position = boxDesiredPosition;
            }
            if (Mathf.Approximately(dir.y, down))
            {
                boxDesiredPosition += Vector3.up;
                //collision.gameObject.transform.position = boxDesiredPosition;
            }


        }
    }
}


