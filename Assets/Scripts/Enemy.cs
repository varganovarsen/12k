using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    float ForceToDestroy;
    [SerializeField]
    int damage;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;


        if (Mathf.Abs(PlayerMovement.Instance.Velocity.y) > ForceToDestroy)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player"))
            return;
        GetComponent<Collider2D>().enabled = false;
        PlayerHealth.Instance.DealDamage(damage);
    }
}
