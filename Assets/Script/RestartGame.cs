using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PlatformShoot
{
    public class RestartGame : MonoBehaviour
    {
        private void Start()
        {
            //��������RestartButton����س���
            transform.Find("RestartButton").GetComponent<Button>().onClick.AddListener(() =>
            {
                SceneManager.LoadScene("SampleScene");
            });
        }
    }
}
