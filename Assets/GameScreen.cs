using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D.Animation;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour
{
    [SerializeField] private Button _close;
    [SerializeField] private Button _tryAgain;
    [SerializeField] private Button _home;

    [SerializeField] private GameObject _Lose;

    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _coins;

    [SerializeField] private SpriteRenderer _bg;
    [SerializeField] private Sprite[] _backGrounds;

    private TextManager _textManager = new TextManager();
    int seconds;
    int newResult = 0;


    void Start()
    {
        _close.onClick.AddListener(Home);
        _tryAgain.onClick.AddListener(TryAgain);
        _home.onClick.AddListener(Home);

        StartCoroutine(ScoreTimer());

        int currentBG = PlayerPrefs.GetInt("CurrentBG", 1);
        _bg.sprite = _backGrounds[currentBG];
    }

    void OnDestroy()
    {
        _close.onClick.RemoveListener(Home);
        _tryAgain.onClick.RemoveListener(TryAgain);
        _home.onClick.RemoveListener(Home);
    }

    private void Home()
    {
        CalculateReward();
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    private void TryAgain()
    {
        CalculateReward();
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    private void CalculateReward()
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + newResult);
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + newResult);

        PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") + newResult);

        if (PlayerPrefs.GetInt("MaxDistance") < (newResult / 1000))
        {
            PlayerPrefs.SetInt("MaxDistance", newResult / 1000);
        }

        if(PlayerPrefs.GetInt("CurrentRecord") > PlayerPrefs.GetInt("MaxSnowBalls"))
        {
            PlayerPrefs.SetInt("MaxSnowBalls", PlayerPrefs.GetInt("CurrentRecord"));
        }
    }

    private IEnumerator ScoreTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            seconds++;
            newResult = seconds * 1000;

            _textManager.SetText(newResult, _score, true);
            _textManager.SetText(newResult, _coins, true);
        }
    }
}
