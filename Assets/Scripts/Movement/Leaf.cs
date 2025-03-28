using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Leaf : MonoBehaviour
{
    public static event System.Action<string> OnLeafDestroy;
    [SerializeField] private float minHorizontalSpeed;
    [SerializeField] private float maxHorizontalSpeed;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float verticalSpeed;
    [SerializeField] private float minXDistance = 3.0f;
    [SerializeField] private float maxDdistance = 5.0f;
    [SerializeField] private float xDistance = 4.0f;
    [SerializeField] private float destroyY = -1.0f;
    [SerializeField] private float rotationAmount = 15.0f;
    [SerializeField] bool increaseSpeed = false;
    GameObject leafAnimation;

    private void Awake()
    {
        horizontalSpeed = Random.Range(minHorizontalSpeed, maxHorizontalSpeed);
        xDistance = Random.Range(minXDistance, maxDdistance);
        leafAnimation = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (transform.position.y < destroyY)
        {
            var renderer = leafAnimation.GetComponent<SpriteRenderer>();
            DOTween.To(() => renderer.color, x => renderer.color = x, new Color(1, 1, 1, 0), 0.5f).OnComplete(() =>
            {
                OnLeafDestroy?.Invoke(GetComponentInChildren<TextMeshPro>().text);
                Destroy(gameObject);
            });
        }

        Move();
        Rotate();
        IncreaseSpeed();
    }

    void Move() {
        float x = Mathf.Cos(Time.time * horizontalSpeed) * xDistance;
        float y = transform.position.y - verticalSpeed * Time.deltaTime;

        transform.position = new Vector3(x, y, transform.position.z);
    }

    void Rotate()
    {
        float rotation = Mathf.Sin(Time.time * horizontalSpeed) * rotationAmount;
        leafAnimation.transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    void IncreaseSpeed()
    {
        if (increaseSpeed)
        {
            DOTween.To(() => verticalSpeed, x => verticalSpeed = x, 6, 4f).SetEase(Ease.Linear);
        }
    }
}
