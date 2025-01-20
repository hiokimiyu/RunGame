using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveLoadManager : SingletonMonoBehaviour<SaveLoadManager>
{
    //[SerializeField] GameObject go;
    [SerializeField] SaveData _data;
    string _filePath;
    [SerializeField, Header("保存先")] string _fileName;

    void Start()
    {
        Debug.Log(Application.dataPath);
        Debug.Log(Application.persistentDataPath);

        _filePath = $"{Application.persistentDataPath}/{_fileName}.json";
        _data = GetComponent<SaveData>();

        //この名前のファイがない時新しくこの名前でファイルを新規作成
        if (!File.Exists(_filePath))
        {
            Save();
        }

        LoadAction();
    }

    public void SaveAction()
    {
        _data.Save();
        Save();
    }

    public void LoadAction()
    {
        Debug.Log("Load");
        Load();
        _data.Load();
    }

    void Save()
    {
        SaveData saveData = new SaveData();

        //データをjsonに変換して
        string json = JsonUtility.ToJson(_data);
        Debug.Log(json);
        //ファイルの書き込み
        using (StreamWriter wrter = new StreamWriter(_filePath, false))
        {
            //情報を指定したファイルに書き込む
            wrter.WriteLine(json);
            //ファイルを閉じる
            wrter.Close();
        }
    }

    void Load()
    {
        if (File.Exists(_filePath))
        {
            //ファイルの読み込み
            using (StreamReader sr = new StreamReader(_filePath))
            {
                //ファイルの内容を全て読み込む
                string json = sr.ReadToEnd();
                Debug.Log(json);
                sr.Close();
                JsonUtility.FromJsonOverwrite(json, _data);
            }
        }
    }
}