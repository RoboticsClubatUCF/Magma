using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public float gravity;   
    private float fallSpeed;

    private CharacterController character_controller;

    public bool isGrounded;

    public float jumpSpeed;

    public float moveSpeed = 8;

    private float xSpeed;
    private float zSpeed;

   

    // Use this for initialization
    void Start() {
        character_controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded ();
        Jump();
        Move();
        Fall();
            
    }

   

    void Move()
    {
        xSpeed = Input.GetAxis("Horizontal");
        zSpeed = Input.GetAxis("Vertical");

        if (xSpeed != 0 || zSpeed != 0)
        {
            character_controller.Move( new Vector3(xSpeed, 0, zSpeed) * moveSpeed * Time.deltaTime  );
            transform.localRotation = Quaternion.Euler(-90, 0, Mathf.Atan2(xSpeed, zSpeed) * 180 / Mathf.PI) ;
        }

    }
    void Fall()
    {
        if (!isGrounded)
        {
            fallSpeed += gravity * Time.deltaTime;
        }
        else
        {
            if (fallSpeed > 0) fallSpeed = 0;
        }
        character_controller.Move(new Vector3(0, -fallSpeed) * Time.deltaTime);
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            fallSpeed = -jumpSpeed;
        }
    }
    
    void IsGrounded ()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        isGrounded = (Physics.Raycast(transform.position, -Vector3.up, .25f, layerMask));

    }
}