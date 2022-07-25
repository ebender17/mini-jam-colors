using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayscaleControl : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private float _duration = 1f;

    void Start () 
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void StartGrayscaleRoutine ()
    {
        StartCoroutine(GrayscaleRoutine(_duration, true));
    }

    public void StartResaturateRoutine ()
    {
        StartCoroutine(GrayscaleRoutine(_duration, false));
    }

    private IEnumerator GrayscaleRoutine (float duration, bool isGrayscale)
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

    public void SetGrayscale (float amount = 1)
    {
        _spriteRenderer.material.SetFloat("_GrayscaleAmount", amount);
    }

}
