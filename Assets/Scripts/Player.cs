using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody;

    public float health;
    public int maxHealth;

    //Horizontal Movement
    public float acceleration;
    public float maxRunVelocity;

    //Vertical Jump
    public float timeSinceLastJump = 100;
    public float jumpInterval;

    public float jumpVelocity;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    public bool jump = true;

    public bool onPlatform;
    public float timeStationary;
    public int maxJumps = 3;
    public int jumpCount = 0;

    public Quaternion lookRotation;
    public Transform weaponHolder;

    public Animator animator;


    //Coroutines 
    public Coroutine stunCoroutine;

    public bool isStunned = true;
    public bool isAlive = true;
    public void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //Jumping
        timeSinceLastJump += Time.fixedDeltaTime;
        if (jump && Input.GetButtonDown("Jump") && timeSinceLastJump > jumpInterval)
        {
            Debug.Log("jump");
            if (jumpCount < maxJumps)
            {
                rigidbody.velocity += Vector2.up * jumpVelocity;
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpVelocity * (1 + Mathf.Clamp(Mathf.Abs(rigidbody.velocity.x/50),0,1)));
                timeSinceLastJump = 0;
                jumpCount++;
            }            
        }
        if (rigidbody.velocity.y < 0)
        {
            rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else
        {
            rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        //Horizontal Movement
        if (Input.GetAxisRaw("Horizontal") > 0 && rigidbody.velocity.x < maxRunVelocity)
        {
            rigidbody.velocity += Vector2.right * acceleration * Time.fixedDeltaTime;
            timeStationary = 0;
        }

        if (Input.GetAxisRaw("Horizontal") < 0 && -rigidbody.velocity.x < maxRunVelocity)
        {
            rigidbody.velocity += Vector2.left * acceleration * Time.fixedDeltaTime;
            timeStationary = 0;
        }

        if (Input.GetAxisRaw("Horizontal") == 0 && onPlatform)
        {
            timeStationary += Time.deltaTime;

            rigidbody.velocity = new Vector2(rigidbody.velocity.x/(Mathf.Pow(Mathf.Clamp(timeStationary * 5,1,5),2f)),rigidbody.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            onPlatform = true;
            Debug.Log("Enter Platform");
        }
        jumpCount = 0;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            onPlatform = false;
            Debug.Log("Exit Platform");
        }
    }

    public void ThrowWeapon()
    {

    }

    public void EquipWeapon(Weapon weapon)
    {
        Weapon weaponInstance = Instantiate(weapon);
    }

    public void DoDamage(float damage)
    {
        health -= Mathf.Clamp(health-damage, 0, maxHealth);
        if (health <= 0)
        {
            Death();
        }
    }

    public IEnumerator SetStunned(float stunDuration)
    {
        float stunTimer = 0;
        isStunned = false;
        while (stunTimer < stunDuration)
        {
            stunTimer += Time.deltaTime;
            yield return null;
        }
        isStunned = true;
    }
    public void Death(string animatorName = "defaultDeath")
    {
        Destroy(gameObject);
        //Notify game manager of death and destroy game object
    }
}

