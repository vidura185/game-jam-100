using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormholeGun : MonoBehaviour
{
    public int ammo;
    public int fireRate;
    public int wormholeGrowthTime;

    public GameObject wormholeEntrance;
    public GameObject wormholeExit;

    Player owningPlayer;
    //Grenade has
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire"))
        {
            if (ammo <= 0)
            {
            }
        }
    }

    void Shoot()
    {

    }
}

public struct WormholeProjectile
{
    public int radius;
}