using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class playerControl : MonoBehaviour
{
    public float walkingSpeed = 25f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 0.6f;
    public float gravity = -0.05f;
    public Camera playerCamera;
    public float lookSpeed = 200.0f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float lookSmooth = 1;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    private float XRotation = 0.0f;
    public Vector3 velocity;
    public bool grounded;

    [HideInInspector]
    public bool canMove = true;

    private RaycastHit HitInfo;
    private bool RayCastCheck;

    public RectTransform cursor;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        // Input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;
        bool LClick = Input.GetMouseButtonDown(0);

        // Interaction
        RayCastCheck = Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out HitInfo, 10f);
        if(RayCastCheck) {
            if(HitInfo.collider.gameObject.layer == 3) {
                // UI Cursor Animation
                cursor.localScale = Vector3.one * 0.3f;
                //Debug.Log("Activate Cursor Animation");
                if(LClick) {
                    HitInfo.collider.gameObject.GetComponent<Action>().Interact();
                }
            }
        } else {cursor.localScale = Vector3.one * 0.2f;}

        // Physics and Movement
        velocity.y += gravity;
        grounded = characterController.isGrounded;
        
        if(!grounded && characterController.velocity.y == 0) {velocity.y = -0.03f;}
        if(grounded && characterController.velocity.y < 0) {velocity.y = -0.03f;}
        if(grounded && Input.GetButtonDown("Jump")) {velocity.y = jumpSpeed;}

        XRotation -= mouseY;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);
        Vector3 move = (transform.right * x + transform.forward * z) * walkingSpeed * Time.deltaTime + velocity;

        playerCamera.transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.eulerAngles + Vector3.up * mouseX), lookSmooth * lookSpeed);
        characterController.Move(move);
    }
}
