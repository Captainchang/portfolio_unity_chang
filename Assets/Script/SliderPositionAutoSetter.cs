using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPositionAutoSetter : MonoBehaviour
{
    [SerializeField]
    private Vector3 distance = Vector3.down * 35.0f;
    private Transform targetTransform;
    private RectTransform rectTransform;
   
    public void Setup(Transform target)
    {
        // Slider UI°¡ ¦i¾Æ´Ù´Ò target ¼³Á¤
        targetTransform= target;
        // RectTransform ÄÄÆ÷³ÍÆ®
        rectTransform = target.GetComponent<RectTransform>();   
    }

    private void LateUpdate()
    {
        if (targetTransform == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetTransform.position);

        rectTransform.position = screenPosition + distance;
    }
}
