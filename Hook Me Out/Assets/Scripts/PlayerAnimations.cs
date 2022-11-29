using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator animatorPlayer;
    public PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        animatorPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animatorPlayer.SetFloat("walkingSide", player._joystickAxisLeft.x);
        if(Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            animatorPlayer.SetTrigger("Jump");
        }
        if(Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            player.hasJump = false;
        }
    }

    public void IdlePlayer()
    {
        animatorPlayer.SetTrigger("Idle");
    }

    
}
