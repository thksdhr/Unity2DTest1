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
            //将原有值转换为int类型，并存储到临时变量中
            int temp = int.Parse(ScoreNum.text);
            //改变text中的内容
            ScoreNum.text = (temp + Score).ToString();
        }
    }
}