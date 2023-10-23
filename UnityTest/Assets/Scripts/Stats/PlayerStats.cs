using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Stat damage;
    public Stat armour;

    public int maxHealth = 100;

    public int currentHealth {get; private set;}

    void Awake() {
        currentHealth = maxHealth;
       
    }

    void Update() {
        if (Input.getKeyDown(KeyCode.T)) { //T represents Testing and see how the code works
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage) {
        damage -= armour.getValue()
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        Debug.Log(transform.name + " takes " + damage + " damage.");
        currentHealth -= damage;
        if (currentHealth <= 0) {
            Die();
        }
    }

    public virtual void Die() 

}
