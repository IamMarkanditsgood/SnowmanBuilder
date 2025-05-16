using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Profile : BasicScreen
{
    [SerializeField] private Button _back;
    [SerializeField] private Button _next;
    [SerializeField] private Button _previous;
    [SerializeField] private Image _achieve;
    [SerializeField] private Sprite[] _achievements;
    [SerializeField] private Sprite _openAchieve;


    public TMP_Text _maxDistance;
    public TMP_Text _maxSnowFlackes;
    public TMP_Text _maxSnowBalls;


    private int _currentAchieve;

    private void Start()
    {
        _back.onClick.AddListener(Home);
        _next.onClick.AddListener(Next);
        _previous.onClick.AddListener(Previous);


    }

    private void OnDestroy()
    {
        _back.onClick.RemoveListener(Home);
        _next.onClick.RemoveListener(Next);
        _previous.onClick.RemoveListener(Previous);


    }
    public override void ResetScreen()
    {
        
    }

    public override void SetScreen()
    {
        ConfigScreen();
    }

    private void ConfigScreen()
    {
        _maxDistance.text = PlayerPrefs.GetInt("MaxDistance").ToString();
        _maxSnowFlackes.text = PlayerPrefs.GetInt("TotalCoins").ToString();
        _maxSnowBalls.text = PlayerPrefs.GetInt("MaxSnowBalls").ToString();



        _achieve.sprite = _achievements[_currentAchieve];

        if (_currentAchieve == 0 && PlayerPrefs.HasKey("FirstAchieve"))
        {
            _achieve.sprite = _openAchieve;
        }
    }

    private void Home()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Home);
    }
    private void Next()
    {
        if(_currentAchieve < _achievements.Length - 1)
        {
            _currentAchieve++;
            ConfigScreen();
        }
    }
    private void Previous()
    {
        if (_currentAchieve > 0)
        {
            _currentAchieve--;
            ConfigScreen();
        }
    }
   
}