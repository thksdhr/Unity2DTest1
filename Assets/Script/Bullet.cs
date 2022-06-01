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
            mLayerMask = LayerMask.GetMask("Ground", "Trigger");//付给mLayerMask筛选器两个Tag标签
            Destroy(gameObject, 3f);//延迟三秒钟后销毁子弹
        }
        private void Update()
        {
            transform.Translate(12f * Time.deltaTime * bFace, 0, 0);//控制子弹向一个方向固定飞行

        }
        private void FixedUpdate()
        {
            var coll = Physics2D.OverlapBox(transform.position, transform.localScale, 0, mLayerMask);//如果碰撞到了mLayerMask筛选的对象，返回对应的Collider和数量
            if (coll)
            {
                if (coll.CompareTag("Trigger"))
                {
                    Destroy(coll.gameObject);//coll的标签为Trigger,删除它
                    GameObject.Find("Player").GetComponent<Player>().mGamePass.SetActive(true);//直接修改Player.cs中的值【原因不明BUG传递过来的值会被清除NULL】
                }
            }
        }
    }
}