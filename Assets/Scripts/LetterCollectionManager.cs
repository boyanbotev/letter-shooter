using DG.Tweening;
using UnityEngine;

public class LetterCollectionManager : MonoBehaviour
{
    [SerializeField] string targetLetter = "s";
    [SerializeField] Transform collectTransform;

    private void OnEnable()
    {
        Target.OnProjectileCollision += HandleProjectileCollision;
    }

    private void OnDisable()
    {
        Target.OnProjectileCollision -= HandleProjectileCollision;
    }

    private void HandleProjectileCollision(GameObject target, GameObject projectile)
    {
        Destroy(projectile);
        var text = target.GetComponentInChildren<TMPro.TextMeshPro>();

        if (text.text == targetLetter)
        {
            Debug.Log("Correct letter!");

            text.transform.parent = target.transform.parent;
            Destroy(target);

            DOTween.To(() => text.transform.position, x => text.transform.position = x, collectTransform.position, 0.7f).OnComplete(() =>
            {
                Destroy(text.gameObject);
            }).SetEase(Ease.InCubic);
        }
        else
        {
            Debug.Log("Incorrect letter!");
        }
    }
}
