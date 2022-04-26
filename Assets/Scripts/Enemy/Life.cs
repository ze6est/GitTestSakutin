using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    private int _life = 1;    
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ApplyLife(_life);
        }

        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
