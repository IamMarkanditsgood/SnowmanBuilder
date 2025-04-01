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
    [SerializeField] private Button _editPhoto;
    [SerializeField] private Button _editName;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _startTime;
    [SerializeField] private TMP_Text _maxDistance;
    [SerializeField] private TMP_Text _maxSnowBalls;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _coins;
    [SerializeField] private TMP_InputField _inputName;
    [SerializeField] private Image _achieve;
    [SerializeField] private Sprite[] _achievements;
    [SerializeField] private Sprite _openAchieve;
    [SerializeField] private AvatarManager _avatarManager;

    private TextManager textManager = new TextManager();

    private int _currentAchieve;
    private const string FirstLoginKey = "FirstLoginDate";

    private void Start()
    {
        _back.onClick.AddListener(Home);
        _next.onClick.AddListener(Next);
        _previous.onClick.AddListener(Previous);
        _editName.onClick.AddListener(EditName);
        _editPhoto.onClick.AddListener(EditPhoto);

    }

    private void OnDestroy()
    {
        _back.onClick.RemoveListener(Home);
        _next.onClick.RemoveListener(Next);
        _previous.onClick.RemoveListener(Previous);
        _editName.onClick.RemoveListener(EditName);
        _editPhoto.onClick.RemoveListener(EditPhoto);

    }
    public override void ResetScreen()
    {
        if (_inputName.gameObject.activeInHierarchy)
        {
            PlayerPrefs.SetString("Name", _inputName.text);
        }
    }

    public override void SetScreen()
    {
        ConfigScreen();
    }

    private void ConfigScreen()
    {
        if (!PlayerPrefs.HasKey(FirstLoginKey))
        {
            // Сохраняем текущую дату в строковом формате
            string firstLoginDate = DateTime.Now.ToString("yyyy-MM-dd");
            PlayerPrefs.SetString(FirstLoginKey, firstLoginDate);
            PlayerPrefs.Save();
        }

        // Получаем дату первого входа
        string savedDate = PlayerPrefs.GetString(FirstLoginKey);

        // Отображаем в UI
        if (_startTime != null)
        {
            _startTime.text = "registered in the game since " + savedDate;
        }

        _avatarManager.SetSavedPicture();
        _name.text = PlayerPrefs.GetString("Name", "UserName");
        
        _inputName.text = PlayerPrefs.GetString("Name", "UserName");
        textManager.SetText(PlayerPrefs.GetInt("Coins"), _coins, true);
        textManager.SetText(PlayerPrefs.GetInt("Score"), _score, true);
        _maxDistance.text = PlayerPrefs.GetInt("MaxDistance").ToString();
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
    private void EditName()
    {
        if (!_inputName.gameObject.activeInHierarchy)
        {
            _inputName.gameObject.SetActive(true);
        }
        else
        {
            _name.text = _inputName.text;
            PlayerPrefs.SetString("Name", _inputName.text);
            _inputName.gameObject.SetActive(false);
        }
        
    }

    private void EditPhoto()
    {
        _avatarManager.PickFromGallery();
    }
}