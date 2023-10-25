using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] private Button _pauseBtn;
    [SerializeField] private TextMeshProUGUI _scoreTMP;
    [SerializeField] private TextMeshProUGUI _timeInGameTMP;

    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private TextMeshProUGUI _resultTMP;
    [SerializeField] private Button _restartBtn;
    [SerializeField] private Button _goToMainMenu;
    private int minutes = 0;
    private int seconds = 0;
    private float _time;
    void Start()
    {
        _pauseBtn.onClick.AddListener(() => Pause());
        _restartBtn.onClick.AddListener(() => Restart());
        _goToMainMenu.onClick.AddListener(() => GoToMainMenu());
        _gameOverUI.SetActive(false);
    }

    void Update()
    {
        _scoreTMP.text = GameManager.Score.ToString();
        if (Time.time > _time)
        {
            seconds += 1;
            switch (seconds)
            {
                case 60:
                    minutes++;
                    seconds = 0;
                    break;
            }
            _timeInGameTMP.text = $"{minutes}:{seconds}";
            _time = Time.time + 1;
        }
        _resultTMP.text = $"Поражение\nНабрано: {GameManager.Score} очков";
    }
    private void Pause()
    {
        switch (Time.timeScale)
        {
            case 0:
                Time.timeScale = 1; break;
            case 1:
                Time.timeScale = 0; break;

        }
    }
    private void Restart()
    {
        SaveResults.Save();
        GameManager.TryAgain();
        SceneManager.LoadScene("Game");
    }
    private void GoToMainMenu()
    {
        SaveResults.Save();
        GameManager.Reset();
        SceneManager.LoadScene("MainMenu");
    }
}
