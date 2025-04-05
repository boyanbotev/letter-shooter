using DG.Tweening;
using System.Collections;
using UnityEngine;

public class LetterCollectionManager : MonoBehaviour
{
    public static event System.Action OnCorrectCollect;
    public static event System.Action OnFalseCollect;
    [SerializeField] string targetLetter = "s";
    [SerializeField] Transform collectTransform;
    [SerializeField] bool spawnNewLetter = false;
    [SerializeField] SpawnManager spawnManager;
    [SerializeField] float minSpawnDelay = 5f;
    [SerializeField] float maxSpawnDelay = 6f;

    private void OnEnable()
    {
        Target.OnProjectileCollision += HandleProjectileCollision;
        Leaf.OnLeafDestroy += HandleLeafDestroy;
    }

    private void OnDisable()
    {
        Target.OnProjectileCollision -= HandleProjectileCollision;
        Leaf.OnLeafDestroy -= HandleLeafDestroy;
    }

    private void HandleProjectileCollision(GameObject target, GameObject projectile)
    {
        Destroy(projectile);
        var text = target.GetComponentInChildren<TMPro.TextMeshPro>();

        if (spawnNewLetter)
        {
            StartCoroutine(SpawnNewLetter());
        }

        if (text.text == targetLetter)
        {
            Debug.Log("Correct letter!");

            text.transform.parent = target.transform.parent;
            Destroy(target);

            DOTween.To(() => text.transform.position, x => text.transform.position = x, collectTransform.position, 0.7f).OnComplete(() =>
            {
                Destroy(text.gameObject);
            }).SetEase(Ease.InCubic);

            OnCorrectCollect?.Invoke();
        }
        else
        {
            Debug.Log("Incorrect letter!");
            Destroy(target);
            OnFalseCollect?.Invoke();
        }
    }

    private void HandleLeafDestroy(string letter)
    {
        if (letter == targetLetter)
        {
            OnFalseCollect?.Invoke();
        }
    }

    IEnumerator SpawnNewLetter()
    {
        yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));

        var apple = spawnManager.Spawn();
    }
}
