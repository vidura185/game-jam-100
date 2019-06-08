using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    public float ammo;
    public float depletionRate;
    public GameObject gravityStream;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    void Shoot()
    {
        if (ammo <= 0)
        {
            ammo -= depletionRate;
            gravityStream.transform.rotation = Quaternion.LookRotation(Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position);
        }
    }

    void AttractEnemies()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

