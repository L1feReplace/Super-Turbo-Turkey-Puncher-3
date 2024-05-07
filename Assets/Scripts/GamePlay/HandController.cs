using System.Collections;
using UnityEngine;

public class HandController : MonoBehaviour
{
    [SerializeField] private GameObject _turkey;
    [SerializeField] private GameObject _turkeyHit;
    [SerializeField] private int _clickScore = 1;
    [SerializeField] private int[] _costInt;

    private RectTransform _rectTransform;
    private int _score;
    private UIUpdater _uiUpdater;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _uiUpdater = FindObjectOfType<UIUpdater>(); 
        LoadPlayerPrefs();
        UpdateUI();
    }

    private void OnDestroy()
    {
        SavePlayerPrefs();
    }

    public void OnClickButton()
    {
        _score += _clickScore;
        UpdateUI();
        Punch();
    }

    public void OnClickBuyLevel(int levelIndex)
    {
        if (_score >= _costInt[levelIndex])
        {
            _score -= _costInt[levelIndex];
            _costInt[levelIndex] *= 2;
            _clickScore *= 2;
            UpdateUI();
        }
    }

    private void LoadPlayerPrefs()
    {
        _score = PlayerPrefs.GetInt("Score", 0);
        _clickScore = PlayerPrefs.GetInt("ClickScore", 1);
        for (int i = 0; i < _costInt.Length; i++)
        {
            _costInt[i] = PlayerPrefs.GetInt("CostInt" + i, _costInt[i]);
        }
    }

    private void SavePlayerPrefs()
    {
        PlayerPrefs.SetInt("Score", _score);
        PlayerPrefs.SetInt("ClickScore", _clickScore);
        for (int i = 0; i < _costInt.Length; i++)
        {
            PlayerPrefs.SetInt("CostInt" + i, _costInt[i]);
        }
        PlayerPrefs.Save();
    }

    private void UpdateUI()
    {
        _uiUpdater.UpdateUI(_score, _clickScore, _costInt);
    }

    private void Punch()
    {
        Vector2 punchOffset = new Vector2(0f, 180f);
        _rectTransform.anchoredPosition += punchOffset;
        _turkey.SetActive(false);
        _turkeyHit.SetActive(true);
        StartCoroutine(PunchEndCoroutine(punchOffset));
    }

    private IEnumerator PunchEndCoroutine(Vector2 punchOffset)
    {
        yield return new WaitForSeconds(0.2f);
        _rectTransform.anchoredPosition -= punchOffset;
        _turkey.SetActive(true);
        _turkeyHit.SetActive(false);
    }
}
