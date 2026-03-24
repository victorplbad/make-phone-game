using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Transactions;
using TMPro;
using Unity.Collections;
using UnityEditor.Overlays;
using System.Xml.Serialization;
using UnityEngine;

public class DataSaver : MonoBehaviour
{

    public float currentTime;
    public Transform currentPlayerPositionX;
    public int currentPlayerScore;
    public int currentPlayerHealth;


    public PlayerData playerData = new();
    
    public string DataSavingKey = "saveDataPlace";
    


    public TextMeshProUGUI positionSavedShow; // optional: show current path
    private GameData gameDataCurrent;

    public void Start()
    {

        gameDataCurrent = transform.GetComponent<GameManager>().gameData;



        SaveToFile();



        //InvokeRepeating("SaveToFile", 1f, 1f); // call X , start after X , repeat X

    }



    void SaveJson(GameData gameDataHere)
    {
        string folder = Path.Combine(GetSavePath(), "scripts/data/");
        
        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        string pathFull = Path.Combine(folder, "saveDataPlace.json");
        string json = JsonUtility.ToJson(gameDataHere, true);
        File.WriteAllText(pathFull, json);
        Debug.Log("Saved JSON: " + pathFull);
        positionSavedShow.text = pathFull;
    }




    public void SaveToFile()
    {

        PlayerData data = new();
        data.time = currentTime;
        data.playerPositionX = currentPlayerPositionX;
        data.playerScore = currentPlayerScore;
        data.playerHealth = currentPlayerHealth;

        //GameData gamedate = new();
        //gamedate.entries.Add(data);

        SaveJson(gameDataCurrent);




    }


   

    /// <summary>
    /// //////////////////////////////////////////////////////////
    /// </summary>

    public void MoveToDownloads()
    {
        string savedFolder = Path.Combine(GetSavePath(), "scripts/data/");
        if (!Directory.Exists(savedFolder))
        {
            Debug.LogWarning("SavedData folder does not exist!");
            return;
        }

        string downloadsPath;

        if (Application.platform == RuntimePlatform.Android)
        {
            downloadsPath = "/storage/emulated/0/Download/SavedData"; // Android Downloads
        }
        else
        {
            downloadsPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "SavedData");
        }

        if (!Directory.Exists(downloadsPath))
            Directory.CreateDirectory(downloadsPath);

        foreach (string file in Directory.GetFiles(savedFolder))
        {
            string destFile = Path.Combine(downloadsPath, Path.GetFileName(file));
            File.Copy(file, destFile, true);
            Debug.Log("Copied to Downloads: " + destFile);
        }

        Debug.Log("All files moved to Downloads folder!");
    }



    private string GetSavePath()
    {
        if (Application.isEditor)
            return Application.dataPath; // Editor folder
        else
            return Application.persistentDataPath; // Android, iOS, Standalone builds
    }


}



