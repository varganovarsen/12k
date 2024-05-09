using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    float deathSpeed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player"))
            return;

        if (Mathf.Abs(PlayerMovement.Instance.Velocity.y) > deathSpeed)
        {
            PlayerHealth.Instance.DealDamage(999);
        }
        else
        {
            PlayerHealth.Instance.ResetHealth();
            PlayerMovement.Instance.Freeze(true);
            PlayerMovement.Instance.IsOnPlatform = true;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
