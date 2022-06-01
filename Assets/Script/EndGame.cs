using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PlatformShoot
{
    public class EndGame : MonoBehaviour
    {
        private void Start()
        {
            transform.Find("EndGame").GetComponent<Button>().onClick.AddListener(() =>
            {
                SceneManager.LoadScene("GameOver");
            });
        }
    }
}
