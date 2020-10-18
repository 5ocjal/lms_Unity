using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody2D playerRigidbody;
    private Vector2 movement;
    private Vector2 mousePossition;
    private Animator animator;
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Vector3.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        MoveCharacter();
        mousePossition = camera.ScreenToWorldPoint(Input.mousePosition);

        if(movement.x != 0 || movement.y != 0){
            animator.SetBool("isInMove", true);
        }else{
            animator.SetBool("isInMove", false);
        }

    }

    void MoveCharacter()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDirection = mousePossition - playerRigidbody.position;
        float lookDirectionAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 270f;
        playerRigidbody.rotation = lookDirectionAngle;
    }
}
