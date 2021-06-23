using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int moveSpeed;
    int attackDamage;
    int enemyHealth;
    float attackRadius;
    float followRadius;

    public void setMoveSpeed(int speed)
    {
        moveSpeed = speed;
    }
    public void setAttackDamage(int ad)
    {
        attackDamage = ad;
    }
    public void setEnemyHealth(int enHp)
    {
        enemyHealth = enHp;
    }
    public int getMoveSpeed()
    {
        return moveSpeed;
    }
    public int getAttackDamage()
    {
        return attackDamage;
    }
    public int getEnemyHealth()
    {
        return enemyHealth;
    }

    public void setFollowRadius(float folRad)
    {
        followRadius = folRad;
    }
    public void setAttackRadius(float attRad)
    {
        attackRadius = attRad;
    }

    public bool checkFollowRadius(float playerPosition, float enemyPosition)
    {
        if (Mathf.Abs(playerPosition - enemyPosition) < followRadius) return true;
        else return false;
    }
    public bool checkAttackRadius(float playerPosition, float enemyPosition)
    {
        if (Mathf.Abs(playerPosition - enemyPosition) < attackRadius) return true;
        else return false;
    }


}
