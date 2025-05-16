using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Home : BasicScreen
{
    [SerializeField] private Button _play;
    [SerializeField] private Button _settings;
    [SerializeField] private Button _status;
    [SerializeField] private Button _shop;
    [SerializeField] private Button _profilePopup;

    void Start()
    {
        _play.onClick.AddListener(PlayGame);
        _settings.onClick.AddListener(Settings);
        _status.onClick.AddListener(Profile);
        _shop.onClick.AddListener(Shop);
        _profilePopup.onClick.AddListener(ProfilePopup);
    }

    void OnDestroy()
    {
        _play.onClick.RemoveListener(PlayGame);
        _settings.onClick.RemoveListener(Settings);
        _status.onClick.RemoveListener(Profile);
        _shop.onClick.RemoveListener(Shop);
        _profilePopup.onClick.RemoveListener(ProfilePopup);
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
    private void ProfilePopup()
    {
        UIManager.Instance.ShowPopup(PopupTypes.ProfilePopup);
    }
}
