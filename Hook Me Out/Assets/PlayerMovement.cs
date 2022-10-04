using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    Rigidbody2D rigiBody;
    public float jumpForce;
    private bool canJump;
    public LayerMask layerGround;

    // Start is called before the first frame update
    void Start()
    {
        rigiBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * (Time.deltaTime * movementSpeed), Space.World);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * (Time.deltaTime * movementSpeed),Space.World);
        }

        RaycastHit2D HitGround;
        Debug.DrawRay(transform.position, Vector2.down *  1f, Color.red);
        if(Physics2D.Raycast(transform.position, Vector2.down , 1.5f, layerGround))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigiBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
        
    }
}
