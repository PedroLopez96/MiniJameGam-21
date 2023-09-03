using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class PlayerScript : MonoBehaviour
{

    public GameObject hitBox;
    public GameObject canvas;
    private bool isHittingInteractable = false;

    void Start()
    {

    }

    void Update()
    {
        // HITBOX MELEE ATTACK
        if (Input.GetMouseButton(0))
        {
            hitBox.SetActive(true);
        }
        else
        {
            hitBox.SetActive(false);
        }


        // RAYCAST TO INTERACT
        Vector3 playerChestPosition = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        RaycastHit hit;

        if (Physics.Raycast(playerChestPosition, transform.TransformDirection(Vector3.forward), out hit, 10))
        {
            if (hit.transform.tag == "Interactable")
            {
                isHittingInteractable = true;
                Debug.Log("Press E to pick up");
            }

        } else isHittingInteractable = false;

        // MAKE VISUAL RAY FOR DEBUGGING
        Debug.DrawRay(playerChestPosition, transform.TransformDirection(Vector3.forward) * 10, Color.yellow);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isHittingInteractable)
            {
                Debug.Log("Picked something up: " + hit.transform.name);
                Destroy(hit.transform.gameObject);  
            } else
            {
                Debug.Log("Nothing to pick up");
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag == "Enemy")
        {
            canvas.GetComponent<PanelSwitch>().enableGameOver();
        }

        if (collision.transform.tag == "LoopDevice")
        {
            Debug.Log("Out of the loop!");
        }
    }
}
