using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    public float playerMoveSpeed;
    Animator anim;
    public float turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalMovement = Input.GetAxis("Horizontal");
        var verticalMovement = Input.GetAxis("Vertical");

        var playerMovement = new Vector3(horizontalMovement, 0, verticalMovement);
        characterController.SimpleMove(playerMovement * Time.deltaTime*playerMoveSpeed);
        anim.SetFloat("Speed", playerMovement.magnitude);

        Quaternion newDirection = Quaternion.LookRotation(playerMovement);
        transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * turnSpeed);            
    }
}
