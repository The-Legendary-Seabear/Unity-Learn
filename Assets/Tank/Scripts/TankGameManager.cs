using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class TankGameManager : MonoBehaviour
{
    [SerializeField] GameObject titlePanel;
    [SerializeField] GameObject gameWinPanel;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] bool debug = false;

    static TankGameManager instance;
    public static TankGameManager Instance {
        get {
            if (instance == null) instance = FindFirstObjectByType<TankGameManager>();
            return instance;
            }
        }

    public int Score { get; set; } = 0;
    void Start()
    {
        //This affects the speed at which the time passes in the game. This effectively pauses the game.
        Time.timeScale = (debug) ? 1.0f : 0.0f;
        titlePanel.SetActive(!debug);
        gameWinPanel.SetActive(false);
    }

    void Update()
    {
        scoreText.text = Score.ToString("0000");
    }

    public void OnGameStart()
    {
        print("start game");
        titlePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void OnGameWin()
    {
        gameWinPanel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void OnGameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Destroy(gameObject);
    }

    public void OnGameOver()
    {
        StartCoroutine(ResetGameCR(2.0f));
    }

    IEnumerator ResetGameCR(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        titlePanel.SetActive(false);
    }
}
