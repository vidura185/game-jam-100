using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void StartGame(int startingLevel = 0)
    {
        //spawn characters
        //character prefab should already have ammo set to 100
    }

    public void SetDead(Player player)
    {
        //if only one player is alive, increment that players score count and load next level
    }

}
