using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireboll : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float damage = 10;

    void Start()
    {
        Invoke("DestroyFireboll",lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {

        DamageEneny(collision);

        DestroyFireboll();
    }

    private void DamageEneny(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHeal>();
        if (enemyHealth != null)
        {

            enemyHealth.DealDamege(damage);
            
        }
    }
    void FixedUpdate()
    {
        MoveFixedUpdate();
    }

    private void MoveFixedUpdate()
    {
       transform.position += transform.forward * speed * Time.fixedDeltaTime; 
    }

    private void DestroyFireboll()
    {
        Destroy(gameObject);
    }    
}
