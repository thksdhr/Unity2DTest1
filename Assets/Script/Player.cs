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
            MyMainPanel = GameObject.Find("MainPanel").GetComponent<MainPanel>();//��ȡMainPanel�е����MainPanel
        }
        private void Update()
        {
            MoveControl();//��Ծ����
            OpenFire();//������
        }
        private void FixedUpdate()
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * MoveSpeed, rb.velocity.y);
            DoMove();
        }
        private void MoveControl()
        {
            //�ж���Ծ
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
                var Bullet = Resources.Load<GameObject>("Bullet");//����Resources�ļ����ڵ���Դ
                GameObject.Instantiate(Bullet, transform.position, Quaternion.identity);//����Դ���ɵ�������

            }
        }
        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.gameObject.CompareTag("Door"))//�����ɫ��ײ���˱�ǩDoor
            {
                SceneManager.LoadScene("GameOver");//���س���GameOver
            }
            if (coll.gameObject.CompareTag("Reward"))
            {
                MyMainPanel.UpdateScore(1);
                GameObject.Destroy(coll.gameObject);
            }
        }
    }
}
