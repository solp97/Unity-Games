using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : Singleton<DataManager>
{
    public Vector3 checkPos;

    PlayerData playerdata =  new PlayerData();
    ChaserData chaserdata = new ChaserData();
    GameData gamedata = new GameData();



    string savePath;
    string playerName = "playerAll";
    string chaserName = "chaserAll";
    string gameDataName = "dataAll";

    public bool isSave = false;
    public GameObject player;
    public GameObject chaser;
    public GameManager gamemanager;
    private void Awake()
    {
        savePath = Application.persistentDataPath + "/";
    }


    void Start()
    {
        

    }
     public void SaveData()
    {
        string playerToJson = JsonUtility.ToJson(playerdata);
        string chaserToJson = JsonUtility.ToJson(chaserdata);
        string DataToJson = JsonUtility.ToJson(playerdata);

        File.WriteAllText(savePath + playerName, playerToJson);
        File.WriteAllText(savePath + chaserName, chaserToJson);
        File.WriteAllText(savePath + gameDataName, DataToJson);
        isSave = true;
    }

    public void LoadData()
    {
        string jsonToPlayer = File.ReadAllText(savePath + playerName);
        playerdata = JsonUtility.FromJson<PlayerData>(jsonToPlayer);
        string jsonToChaser = File.ReadAllText(savePath + chaserName);
        chaserdata = JsonUtility.FromJson<ChaserData>(jsonToChaser);
        string jsonToData = File.ReadAllText(savePath + gameDataName);
        gamedata = JsonUtility.FromJson<GameData>(jsonToData);
    }

    public void CheckPointSetPosition()
    {
        checkPos = player.transform.position;
    }

}

class PlayerData
{
    public Vector3 PlayerPos = DataManager.Instance.player.transform.position;
    public Vector3 PlayerRotate = DataManager.Instance.player.transform.rotation.eulerAngles;
}

class ChaserData
{
    public Vector3 ChaserPos = DataManager.Instance.chaser.transform.position;
    public Vector3 PlayerRotate = DataManager.Instance.chaser.transform.rotation.eulerAngles;
}

class GameData
{
    public int SaveDisks = DataManager.Instance.gamemanager.saveDiskCount;
    public int GoldKeys = DataManager.Instance.gamemanager.goldKeyCount;
}