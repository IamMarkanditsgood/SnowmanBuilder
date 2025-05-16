using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProfilePopup : BasicPopup
{
    [SerializeField] private Button _editPhoto;
    [SerializeField] private Button _editName;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_InputField _inputName;
    [SerializeField] private AvatarManager _avatarManager;

    public override void Subscribe()
    {
        base.Subscribe();
        _editName.onClick.AddListener(EditName);
        _editPhoto.onClick.AddListener(EditPhoto);
    }
    public override void Unsubscribe()
    {
        base.Unsubscribe();
        _editName.onClick.RemoveListener(EditName);
        _editPhoto.onClick.RemoveListener(EditPhoto);
    }
    public override void ResetPopup()
    {
        if (_inputName.gameObject.activeInHierarchy)
        {
            PlayerPrefs.SetString("Name", _inputName.text);
        }
    }

    public override void SetPopup()
    {
        _avatarManager.SetSavedPicture();
        _name.text = PlayerPrefs.GetString("Name", "UserName");

        _inputName.text = PlayerPrefs.GetString("Name", "UserName");
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
