using System;
using SQLite4Unity3d;
using UnityEngine;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine.Serialization;

public class DataService : MonoBehaviour
{
    private SQLiteConnection _connection;
    public static DataService Instance;
    private string _streamingAssetsPath;
    private void Awake()
    {
        Instance = this;
        DetectStreamingAssetFolder();
        InitailSqLiteConnection();
    }
    
    public void CreateTable<T>()
    {
        _connection.CreateTable<T>();
    }
    
    public void DelectTable<T>()
    {
        _connection.DropTable<T>();
    }
    
    public void DelectDataInTable<T>(int index) where T : new()
    {
        _connection.Delete<T>(index);
    }
    
    public void InsertDataToTable<T>(T data)
    {
        _connection.Insert(data);
    }
    public IEnumerable<T> SelectDataInTable<T>(Func<T, bool> predicate) where T : new()
    {
        return _connection.Table<T>().Where(predicate).ToList();
    }
    
    private void InitailSqLiteConnection()
    {
        string dbPath = DetectDataBaseFile();
        _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
    }
    private void DetectStreamingAssetFolder()
    {
        _streamingAssetsPath = Path.Combine(Application.streamingAssetsPath, "Database");

        if (!Directory.Exists(_streamingAssetsPath))
        {
            Directory.CreateDirectory(_streamingAssetsPath);
        }
    }
    private string DetectDataBaseFile()
    {
        string dbPath = Path.Combine(_streamingAssetsPath, "GameDatabase.db");

        if (!File.Exists(dbPath))
        {
            File.Create(dbPath);
        }

        return dbPath;
    }
}
