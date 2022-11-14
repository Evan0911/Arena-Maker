using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public bool canAttack = true;
    public int damage;
    public int cooldown;
    public bool attackButtonPressed = false;

    public static PlayerAttacks instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerAttack dans la scène");
            return;
        }

        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && canAttack == true)
        {
            attackButtonPressed = true;
        }
        else
        {
            attackButtonPressed = false;
        }
    }

    IEnumerator Cooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && canAttack == true && attackButtonPressed == true)
        {
            collision.GetComponent<EnemyHealth>().EnemyDamage(damage);
            Console.WriteLine(collision.GetComponent<EnemyHealth>().enemyHP);
            StartCoroutine(Cooldown());

        }
    }
}
