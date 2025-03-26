using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public static event System.Action<GameObject, GameObject> OnProjectileCollision;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Projectile>() != null)
        {
            OnProjectileCollision?.Invoke(gameObject, collision.gameObject);
        }
    }
}
