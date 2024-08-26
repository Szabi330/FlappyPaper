using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int bestScore;
    public int life;

    public PlayerData(int bestScore, int life)
    {
        this.life = life;
        this.bestScore = bestScore;
    }
}
