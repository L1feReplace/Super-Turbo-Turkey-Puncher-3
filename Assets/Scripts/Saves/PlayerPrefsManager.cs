using UnityEngine;

public static class PlayerPrefsManager
{
    public static void LoadPlayerPrefs(int[] costInt, ref int score, ref int clickScore)
    {
        score = PlayerPrefs.GetInt("Score", 0);
        clickScore = PlayerPrefs.GetInt("ClickScore", 1);
        for (int i = 0; i < costInt.Length; i++)
        {
            costInt[i] = PlayerPrefs.GetInt("CostInt" + i, costInt[i]);
        }
    }

    public static void SavePlayerPrefs(int[] costInt, int score, int clickScore)
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("ClickScore", clickScore);
        for (int i = 0; i < costInt.Length; i++)
        {
            PlayerPrefs.SetInt("CostInt" + i, costInt[i]);
        }
        PlayerPrefs.Save();
    }
}
