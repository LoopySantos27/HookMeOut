
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    Rigidbody2D rigiBody;
    public float jumpForce;
    public bool hasJump = true;
    public LayerMask layerGround;

    public Vector3 _joystickAxisLeft;
    [SerializeField]
    private PlayerInput _playerInput;
    [SerializeField]
    private PlayerAnimations animations;


    // Start is called before the first frame update
    void Start()
    {
        rigiBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2 (_joystickAxisLeft.x,0);
        Debug.Log(_joystickAxisLeft.x);
       // Vector2 movement = new Vector2 (horizontalInput,0);
        movement.Normalize();

        transform.Translate(movement * movementSpeed * Time.deltaTime);

       
        Debug.DrawRay(transform.position, Vector2.down *  0.5f, Color.red);
        if(Physics2D.Raycast(transform.position, Vector2.down , 0.8f, layerGround))
        {
            //Revisar si va cayendo para poner animacion de que cayó
            if(hasJump == false)
            {
                animations.animatorPlayer.SetTrigger("Landing");
                hasJump = true;
                // Invoke(animations.IdlePlayer(), 0.5f);
                StartCoroutine(IELandingToIdle());

            }
            

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                hasJump = false;
                AudioManager.instance.Play("JumpSound");
                rigiBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
        
    }

    IEnumerator IELandingToIdle()
    {

        yield return new WaitForSeconds(0.5F);
        animations.animatorPlayer.SetTrigger("Idle");
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
        _joystickAxisLeft = context.ReadValue<Vector2>();
    }

}
