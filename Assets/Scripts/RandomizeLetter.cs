using UnityEngine;
using TMPro;
using System;

[Serializable]
public class Symbol
{
    public string value;
    public int weight;
}


public class RandomizeLetter : MonoBehaviour
{
    [SerializeField] Symbol[] symbols;
    TextMeshPro text;

    private void Awake()
    {
        text = GetComponent<TextMeshPro>();
        text.text = GetRandomSymbol();
    }

    private string GetRandomSymbol()
    {
        int totalWeight = 0;
        foreach (Symbol symbol in symbols)
        {
            totalWeight += symbol.weight;
        }

        int randomValue = UnityEngine.Random.Range(0, totalWeight);
        int weightSum = 0;

        foreach (Symbol symbol in symbols)
        {
            weightSum += symbol.weight;
            if (randomValue < weightSum)
            {
                return symbol.value;
            }
        }

        return symbols[0].value;
    }


}
