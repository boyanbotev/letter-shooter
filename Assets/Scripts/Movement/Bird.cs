using UnityEngine;
using DG.Tweening;

public class Bird : MonoBehaviour
{
    [SerializeField] float yVariation = 0.2f;
    [SerializeField] float flapDuration = 0.7f;
    [SerializeField] float duration = 5;
    void Start()
    {
        transform.DOMoveX(-transform.position.x, duration).SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo)
            .SetRelative(false)
            .SetEase(Ease.InOutSine);


        transform.DOMoveY(yVariation, flapDuration).SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo)
            .SetRelative(true)
            .SetEase(Ease.InOutSine);
    }
}
