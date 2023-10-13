using System.Collections;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    public static FloatingText instance;
    private void Awake()
    {
        instance = this;
    }
    [SerializeField] private Canvas _damageTextCanvas;
    [SerializeField] private float _textFontSize = 20;
    [SerializeField] private TMP_FontAsset _textFont;
    private Camera _referenceCamera;
    private IEnumerator GenerateFloatingTextCoroutine(string text, Transform target, float duration = 0.5f, float speed = 50f)
    {
        if (target == null)
        {
            yield break;
        }

        Vector3 targetPosition = target.position; 

        GameObject textObj = new GameObject("Damage Floating Text");

        RectTransform rect = textObj.AddComponent<RectTransform>();
        TextMeshProUGUI tmPro = textObj.AddComponent<TextMeshProUGUI>();

        tmPro.text = text;
        tmPro.horizontalAlignment = HorizontalAlignmentOptions.Center;
        tmPro.verticalAlignment = VerticalAlignmentOptions.Middle;
        tmPro.fontSize = _textFontSize;
     
        

        if (_textFont)
        {
            tmPro.font = _textFont;
        }

        rect.position = _referenceCamera.WorldToScreenPoint(targetPosition);

        Destroy(textObj, duration);

        textObj.transform.SetParent(instance._damageTextCanvas.transform);
        textObj.transform.SetAsFirstSibling();
        WaitForEndOfFrame w = new WaitForEndOfFrame();

        float t = 0;
        float yOffset = 0;

        while (t < duration)
        {
            yield return w;
            t += Time.deltaTime;

            if (rect == null)
            {
                yield break;
            }

            tmPro.color = new Color(tmPro.color.r, tmPro.color.g, tmPro.color.b, 1 - t / duration);
            yOffset += speed * Time.deltaTime;

            if (rect == null)
            {
                yield break;
            }

            rect.position = _referenceCamera.WorldToScreenPoint(targetPosition + new Vector3(0, yOffset));
        }
    }



    public static void GenerateFloatingText(string text, Transform target, float duration = 0.5f, float speed = 1f)
    {
        if (!instance._damageTextCanvas)
        {
            return;
        }
        if (!instance._referenceCamera)
        {
            instance._referenceCamera = Camera.main;
        }
        instance.StartCoroutine(instance.GenerateFloatingTextCoroutine(text, target, duration, speed));
    }
    public void StartFloatingTextCoroutine(string text, Transform target, float duration = 0.5f, float speed = 50f)
    {
        StartCoroutine(GenerateFloatingTextCoroutine(text, target, duration, speed));
    }


}
