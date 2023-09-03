using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{

    public static int currentLevel;
    public static int loopbackCount;
    public static int scorePoints;
    public static int enemiesKilled;

    public static void Initialize()
    {
        currentLevel = 1;
        loopbackCount = 0;
        scorePoints = 0;
        enemiesKilled = 0;
    }

    //TODO: HOLDS INFORMATION ABOUT
    //              CURRENT LEVEL
    //              HOW MANY LOOPBACKS HAPPENED ALREADY
    //              SCORE POINTS
    //              ENEMIES KILLED

}
