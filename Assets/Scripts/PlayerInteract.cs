using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    // TODO: CREATE A HITBOX IN FRONT OF PLAYER AND CHECK IF THERE IS ANY INTERACTABLE COLLISION
    // IF YES, DISPLAY UI AND IF PRESS E, INTERACTABLE WILL BE ACIVATED

    HUDScript HUD;
    public bool hitInteractable = false;
    public GameObject interactableObject;

    private void Start()
    {
        HUD = GameObject.Find("GameManager").GetComponent<HUDScript>();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collide with: " + other.transform.name);

        if (other.transform.tag == "Interactable")
        {
            interactableObject = other.gameObject;
            hitInteractable=true;
            HUD.interactText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        interactableObject = null;
        hitInteractable = false;
        HUD.interactText.gameObject.SetActive(false);
       
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interactableObject.GetComponent<InteractableScript>().Interact();
            HUD.interactText.gameObject.SetActive(false);
        }
    }

}
