using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataTransit : MonoBehaviour
{
    public static DataTransit instance;

    public string playerName;
    public float playerScore;
    public string bestPlayerName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayerData();
    }
    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public string bestPlayerName;
        public float playerScore;
    }
    public void SaveName()
    {
        SaveData saveData = new SaveData();
        saveData.playerName = playerName;
    }

    public void SetBestPlayerName()
    {
        bestPlayerName = playerName;
    }
    public void SavePlayerData(string name, float score)
    {
        SaveData data = new SaveData();
        data.playerScore = score;
        data.bestPlayerName = name;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.bestPlayerName;
            playerScore = data.playerScore;
        }
    }

}
