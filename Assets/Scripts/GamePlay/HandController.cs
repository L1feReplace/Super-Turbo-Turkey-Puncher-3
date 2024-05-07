using System.Collections;
using UnityEngine;

public class HandController : MonoBehaviour
{
    [SerializeField] private GameObject[] turkeyImages;
    [SerializeField] private GameObject[] turkeyHitImages;
    [SerializeField] private int[] costInt;

    private int score;
    private int clickScore = 1;
    private UIUpdater uiUpdater;
    private RectTransform rectTransform;
    private GameObject turkey;
    private GameObject turkeyHit;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        uiUpdater = FindObjectOfType<UIUpdater>();
        PlayerPrefsManager.LoadPlayerPrefs(costInt, ref score, ref clickScore);
        UpdateUI();
        ShowCurrentTurkey();
    }

    private void ShowCurrentTurkey()
    {
        int index = Mathf.Clamp(clickScore - 1, 0, turkeyImages.Length - 1);
        foreach (var image in turkeyImages) image.SetActive(false);
        foreach (var image in turkeyHitImages) image.SetActive(false);
        turkey = turkeyImages[index];
        turkeyHit = turkeyHitImages[index];
        turkey.SetActive(true);
    }

    private void OnDestroy()
    {
        PlayerPrefsManager.SavePlayerPrefs(costInt, score, clickScore);
    }

    public void OnClickButton()
    {
        score += clickScore;
        UpdateUI();
        Punch();
    }

    public void OnClickBuyLevel(int levelIndex)
    {
        if (score >= costInt[levelIndex])
        {
            score -= costInt[levelIndex];
            costInt[levelIndex] *= 2;
            clickScore *= 2;
            UpdateUI();
            ShowCurrentTurkey();
        }
    }

    private void UpdateUI()
    {
        uiUpdater.UpdateUI(score, clickScore, costInt);
    }

    private void Punch()
    {
        Vector2 punchOffset = new Vector2(0f, 180f);
        rectTransform.anchoredPosition += punchOffset;
        turkey.SetActive(false);
        turkeyHit.SetActive(true);
        StartCoroutine(PunchEndCoroutine(punchOffset));
    }

    private IEnumerator PunchEndCoroutine(Vector2 punchOffset)
    {
        yield return new WaitForSeconds(0.2f);
        rectTransform.anchoredPosition -= punchOffset;
        turkey.SetActive(true);
        turkeyHit.SetActive(false);
    }
}
