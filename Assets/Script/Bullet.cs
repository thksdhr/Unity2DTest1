using UnityEngine;

namespace PlatformShoot
{
    public class Bullet : MonoBehaviour
    {
        private LayerMask mLayerMask;
        private GameObject mGamePass;
        private void Start()
        {
            mLayerMask = LayerMask.GetMask("Ground", "Trigger");//����mLayerMaskɸѡ������Tag��ǩ
            Destroy(gameObject, 3f);//�ӳ������Ӻ������ӵ�
        }
        private void Update()
        {
            transform.Translate(12f * Time.deltaTime, 0, 0);//�����ӵ���һ������̶�����

        }
        public void GetGamePass(GameObject pass)
        {
            mGamePass = pass;
            Debug.Log(mGamePass);
        }
        private void FixedUpdate()
        {
            var coll = Physics2D.OverlapBox(transform.position, transform.localScale, 0, mLayerMask);//�����ײ����mLayerMaskɸѡ�Ķ��󣬷��ض�Ӧ��Collider������
            if (coll)
            {
                if (coll.CompareTag("Trigger"))
                {
                    Destroy(coll.gameObject);//coll�ı�ǩΪTrigger,ɾ����
                    Debug.Log(mGamePass);
                    mGamePass.SetActive(true);
                }
            }
        }
    }
}