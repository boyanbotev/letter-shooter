using UnityEngine;

public class Projectile : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating(nameof(CheckIfDestroy), 2f, 0.5f);
    }

    void CheckIfDestroy() {
        if (transform.position.y < -6.0f)
        {
            Destroy(gameObject);
        }
    }
}
