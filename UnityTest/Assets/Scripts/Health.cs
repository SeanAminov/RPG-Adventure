using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount) {
        currentHealth -= amount;

        if (currentHealth <= 0) {
         //   anim.setBool
         //Death Animation
         
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
