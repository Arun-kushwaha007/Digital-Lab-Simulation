using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    //public ProjectileItem ItemScript;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, itemContainer, fpsCam;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    private void Update()
    {
        // Check if palyer is in range and "E" is pressed
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull) PickUp();

        if (equipped && Input.GetKeyDown(KeyCode.Q)) Drop();

    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;
        //Make Rigidbody Kinematic and BoxCollider a Trigger
        rb.isKinematic = true;
        coll.isTrigger = true;

        // Enable Script
        //ItemScript.enabled = true;
    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;
        //Make Rigidbody not Kinematic and BoxCollider a Trigger
        rb.isKinematic = false;
        coll.isTrigger = false;

        // disable Script
        //ItemScript.enabled = false;
    }
}
