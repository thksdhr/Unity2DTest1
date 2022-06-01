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
        private GameObject mGamePass;
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            MyMainPanel = GameObject.Find("MainPanel").GetComponent<MainPanel>();//��ȡMainPanel�е����MainPanel
            mGamePass = GameObject.Find("GamePass");
            mGamePass.SetActive(false);//��GamePass����Ϊδ����״̬
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
                var bullet = Resources.Load<GameObject>("Bullet");//����Resources�ļ����ڵ���Դ
                GameObject.Instantiate(bullet, transform.position, Quaternion.identity);//����Դ���ɵ�������
                bullet.GetComponent<Bullet>().GetGamePass(mGamePass);
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
