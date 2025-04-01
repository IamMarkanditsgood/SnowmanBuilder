using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : BasicScreen
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _coins;
    [SerializeField] private TMP_Text _bgName;
    [SerializeField] private TMP_Text _bgNamePrevText;
    [SerializeField] private Button _close;
    [SerializeField] private Button _next;
    [SerializeField] private Button _prev;
    [SerializeField] private Button _buy;
    [SerializeField] private Button _use;
    [SerializeField] private GameObject _choosed;
    [SerializeField] private Image _bg;
    [SerializeField] private Sprite[] _backGrounds;
    [SerializeField] private GameObject[] _panels;

    private TextManager _textManager = new TextManager();

    private int currentBG = 1;

    private void Start()
    {
        _close.onClick.AddListener(Home);
        _next.onClick.AddListener(Next);
        _prev.onClick.AddListener(Previous);
        _buy.onClick.AddListener(Buy);
        _use.onClick.AddListener(Use);
    }
    private void OnDestroy()
    {
        _close.onClick.RemoveListener(Home);
        _next.onClick.RemoveListener(Next);
        _prev.onClick.RemoveListener(Previous);
        _buy.onClick.RemoveListener(Buy);
        _use.onClick.RemoveListener(Use);
    }

    public override void SetScreen()
    {
        ConfigScreen();
    }

    public override void ResetScreen()
    {
    }

    private void ConfigScreen()
    {
        if (!PlayerPrefs.HasKey($"Background{1}"))
        {
            Debug.Log("Good");
            PlayerPrefs.SetInt($"Background{1}", 1);
        }
            _textManager.SetText(PlayerPrefs.GetInt("Coins"), _coins, true);
        _textManager.SetText(PlayerPrefs.GetInt("Score"), _score, true);
        _bgName.text = "Background" + (currentBG + 1);
        _bg.sprite = _backGrounds[currentBG];

        if (currentBG == 0)
        {
            _panels[0].SetActive(false);
        }
        else if(currentBG == _backGrounds.Length - 1)
        {
            _panels[2].SetActive(false);
        }
        else
        {
            _bgNamePrevText.text = "Background" + (currentBG);
            _panels[0].SetActive(true);
            _panels[2].SetActive(true);
        }
        if(!PlayerPrefs.HasKey("CurrentBG"))
        {
            PlayerPrefs.SetInt("CurrentBG", 1);
        }

        if(PlayerPrefs.GetInt("CurrentBG") == currentBG)
        {
            _choosed.SetActive(true);   
            _buy.gameObject.SetActive(false);
            _use.gameObject.SetActive(false);
        }
        else if (PlayerPrefs.HasKey($"Background{currentBG}"))
        {
            _choosed.SetActive(false);
            _buy.gameObject.SetActive(false);
            _use.gameObject.SetActive(true);
        }
        else
        {
            _choosed.SetActive(false);
            _buy.gameObject.SetActive(true);
            _use.gameObject.SetActive(false);
        }
    }

    private void Home()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Home);
    }

    private void Next()
    {
        if(currentBG < _backGrounds.Length-1)
        {
            currentBG++;
            ConfigScreen();
        }
    }

    private void Previous()
    {
        if (currentBG > 0)
        {
            currentBG--;
            ConfigScreen();
        }
    }

    private void Buy()
    {
        if (!PlayerPrefs.HasKey($"Background{currentBG}") && PlayerPrefs.GetInt("Coins") >= 10000)
        {
            int coins = PlayerPrefs.GetInt("Coins");
            coins -= 10000;
            PlayerPrefs.SetInt("Coins", coins);
            PlayerPrefs.SetInt($"Background{currentBG}", 1);
            ConfigScreen();
        }
    }

    private void Use()
    {
        if (PlayerPrefs.GetInt("CurrentBG") != currentBG)
        {
            PlayerPrefs.SetInt("CurrentBG", currentBG);
            ConfigScreen();
        }     
    }
      
}