using System.Collections;
using UnityEngine;


public class GrayscaleControl : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private float duration = 10f;


    private MaterialPropertyBlock propertyBlock = null;


    public void StartGrayscaleRoutine()
    {
        StartCoroutine(GrayscaleRoutine(duration, true));
    }

    public void StartResaturateRoutine()
    {
        StartCoroutine(GrayscaleRoutine(duration, false));
    }

    private IEnumerator GrayscaleRoutine(float duration, bool isGrayscale)
    {
        float time = 0;
        while(duration > time)
        {
            float durationFrame = Time.deltaTime;
            float ratio = time / duration;
            float grayAmount = isGrayscale ? ratio : 1-ratio;
            SetGrayscale(grayAmount);
            time += durationFrame;
            yield return null;
        }

        SetGrayscale(isGrayscale ? 1 : 0);
    }

    public void SetGrayscale(float amount = 1)
    {
        if (propertyBlock == null) { propertyBlock = new MaterialPropertyBlock(); } 
        spriteRenderer.GetPropertyBlock(propertyBlock);
        propertyBlock.SetFloat("_GrayscaleAmount", amount);
        spriteRenderer.SetPropertyBlock(propertyBlock);
        Debug.Log("Have set property block");
    }
}
