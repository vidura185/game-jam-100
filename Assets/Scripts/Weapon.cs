using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public bool isAutomatic;
    public abstract void Shoot();

    private void Update()
    {
        if (isAutomatic) {
            if (Input.GetButton("Fire"))
            {

            }
        } else
        {
            if (Input.GetButtonDown("Fire"))
            {

            }
        }
    }
}
