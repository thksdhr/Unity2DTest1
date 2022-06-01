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
            rb = GetComponent<Rigidbody2D>();//��ȡ��ɫ����
            MyMainPanel = GameObject.Find("MainPanel").GetComponent<MainPanel>();//��ȡMainPanel�е����MainPanel
            mGamePass = GameObject.Find("GamePass");//GamePass�����ȡ
            mGamePass.SetActive(false);//��GamePass����Ϊδ����״̬
            GameLost = GameObject.Find("GameLost");
            GameLost.SetActive(false);
        }
        private void Update()
        {
            MoveControl();//��Ծ����
            OpenFire();//������
        }
        private void FixedUpdate()
        {
            DoMove();
            IfGameLost();
        }
        //�ƶ����Ƶ�����
        private void MoveControl()
        {
            //�ж���Ծ����
            if (Input.GetButtonDown("Jump"))
            {
                OnJump = true;
            }
        }
        //�����ƶ�����������
        private void DoMove()
        {
            //ִ����Ծ
            if (OnJump == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                OnJump = false;
            }
            //�ƶ�����
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * MoveSpeed, rb.velocity.y);
            //��ҳ���
            float mFace = Input.GetAxisRaw("Horizontal");
            if (mFace != 0)
            {
                //��localScale���޸ĳ���
                transform.localScale = new Vector3(mFace, transform.localScale.y, transform.localScale.z);
            }


        }
        //����ӵ�
        private void OpenFire()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                var bullet = Resources.Load<GameObject>("Bullet");//����Resources�ļ����ڵ���Դ
                GameObject.Instantiate(bullet, transform.position, Quaternion.identity);//����Դ���ɵ�������
            }
        }
        //��Ϸ����
        private void IfGameLost()
        {
            if(transform.position.y < -20)
            {
                this.gameObject.SetActive(false);//Player����ͣ��
                GameLost.SetActive(true);
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
