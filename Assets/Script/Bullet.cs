using UnityEngine;

namespace PlatformShoot
{
    public class Bullet : MonoBehaviour
    {
        private LayerMask mLayerMask;
        private GameObject mGamePass;
        private void Start()
        {
            mLayerMask = LayerMask.GetMask("Ground", "Trigger");//付给mLayerMask筛选器两个Tag标签
            Destroy(gameObject, 3f);//延迟三秒钟后销毁子弹
        }
        private void Update()
        {
            transform.Translate(12f * Time.deltaTime, 0, 0);//控制子弹向一个方向固定飞行

        }
        public void GetGamePass(GameObject pass)
        {
            mGamePass = pass;
            Debug.Log(mGamePass);
        }
        private void FixedUpdate()
        {
            var coll = Physics2D.OverlapBox(transform.position, transform.localScale, 0, mLayerMask);//如果碰撞到了mLayerMask筛选的对象，返回对应的Collider和数量
            if (coll)
            {
                if (coll.CompareTag("Trigger"))
                {
                    Destroy(coll.gameObject);//coll的标签为Trigger,删除它
                    Debug.Log(mGamePass);
                    mGamePass.SetActive(true);
                }
            }
        }
    }
}