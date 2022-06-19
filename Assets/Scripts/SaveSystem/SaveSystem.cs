using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private string KeyCommonScore = "PlayerScore";
    public static SaveSystem instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
    }

    public Data LoadPlayerScoreWithPlayerPrefs()
    {
        Data DataPlayer = new Data();
        DataPlayer.CurrentCount = 0;
        DataPlayer.CommonCount = PlayerPrefs.GetInt(KeyCommonScore);
        return DataPlayer;
    }

    public void SavePlayerScoreWithPlayerPrefs(Data currentData)
    {
        int commonScore = currentData.CommonCount + currentData.CurrentCount;
        PlayerPrefs.SetInt(KeyCommonScore, commonScore);
    }
}