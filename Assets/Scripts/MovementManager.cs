using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementManager : MonoBehaviour
{
    [SerializeField] private int rows = 2;
    [SerializeField] private int rowLength = 5;
    [SerializeField] private Vector2 speed = new(0.1f, 0.3f);
    [SerializeField] private float xDistance = 4.0f;
    [SerializeField] private Vector2 letterSpacing = new (1, 1);
    [SerializeField] private GameObject letterPrefab;
    [SerializeField] Transform container;

    // TODO: create a group of letters, evenly spaced
    // move down the screen as in space invaders
    // move left and right as in space invaders

    private void Start()
    {
        CreateLetters();
    }

    private void Update()
    {
        float x = Mathf.Cos(Time.time * speed.x) * xDistance;
        float y = container.position.y - speed.y * 0.001f;
        container.position = new Vector3(x, y, 0);
        speed.x += 0.00002f;
    }

    void CreateLetters()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < rowLength; j++)
            {
                GameObject letter = Instantiate(letterPrefab, container);
                float x = j * letterSpacing.x - letterSpacing.x * (rowLength - 1) / 2;
                float y = i * -letterSpacing.y + letterSpacing.y * (rows -1) / 2;

                letter.transform.localPosition = new Vector3(x, y, letter.transform.position.z);
            }
        }
    }

}
