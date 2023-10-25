using UnityEngine;

public static class GameManager
{
    public static string Nickname = "";
    public static int Score = 0;

    public static void Reset()
    {
        Nickname = string.Empty;
        Score = 0;
        Time.timeScale = 1;
    }
    public static void TryAgain()
    {
        Score = 0;
        Time.timeScale = 1;
    }
}
