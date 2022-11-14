using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHP;
    public int expDrop;

    public void EnemyDamage(int _Damage)
    {
        enemyHP -= _Damage;
        if (enemyHP <= 0)
        {
            EnemyDeath();
        }
    }

    public void EnemyDeath()
    {
        WaveManager.instance.EnemyDeath();
        PlayerExp.instance.GainExp(expDrop);
        Destroy(gameObject);
    }
}
