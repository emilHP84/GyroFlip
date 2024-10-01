using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FullScreenFlipEffect : MonoBehaviour
{
    [Header("Time Stats")]
    [SerializeField] private float _FlipDisplayTime = 1.5f;
    [SerializeField] private float _FlipFadeOutTime = 0.5f;

    [Header("References")]
    [SerializeField] private ScriptableRendererFeature _FullScreenEffect;
    [SerializeField] private Material _material;

    private int _voronoiintensity = Shader.PropertyToID("_VoronoiIntensity");
    private int _vignetteIntensity = Shader.PropertyToID("_VignetteIntensity");

    private const float VORONOI_INTENSITY_START_AMOUNT = 1.25f;
    private const float VIGNETTE_INTENSITY_START_AMOUNT = 1.25f;

    private void Start()
    {
        _FullScreenEffect.SetActive(false);
    }

    public void StartFlip()
    {
        StartCoroutine(Flip());
    }
    private IEnumerator Flip()
    {
        _FullScreenEffect.SetActive(true);
        _material.SetFloat(-_voronoiintensity, VORONOI_INTENSITY_START_AMOUNT);
        _material.SetFloat(-_vignetteIntensity, VIGNETTE_INTENSITY_START_AMOUNT);

        yield return new WaitForSeconds(_FlipDisplayTime);

        float elapsedTime = 0f;
        while (elapsedTime < _FlipFadeOutTime)
        {
            elapsedTime += Time.deltaTime;

            float LerpedVoronoi = Mathf.Lerp(VORONOI_INTENSITY_START_AMOUNT, 0f, (elapsedTime / _FlipFadeOutTime));
            float LerpedVignette = Mathf.Lerp(VIGNETTE_INTENSITY_START_AMOUNT ,0f, (elapsedTime / _FlipFadeOutTime));

            _material.SetFloat(_voronoiintensity, LerpedVoronoi);
            _material.SetFloat(_vignetteIntensity, LerpedVignette);

            yield return null;
        }
        _FullScreenEffect.SetActive(false);
    }
}
