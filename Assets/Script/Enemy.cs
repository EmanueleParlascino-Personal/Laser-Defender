using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] float health = 100;
    float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTime = 3f;

    [Header("Stuff")]
    [SerializeField] GameObject LaserPrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] GameObject DeathVFX;
    [SerializeField] float explTime = 1f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0,1)] float deathVolume = 0.6f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float pewpewVolume = 0.3f;
    [SerializeField] int scoreValue = 100;

  

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }
    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTime);
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(LaserPrefab, transform.position, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, pewpewVolume);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Destroy(gameObject);
            GameObject vfx = Instantiate(DeathVFX, transform.position, transform.rotation);
            Destroy(vfx, explTime);
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathVolume);
            FindObjectOfType<GameSession>().AddtoScore(scoreValue);
        }
    }

}
