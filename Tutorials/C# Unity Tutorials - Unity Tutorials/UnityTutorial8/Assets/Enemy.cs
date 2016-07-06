using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    private float maxHealth;
    private float health;

    // Use this for initialization
    void Start()
    {
        maxHealth = 1;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReceiveDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
            Destroy(gameObject);
    }
}
