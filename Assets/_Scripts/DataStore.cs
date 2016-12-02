﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataStore : MonoBehaviour{


    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo43.dat");

        PlayerData data = new PlayerData();
        data.life = Player.life;
        data.boostPoints += Player.boostPoints;
        data.completedLevels = Player.completedLevels;
        data.levelScores = Player.levelScores;
        data.completedLevelsHardMode = Player.completedLevelsHardMode;
        data.levelScoresHardMode = Player.levelScoresHardMode;
        data.snowFlakes = Player.snowFlakes;
        data.specialHero = Player.specialHero;
        data.tutorial = Player.tutorial;
        data.adFree = Player.adFree;
        data.gameMode = Player.gameMode;

        bf.Serialize(file, data);
        file.Close();
        
    }

    public static void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo43.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo43.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            Player.life = data.life;
            Player.boostPoints = data.boostPoints;
            Player.completedLevels = data.completedLevels;
            Player.levelScores = data.levelScores;
            Player.completedLevelsHardMode = data.completedLevelsHardMode;
            Player.levelScoresHardMode = data.levelScoresHardMode;
            Player.snowFlakes = data.snowFlakes;
            Player.specialHero = data.specialHero;
            Player.tutorial = data.tutorial;
            Player.adFree = data.adFree;
            Player.gameMode = data.gameMode;

        }
        else
        {
            Player.specialHero = 5;
            Player.snowFlakes = 3; // dont forget to remove this or reduce the number
            Player.completedLevels.Add(1, 3); //change back to 0
            Player.completedLevelsHardMode.Add(1, 3);

            Player.levelScores.Add(1, 0);
            Player.levelScoresHardMode.Add(1, 0);
            for (int i = 2; i <= 12; i++)
            {
                Player.completedLevels.Add(i, 3); //change back to -1
                Player.levelScores.Add(i, 0); //change back to 0
                Player.completedLevelsHardMode.Add(i, 3); //change back to -1
                Player.levelScoresHardMode.Add(i, 0); //change back to 0
            }
        }
    }
}

[Serializable]
class PlayerData
{
    public int life;
    public int boostPoints;
    public int snowFlakes;
    public int specialHero;
    public Dictionary<int, int> completedLevels;
    public Dictionary<int, int> levelScores;
    public Dictionary<int, int> completedLevelsHardMode;
    public Dictionary<int, int> levelScoresHardMode;
    public bool tutorial = false;
    public bool adFree = false;
    public bool gameMode = false;
}
