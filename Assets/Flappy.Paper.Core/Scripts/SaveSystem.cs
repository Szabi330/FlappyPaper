using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SavePlayer(int bestScore, int life)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "player.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(bestScore, life);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "player.save";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            SavePlayer( 0, 50);

            return new PlayerData(0, 50);
        }

    }

    public static void SaveNextFreeLive()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "freeLive.save";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, DateTime.Now.ToBinary());
        stream.Close();
    }

    public static DateTime LoadNextFreeLive()
    {
        string path = Application.persistentDataPath + "freeLive.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            long data = (long)formatter.Deserialize(stream);
            stream.Close();
             
            return DateTime.FromBinary(data);
        }
        else
        {
            SaveNextFreeLive();

            return DateTime.Now;
        }
    }
}
