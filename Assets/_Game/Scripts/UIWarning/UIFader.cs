using DG.Tweening;
using MEC;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFader : MonoBehaviour {
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float fadeDuration = 5f;
    [SerializeField] int sceneID = 1;

    void Start() {
        canvasGroup.alpha = 0f;
        canvasGroup.DOFade(1f, fadeDuration)
            .SetEase(Ease.InOutQuad)
            .SetLoops(2, LoopType.Yoyo);

        Timing.CallDelayed(fadeDuration * 2, () => { SceneManager.LoadSceneAsync(sceneID); });
    }
}
