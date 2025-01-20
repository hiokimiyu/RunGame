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
    [SerializeField, Header("�ۑ���")] string _fileName;

    void Start()
    {
        Debug.Log(Application.dataPath);
        Debug.Log(Application.persistentDataPath);

        _filePath = $"{Application.persistentDataPath}/{_fileName}.json";
        _data = GetComponent<SaveData>();

        //���̖��O�̃t�@�C���Ȃ����V�������̖��O�Ńt�@�C����V�K�쐬
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

        //�f�[�^��json�ɕϊ�����
        string json = JsonUtility.ToJson(_data);
        Debug.Log(json);
        //�t�@�C���̏�������
        using (StreamWriter wrter = new StreamWriter(_filePath, false))
        {
            //�����w�肵���t�@�C���ɏ�������
            wrter.WriteLine(json);
            //�t�@�C�������
            wrter.Close();
        }
    }

    void Load()
    {
        if (File.Exists(_filePath))
        {
            //�t�@�C���̓ǂݍ���
            using (StreamReader sr = new StreamReader(_filePath))
            {
                //�t�@�C���̓��e��S�ēǂݍ���
                string json = sr.ReadToEnd();
                Debug.Log(json);
                sr.Close();
                JsonUtility.FromJsonOverwrite(json, _data);
            }
        }
    }
}