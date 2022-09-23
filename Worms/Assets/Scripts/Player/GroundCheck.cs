using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    private PlayerMovement _movement;

    // Start is called before the first frame update
    void Start()
    {
        _movement = GetComponentInParent<PlayerMovement>();
    }

    //Groundcheck
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _movement.isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _movement.isGrounded = false;
        }
    }
}
