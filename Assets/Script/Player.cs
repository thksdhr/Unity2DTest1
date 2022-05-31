using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlatformShoot
{
    public class Player : MonoBehaviour
    {
        private Rigidbody2D rb;
        private float MoveSpeed, JumpForce;
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            MoveSpeed = 5f;
            JumpForce = 12f;
            Debug.Log("OK");
        }

        void Update()
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * MoveSpeed, rb.velocity.y);
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            }
        }
    }
}
