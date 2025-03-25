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
    [SerializeField] LineManager lineManager;
    [SerializeField] float minShootVelocity = 8.0f;
    [SerializeField] float maxShootVelocity = 14.0f;
    [SerializeField] float velocityIncrement = 2f;
    [SerializeField] float rechargeTime = 0.5f;
    float shootVelocity;
    ShootState shootState = ShootState.Ready;


    private void Awake()
    {
        shootVelocity = minShootVelocity;
    }

    void Update()
    {
        if (shootState != ShootState.Ready)
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            if (shootVelocity < maxShootVelocity)
            {
                shootVelocity += Time.deltaTime * velocityIncrement;
            }

            DrawLine();
        }

        if (Input.GetMouseButtonUp(0))
        {
            ShootProjectile(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Reset();
        }
    }

    private void Reset()
    {
        shootVelocity = minShootVelocity;
        lineManager.Clear();
        shootState = ShootState.Charging;
        StartCoroutine(Recharge());
    }

    void DrawLine()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var dir = new Vector3(mousePos.x - transform.position.x, mousePos.y - transform.position.y).normalized;
        lineManager.Draw(transform.position, dir * shootVelocity * shootVelocity * 0.05f);
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
