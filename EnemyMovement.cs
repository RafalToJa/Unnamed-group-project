using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class EnemyMovement : Enemy
{
    public int _moveSpeed;
    public int _attackDamage;
    public int _enemyHealth;
    public float _attackRadius;
    public float _followRadius;
    public Transform AttackPoint;
    public float Range;
    public LayerMask PlayerLayer;
    [SerializeField] Transform playerTransform;
    public Animator enemyAnim;
    public float nextTimeAttack = 0;
    public float attackRate;


    SpriteRenderer enemySR;

    void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().GetComponent<Transform>();//'Player' zmienilem 'PlayerMovement'
        enemyAnim = gameObject.GetComponent<Animator>();
        enemySR = GetComponent<SpriteRenderer>();
        setMoveSpeed(_moveSpeed);
        setAttackDamage(_attackDamage);
        setEnemyHealth(_enemyHealth);
        setAttackRadius(_attackRadius);
        setFollowRadius(_followRadius);
    }

    void Update()
    {   if (playerTransform != null)
        {
            if (checkFollowRadius(playerTransform.position.x, transform.position.x))
            {
                if (playerTransform.position.x < transform.position.x)
                {
                    if (checkAttackRadius(playerTransform.position.x, transform.position.x))
                    {
                        
                        enemyAnim.SetBool("Move", false);
                        if (Time.time >= nextTimeAttack)
                        {
                            enemyAnim.SetTrigger("Attack");
                            nextTimeAttack = Time.time + 1f / attackRate;
                        }
                    }
                    else
                    {
                        this.transform.position += new Vector3(-getMoveSpeed() * Time.deltaTime, 0f, 0f);
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        enemyAnim.SetBool("Move", true);
                        
                        
                        
                    }


                }
                else if (playerTransform.position.x > transform.position.x)
                {
                    if (checkAttackRadius(playerTransform.position.x, transform.position.x))
                    {
                        enemyAnim.SetBool("Move", false);
                        if (Time.time >= nextTimeAttack)
                        {
                            enemyAnim.SetTrigger("Attack");
                            nextTimeAttack = Time.time + 1f / attackRate;
                        }

                    }
                    else
                    {
                        this.transform.position += new Vector3(getMoveSpeed() * Time.deltaTime, 0f, 0f);
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                        enemyAnim.SetBool("Move", true);
                        
                        
                    }


                }
            }
            else
            {
                enemyAnim.SetBool("Move", false);

            }
        }
    }
    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, Range, PlayerLayer);
        if (hitEnemies.Length > 0)
        {
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Health>().TakeDamage(_attackDamage);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPoint.position, Range);
    }
}
