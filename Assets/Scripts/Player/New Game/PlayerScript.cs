using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class PlayerScript : MonoBehaviour
{
    public AudioClip die, swipe, win;
    public GameObject pickaxe, swordpickaxe;
    public GameObject hitBox;
    public GameObject canvas;
    private bool isHittingInteractable = false;
    public bool deactivatedDevice = false;
    public Vector3 initialPosition;
    public string holdingWeapon;
    public GameObject pressEText;


    void Start()
    {
        AudioScript.Init();
        initialPosition = transform.position;
    }

    void Update()
    {
        // HITBOX MELEE ATTACK
        if (Input.GetMouseButton(0))
        {
            StartCoroutine(playclip());
            hitBox.SetActive(true);
            GetComponent<Animator>().SetBool("Attack", true);
        }
        else
        {
            hitBox.SetActive(false);
            GetComponent<Animator>().SetBool("Attack", false);
        }


        // RAYCAST TO INTERACT
        Vector3 playerChestPosition = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        RaycastHit hit;

        if (Physics.Raycast(playerChestPosition, transform.TransformDirection(Vector3.forward), out hit, 10))
        {
            if (hit.transform.tag == "Interactable")
            {
                isHittingInteractable = true;
                pressEText.SetActive(true);
                Debug.Log("Press E to pick up");
            }

        }
        else { isHittingInteractable = false;
            pressEText.SetActive(false);
        }

        // MAKE VISUAL RAY FOR DEBUGGING
        Debug.DrawRay(playerChestPosition, transform.TransformDirection(Vector3.forward) * 10, Color.yellow);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isHittingInteractable)
            {
                
                if (hit.transform.name == "LoopDevice")
                    hit.transform.GetComponent<Animator>().SetBool("Deactivate", true);


                if (hit.transform.name == "PickaxeSword")
                {
                    holdWeapon(hit.transform.name);
                    holdingWeapon = hit.transform.name;
                    Destroy(hit.transform.gameObject);
                }

                GetComponent<Animator>().SetTrigger("Interact");
                StartCoroutine(waitAnim(1));
                
            }
            else
            {

                Debug.Log("Nothing to pick up");
            }
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        // HIT ENEMY AND DIE
        if (collision.transform.tag == "Enemy")
        {
            canvas.GetComponent<PanelSwitch>().enableGameOver();
            AudioScript.play(die);
        }

        // DEACTIVATED DEVICE
        if (collision.transform.tag == "LoopDevice")
        {
            AudioScript.play(win);

            Debug.Log("Out of the loop!");
            deactivatedDevice = true;
            canvas.GetComponent<PanelSwitch>().enableLevel2();

        }
    }

    public void getPlayerBackOrigin()
    {
        transform.position = initialPosition;
    }

    public void holdWeapon(string weaponName) 
    {
        pickaxe.SetActive(false);
        swordpickaxe.SetActive(true);
        holdingWeapon = weaponName;

        if(transform.name == "PickaxeSword")
            hitBox.transform.localScale *= 2f;
    }

    public IEnumerator waitAnim(int secs)
    {
        GetComponent<PlayerController>().enabled = false; 
        yield return new WaitForSeconds(secs);
        GetComponent<PlayerController>().enabled = true;
    }

    public IEnumerator playclip()
    {
        yield return new WaitForSeconds(0.1f);
        AudioScript.play(swipe);
    }
}
