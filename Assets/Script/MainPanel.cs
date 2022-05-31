using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace PlatformShoot
{
    public class MainPanel : MonoBehaviour
    {
        private TextMeshProUGUI ScoreNum;
        private void Start()
        {
            ScoreNum = transform.Find("Num").GetComponent<TextMeshProUGUI>();
        }
        public void UpdateScore(int Score)
        {
            //��ԭ��ֵת��Ϊint���ͣ����洢����ʱ������
            int temp = int.Parse(ScoreNum.text);
            //�ı�text�е�����
            ScoreNum.text = (temp + Score).ToString();
        }
    }
}