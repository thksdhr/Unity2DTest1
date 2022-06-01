using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlatformShoot
{
    public class Player : MonoBehaviour
    {
        private Rigidbody2D rb;
        private float MoveSpeed = 5f, JumpForce = 12f;
        private bool OnJump;
        private MainPanel MyMainPanel;
        public GameObject mGamePass;
        private GameObject GameLost;
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();//获取角色刚体
            MyMainPanel = GameObject.Find("MainPanel").GetComponent<MainPanel>();//获取MainPanel中的组件MainPanel
            mGamePass = GameObject.Find("GamePass");//GamePass对象获取
            mGamePass.SetActive(false);//将GamePass设置为未激活状态
            GameLost = GameObject.Find("GameLost");
            GameLost.SetActive(false);
        }
        private void Update()
        {
            MoveControl();//跳跃按下
            OpenFire();//开火按下
        }
        private void FixedUpdate()
        {
            DoMove();
            IfGameLost();
        }
        //移动控制的输入
        private void MoveControl()
        {
            //判断跳跃按下
            if (Input.GetButtonDown("Jump"))
            {
                OnJump = true;
            }
        }
        //进行移动的物理运算
        private void DoMove()
        {
            //执行跳跃
            if (OnJump == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                OnJump = false;
            }
            //移动控制
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * MoveSpeed, rb.velocity.y);
            //玩家朝向
            float mFace = Input.GetAxisRaw("Horizontal");
            if (mFace != 0)
            {
                //用localScale来修改朝向
                transform.localScale = new Vector3(mFace, transform.localScale.y, transform.localScale.z);
            }


        }
        //射击子弹
        private void OpenFire()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                var bullet = Resources.Load<GameObject>("Bullet");//加载Resources文件夹内的资源
                GameObject.Instantiate(bullet, transform.position, Quaternion.identity);//将资源生成到画面内
            }
        }
        //游戏结束
        private void IfGameLost()
        {
            if(transform.position.y < -20)
            {
                this.gameObject.SetActive(false);//Player设置停用
                GameLost.SetActive(true);
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
