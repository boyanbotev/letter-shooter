using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    [SerializeField] private float minHorizontalSpeed;
    [SerializeField] private float maxHorizontalSpeed;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float verticalSpeed;
    [SerializeField] private float minXDistance = 3.0f;
    [SerializeField] private float maxDdistance = 5.0f;
    [SerializeField] private float xDistance = 4.0f;
    [SerializeField] private float destroyY = -6.0f;
    [SerializeField] private float rotationAmount = 15.0f;

    private void Awake()
    {
        horizontalSpeed = Random.Range(minHorizontalSpeed, maxHorizontalSpeed);
        xDistance = Random.Range(minXDistance, maxDdistance);
    }

    private void Update()
    {
        if (transform.position.y < destroyY)
        {
            Destroy(gameObject);
        }

        Move();
        Rotate();
    }

    void Move() {
        float x = Mathf.Cos(Time.time * horizontalSpeed) * xDistance;
        float y = transform.position.y - verticalSpeed * Time.deltaTime;

        transform.position = new Vector3(x, y, transform.position.z);
    }

    void Rotate()
    {
        float rotation = Mathf.Sin(Time.time * horizontalSpeed) * rotationAmount;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
}
