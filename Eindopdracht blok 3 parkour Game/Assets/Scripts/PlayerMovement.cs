using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    float speedreturn;
    public float speedBoost = 2;
    [SerializeField] float dashtime = .5f;
    [SerializeField] bool dashAble = true;

    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    [SerializeField] int jumpcount = 2;

    public Rigidbody rb;
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    

    Vector3 velocity;
    bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        speedreturn = speed;
        dashAble = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance, groundMask);

        if (isGrounded == true && velocity.y < 0)
        {
            velocity.y = -2f; 
        }

        float x = Input.GetAxis("Horizontal")*Time.deltaTime *speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move*speed*Time.deltaTime);

        if (Input.GetButtonDown("Jump") && jumpcount>0)
        {
            isGrounded = false;
            jumpcount -= 1;
            velocity.y = Mathf.Sqrt(jumpHeight*-2f*gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Dash") && dashAble == true)
        {
            StartCoroutine(Dash());
        }
    }

    public void Grounded()
    {
        Debug.Log("grond");
        jumpcount = 2;
    }

    IEnumerator Dash()
    {
        dashAble = false;
        speed = speed * speedBoost;
        yield return new WaitForSeconds(dashtime);
        speed = speedreturn;
        dashAble = true;

    }
}
