using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRigidbody2D;

    private float jumpForce;
    private bool isJumping;

    // Use this for initialization
    void Start()
    {
        jumpForce = 100;
        isJumping = false;
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            playerRigidbody2D.AddForce(new Vector2(0, jumpForce));
            isJumping = true;
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
            isJumping = false;
    }
}
