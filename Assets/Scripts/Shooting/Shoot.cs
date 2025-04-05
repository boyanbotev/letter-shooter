using System.Collections;
using UnityEngine;

enum ShootState
{
    Ready,
    Charging,
}
public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float shootVelocity = 14.0f;
    [SerializeField] float rechargeTime = 0.5f;
    ShootState shootState = ShootState.Ready;

    void Update()
    {
        if (shootState != ShootState.Ready)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            ShootProjectile(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Reset();
        }
    }

    private void Reset()
    {
        shootState = ShootState.Charging;
        StartCoroutine(Recharge());
    }


    void ShootProjectile(Vector3 mousePos)
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        var dir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y).normalized;
        rb.linearVelocity = dir * shootVelocity;
    }

    IEnumerator Recharge()
    {
        yield return new WaitForSeconds(rechargeTime);
        shootState = ShootState.Ready;
    }
}
