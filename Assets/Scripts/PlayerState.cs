using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerState : MonoBehaviour
{
    public static PlayerState Instance;
    public string PlayerName;
    public int HighScore;
    public int CurrentScore;

    // Update is called once per frame
    private void Awake()
    {
        if (Instance is not null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadPreviousData();
    }

    [System.Serializable] // for JsonUtility to serialize.
    class SaveData
    {
        public string PlayerName;
        public int HighScore;
    }

    public void SaveCurrentData()
    {
        SaveData data = new SaveData();
        data.PlayerName = PlayerName;
        data.HighScore = HighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPreviousData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.PlayerName;
            HighScore = data.HighScore;
        }
    }
}
