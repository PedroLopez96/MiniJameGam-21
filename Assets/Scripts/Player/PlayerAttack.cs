using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    private Camera cam = null;
    private PlayerAnimations animations;

    public GameObject bulletPrefab;
    public GameObject hitBoxMelee;
    public GameObject pickaxe;
    public GameObject picksword;
    public GameObject picklaser;

    public GameObject WeaponHolder;

    public string itemEquipped;

    private PlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        animations = GetComponent<PlayerAnimations>();
        cam = Camera.main;
    }

    private void Update()
    {
        AttackToMousePosition();
    }

    private void AttackToMousePosition()
    {

        if (itemEquipped == "Laser")
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                    bullet.GetComponent<BulletScript>().destinationPosition = hit.point;
                }
            }
        }

        if (itemEquipped == "Pickaxe" && Mouse.current.leftButton.wasPressedThisFrame)
        {
            hitBoxMelee.SetActive(true);
            animations.animAttackingWalking();
        }
    }

    public void equipWeapon(string item)
    {
        itemEquipped = item;
        WeaponHolder.SetActive(true);
        if (item == "Pickaxe")
            pickaxe.SetActive(true);
        
        if (item == "Picksword")
            picksword.SetActive(true);

        if (item == "Picklaser")
            picklaser.SetActive(true);
    }

}
