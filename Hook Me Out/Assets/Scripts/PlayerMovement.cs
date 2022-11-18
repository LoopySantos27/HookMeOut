
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    Rigidbody2D rigiBody;
    public float jumpForce;
    private bool canJump;
    public LayerMask layerGround;

    private Vector3 _joystickAxis;
    [SerializeField]
    private PlayerInput _playerInput;
    

    // Start is called before the first frame update
    void Start()
    {
        rigiBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");

        //Vector2 movement = new Vector2 (_joystickAxis.x,0);
        Vector2 movement = new Vector2 (horizontalInput,0);
        movement.Normalize();

        transform.Translate(movement * movementSpeed * Time.deltaTime);

       

        RaycastHit2D HitGround;
        Debug.DrawRay(transform.position, Vector2.down *  1f, Color.red);
        if(Physics2D.Raycast(transform.position, Vector2.down , 1.5f, layerGround))
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                print(Input.GetKey(KeyCode.Joystick1Button0));
                AudioManager.instance.Play("JumpSound");
                rigiBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
        
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("DeathArea"))
        {
            AudioManager.instance.Play("Lose");
        }
    }

    public void MovementPlayer(InputAction.CallbackContext context)
    {
        //_joystickAxis = context.ReadValue<Vector2>();
        
    }
}
