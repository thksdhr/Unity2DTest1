using UnityEngine;

namespace PlatformShoot
{
    public class Bullet : MonoBehaviour
    {
        private LayerMask mLayerMask;
        private float bFace;
        private void Start()
        {
            bFace = GameObject.Find("Player").GetComponent<Transform>().localScale.x;
            mLayerMask = LayerMask.GetMask("Ground", "Trigger");//����mLayerMaskɸѡ������Tag��ǩ
            Destroy(gameObject, 3f);//�ӳ������Ӻ������ӵ�
        }
        private void Update()
        {
            transform.Translate(12f * Time.deltaTime * bFace, 0, 0);//�����ӵ���һ������̶�����

        }
        private void FixedUpdate()
        {
            var coll = Physics2D.OverlapBox(transform.position, transform.localScale, 0, mLayerMask);//�����ײ����mLayerMaskɸѡ�Ķ��󣬷��ض�Ӧ��Collider������
            if (coll)
            {
                if (coll.CompareTag("Trigger"))
                {
                    Destroy(coll.gameObject);//coll�ı�ǩΪTrigger,ɾ����
                    GameObject.Find("Player").GetComponent<Player>().mGamePass.SetActive(true);//ֱ���޸�Player.cs�е�ֵ��ԭ����BUG���ݹ�����ֵ�ᱻ���NULL��
                }
            }
        }
    }
}