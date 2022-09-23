using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{

    [SerializeField] private float _jumpForce;
    private Rigidbody _playerRigidbody;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _playerRigidbody = other.GetComponent<Rigidbody>();
            _playerRigidbody.velocity = new Vector3(_playerRigidbody.velocity.x, _jumpForce, _playerRigidbody.velocity.z);
        }
    }
}
