using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PlatformShoot
{
    public class RestartGame : MonoBehaviour
    {
        private void Start()
        {
            //如果点击了RestartButton则加载场景
            transform.Find("RestartButton").GetComponent<Button>().onClick.AddListener(() =>
            {
                SceneManager.LoadScene("SampleScene");
            });
        }
    }
}
