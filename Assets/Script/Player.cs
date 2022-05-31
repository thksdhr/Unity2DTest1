using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlatformShoot
{
    public class Player : MonoBehaviour
    {
        private Rigidbody2D rb;
        private float MoveSpeed, JumpForce;
        private bool OnJump;
        private MainPanel MyMainPanel;
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            MoveSpeed = 5f;
            JumpForce = 12f;
            OnJump = false;
            MyMainPanel = GameObject.Find("MainPanel").GetComponent<MainPanel>();//获取MainPanel中的组件MainPanel
        }
        private void Update()
        {
            MoveControl();//跳跃按下
            OpenFire();//开火按下
        }
        private void FixedUpdate()
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * MoveSpeed, rb.velocity.y);
            DoMove();
        }
        private void MoveControl()
        {
            //判断跳跃
            if (Input.GetButtonDown("Jump"))
            {
                OnJump = true;
            }
        }
        private void DoMove()
        {
            if (OnJump == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                OnJump = false;
            }

        }
        private void OpenFire()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                var Bullet = Resources.Load<GameObject>("Bullet");//加载Resources文件夹内的资源
                GameObject.Instantiate(Bullet, transform.position, Quaternion.identity);//将资源生成到画面内

            }
        }
        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.gameObject.CompareTag("Door"))//如果角色碰撞到了标签Door
            {
                SceneManager.LoadScene("GameOver");//加载场景GameOver
            }
            if (coll.gameObject.CompareTag("Reward"))
            {
                MyMainPanel.UpdateScore(1);
                GameObject.Destroy(coll.gameObject);
            }
        }
    }
}
