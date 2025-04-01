using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : BasicPopup
{
    [SerializeField] private Button _vibration;

    [SerializeField] private Sprite _off;
    [SerializeField] private Sprite _on;

    public override void Subscribe()
    {
        base.Subscribe();
        _vibration.onClick.AddListener(Vibration);
    }

    public override void Unsubscribe()
    {
        base.Unsubscribe();
        _vibration.onClick.RemoveListener(Vibration);
    }

    public override void ResetPopup()
    {
    }

    public override void SetPopup()
    {
        if(!PlayerPrefs.HasKey("Vibration"))
        {
            PlayerPrefs.SetInt("Vibration", 1);
        }

        if(PlayerPrefs.GetInt("Vibration") == 1)
        {
            _vibration.GetComponent<Image>().sprite = _on;
        }
        else
        {
            _vibration.GetComponent<Image>().sprite = _off;
        }
    }

    private void Vibration()
    {
        if (PlayerPrefs.GetInt("Vibration") == 1)
        {
            PlayerPrefs.SetInt("Vibration", 0);
            _vibration.GetComponent<Image>().sprite = _off;
        }
        else
        {
            PlayerPrefs.SetInt("Vibration", 1);
            _vibration.GetComponent<Image>().sprite = _on;
        }
    }
}
