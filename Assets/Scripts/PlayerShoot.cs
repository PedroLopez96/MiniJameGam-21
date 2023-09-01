using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField] GameObject bulletPrefab = null;
    private Camera cam = null;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        ShootToMousePosition();
    }

    private void ShootToMousePosition()
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

}
