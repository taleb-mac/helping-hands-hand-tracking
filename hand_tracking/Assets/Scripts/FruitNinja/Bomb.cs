using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Bomb : MonoBehaviour
{

    Image fadeImage;
    RectTransform scoreText;

    private void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<RectTransform>();
        fadeImage = GameObject.FindGameObjectWithTag("Image").GetComponent<Image>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            Time.timeScale = 0f;
            GetComponent<Collider>().enabled = false;
            ExplodeSeq();
        }
    }

    private void ExplodeSeq()
    {
        scoreText.anchorMin = new Vector2(0.5f, 0.5f);
        scoreText.anchorMax = new Vector2(0.5f, 0.5f);
        scoreText.pivot = new Vector2(0.5f, 0.5f);
        scoreText.localPosition = new Vector3(0, 5f, scoreText.position.z);
        StartCoroutine(ExplodeSequence());

    }

    private IEnumerator ExplodeSequence()
    {
        float elapsed = 0f;
        float duration = 0.5f;
        
        // Fade to white
        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.clear, Color.black, t);
            elapsed += Time.unscaledDeltaTime;

            yield return null;
        }
    }


}
