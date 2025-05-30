using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private Button _restart;

    private void Start()
    {
        _restart.onClick.AddListener(Reset);
    }

    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0;
        _gameOverMenu.SetActive(true);

    }
}
