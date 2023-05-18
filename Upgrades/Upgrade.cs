using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(UpgradeText))]
public class Upgrade : MonoBehaviour
{
    [SerializeField] string _identifier;
    [SerializeField] Sprite _sprite;
    [SerializeField] TextMeshProUGUI _levelText;
    [SerializeField] Image _buttonImage;
    Image _image;
    Vector3 _startScale;
    protected int _level, _moneyToUpgrade;
    protected UpgradeText _text;
    protected UpgradeManager _manager;
    protected void Awake()
    {
        _manager = FindObjectOfType<UpgradeManager>();
        _text = GetComponent<UpgradeText>();
        _image = GetComponent<Image>();
        _startScale = transform.localScale;
    }

    protected void Start()
    {
        LoadProgress();
    }

    protected void SaveProgress(int level)
    {
        PlayerPrefs.SetInt(_identifier, level);
    }

    protected void LoadProgress()
    {
        if (!PlayerPrefs.HasKey(_identifier))
        {
            PlayerPrefs.SetInt(_identifier, 0);
        }

        _level = PlayerPrefs.GetInt(_identifier);
        SetLevelValues(_level);
    }
    virtual public void OnUpgradeClicked()
    {
        Resource resources = GameManager.Instance.Resources;
        float playerMoney = resources.Money;
        if (playerMoney < _moneyToUpgrade) { return; }

        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOScale(_startScale * 0.9f, 0.1f));
        seq.Append(transform.DOScale(_startScale, 0.4f));

        Sequence seq2 = DOTween.Sequence();
        seq2.Append(_buttonImage.DOColor(new Color(22f / 255f, 128f / 255f, 46f / 255f, 1f), 0.1f));
        seq2.Append(_buttonImage.DOColor(new Color(22f / 255f, 244f / 255f, 96f / 255f, 1f), 0.4f));

        resources.OnMoneyChange(-1f * _moneyToUpgrade);
        _level++;
        SetLevelValues(_level);
        SaveProgress(_level);
    }
    virtual protected void SetLevelValues(int level)
    {
        _levelText.text = "Level " + (_level + 1).ToString();
    }

    protected void OnMaxLevel()
    {
        _text.SetMax();
        _image.sprite = _sprite;
    }

}
