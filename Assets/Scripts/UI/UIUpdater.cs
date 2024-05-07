using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _clickScoreText;
    [SerializeField] private Text[] _costText;

    public void UpdateUI(int score, int clickScore, int[] costInt)
    {
        UpdateScoreText(score);
        UpdateClickScoreText(clickScore);
        UpdateCostText(costInt);
    }

    private void UpdateScoreText(int score)
    {
        _scoreText.text = score.ToString();
    }

    private void UpdateClickScoreText(int clickScore)
    {
        _clickScoreText.text = clickScore.ToString();
    }

    private void UpdateCostText(int[] costInt)
    {
        for (int i = 0; i < costInt.Length && i < _costText.Length; i++)
        {
            _costText[i].text = costInt[i].ToString();
        }
    }
}
