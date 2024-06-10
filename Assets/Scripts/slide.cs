using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public Health playerHealth;
    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = playerHealth.maxHealth;
        healthBar.value = playerHealth.maxHealth;
    }
    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Health : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 100;
    public HealthBar healthBar;
    void Start()
    {
        curHealth = maxHealth;
    }
    void Update()
    {
        if( Input.GetKeyDown( KeyCode.Space ) )
        {
            DamagePlayer(10);
        }
    }
    public void DamagePlayer( int damage )
    {
        curHealth -= damage;
        healthBar.SetHealth( curHealth );
    }
}
Code language: C# (cs)Copied!
Code language: C# (cs)