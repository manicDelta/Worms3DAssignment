using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    [SerializeField] private Transform _destination;
    [SerializeField] private float _jumpForce;
    private Rigidbody _playerRigidbody;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerRigidbody = other.GetComponent<Rigidbody>();

            //When teleporting other player, add upward velocity as to not spam teleport and induce photosensitive epilectic seizures
            other.transform.position = _destination.transform.position;
            _playerRigidbody.velocity = new Vector3(_playerRigidbody.velocity.x, _jumpForce, _playerRigidbody.velocity.z);
        }
    }
}
