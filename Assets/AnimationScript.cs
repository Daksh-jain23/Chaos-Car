using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CreditsScroller : MonoBehaviour {
    public ScrollRect scrollRect;
    public TMP_Text creditsText;
    public float scrollSpeed = 10f;
    public float startDelay = 2f;
    public float endDelay = 5f;

    private bool isScrolling = false;
    private float scrollPosition = 0f;
    private float contentHeight;
    private float viewportHeight;

    void Start() {
        // Calculate sizes
        contentHeight = creditsText.rectTransform.rect.height;
        viewportHeight = scrollRect.viewport.rect.height;

        // Start at bottom
        scrollRect.verticalNormalizedPosition = 0f;

        // Begin scrolling after delay
        Invoke("StartScrolling", startDelay);
    }

    void StartScrolling() {
        isScrolling = true;
    }

    void Update() {
        if (isScrolling) {
            // Increment scroll position
            scrollPosition += Time.deltaTime * scrollSpeed;
            float normalizedPosition = scrollPosition / (contentHeight + viewportHeight);

            // Stop when reaching end
            if (normalizedPosition >= 1f) {
                normalizedPosition = 1f;
                isScrolling = false;
                Invoke("OnCreditsComplete", endDelay);
            }

            scrollRect.verticalNormalizedPosition = normalizedPosition;
        }
    }

    void OnCreditsComplete() {
        // Call when credits finish
        Debug.Log("Credits finished scrolling");
    }
}