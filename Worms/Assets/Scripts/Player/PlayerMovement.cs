using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _jumpHeight;
    public int playerID;
    public bool isGrounded = true;
    public Transform cameraPos;

    private Rigidbody _myRigidbody;
    private PlayerTurn _myTurn;

    // Start is called before the first frame update
    void Start()
    {
        _myRigidbody = GetComponent<Rigidbody>();
        _myTurn = GetComponent<PlayerTurn>();
    }

    // Update is called once per frame
    void Update()
    {
        Jumping();
        Rotation();
        Movement();
    }

    private void Movement()
    {
        //If player traveled their max range, no more movement allowed, rotations and jumping is fine though
        if (_myTurn.distanceTraveled >= _myTurn.distancePerTurn) return;

        float verticalInput = Input.GetAxisRaw("Vertical");

        transform.Translate(Vector3.forward * _movementSpeed * verticalInput * Time.deltaTime);

        //Add to distancetraveled to make sure player does not move more than they should
        if(verticalInput != 0)
        {
            _myTurn.distanceTraveled += Time.deltaTime;
        }
    }

    private void Rotation()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        transform.Rotate(0, horizontalInput * _rotationSpeed * Time.deltaTime, 0);
    }

    private void Jumping()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _myRigidbody.velocity = new Vector3(_myRigidbody.velocity.x, _jumpHeight, _myRigidbody.velocity.z);
            isGrounded = false;
        }
    }
}
