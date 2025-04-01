using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Home : BasicScreen
{
    [SerializeField] private Button _play;
    [SerializeField] private Button _settings;
    [SerializeField] private Button _profile;
    [SerializeField] private Button _shop;

    void Start()
    {
        _play.onClick.AddListener(PlayGame);
        _settings.onClick.AddListener(Settings);
        _profile.onClick.AddListener(Profile);
        _shop.onClick.AddListener(Shop);
    }

    void OnDestroy()
    {
        _play.onClick.RemoveListener(PlayGame);
        _settings.onClick.RemoveListener(Settings);
        _profile.onClick.RemoveListener(Profile);
        _shop.onClick.RemoveListener(Shop);
    }

    public override void ResetScreen()
    {

    }

    public override void SetScreen()
    {

    }

    private void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    private void Settings()
    {
        UIManager.Instance.ShowPopup(PopupTypes.Settings);
    }

    private void Profile()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Profile);
    }
    private void Shop()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Shop);
    }
}
