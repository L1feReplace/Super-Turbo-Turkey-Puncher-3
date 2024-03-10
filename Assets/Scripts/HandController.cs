using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HandController : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private GameObject _turkey;
    [SerializeField] private GameObject _turkeyHit;

    private RectTransform _rectTransform;
    private int _score;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        LoadScore();
        UpdateScoreText(); 
    }
    public void OnClickButton()
    {
        _score++;
        SaveScore(); 
        UpdateScoreText(); 
        Punch();
    }

    private void UpdateScoreText()
    {
        _scoreText.text = _score.ToString();
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

    private void SaveScore()
    {
        PlayerPrefs.SetInt("Score", _score);
        PlayerPrefs.Save();
    }

    private void LoadScore()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            _score = PlayerPrefs.GetInt("Score");
        }
    }
}
