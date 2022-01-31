using UnityEngine;
using System.IO;

public class SessionManager : MonoBehaviour
{
    public static SessionManager Instance;

    public string playerName;
    public string bestPlayerName;
    public int bestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public int Score;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.PlayerName = bestPlayerName;
        data.Score = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/bestscore.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/bestscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.PlayerName;
            bestScore = data.Score;
        }
    }
}
