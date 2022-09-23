using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWall : MonoBehaviour
{
    [SerializeField] private float _forceOnDestruction = 7.5f;
    [SerializeField] private float _forceTime = 0.05f;
    private Rigidbody _myRigidbody;

    private void Start()
    {
        _myRigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            StartCoroutine(DestroyRoutine());
        }
    }

    IEnumerator DestroyRoutine()
    {
        //Add velocity to make it push around other walls before getting destroyed
        _myRigidbody.velocity = new Vector3(Random.Range(0, _forceOnDestruction), Random.Range(0, _forceOnDestruction), Random.Range(0, _forceOnDestruction));

        yield return new WaitForSeconds(_forceTime);
        Destroy(gameObject);
    }
}
