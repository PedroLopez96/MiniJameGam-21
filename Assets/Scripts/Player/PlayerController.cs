using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 move;
    private Vector3 initialPosition;

    public bool isWalking;
    public void onMove(InputAction.CallbackContext context)
    {
        isWalking = true;
        move = context.ReadValue<Vector2>();
    }

    void Start()
    {
        initialPosition = transform.position;   
    }

    
    void Update()
    {
        movePlayer();

        if(move == Vector2.zero)
        {
            isWalking = false;
            GetComponent<PlayerAnimations>().resetWalking();
        } 
    }

    public void movePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);

        if (movement != Vector3.zero)
        {
            // ANIMATE WALKING
            GetComponent<PlayerAnimations>().animWalking();

            // Only rotate when there is movement
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            

        }

        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }

    public void playerLoopback()
    {
        transform.position = initialPosition;   
    }
}
