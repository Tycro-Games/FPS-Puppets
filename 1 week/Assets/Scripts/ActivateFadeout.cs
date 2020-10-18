using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFadeout : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve multiCurve;

    [SerializeField]
    private float multiplier;

    private Renderer meshRenderer = null;
    private MaterialPropertyBlock propBlock = null;

    public void StartingFade ()
    {
        StartCoroutine (StartFading ());
    }

    private IEnumerator StartFading ()
    {
        float val = 0;
        while (val < 1)
        {
            meshRenderer.GetPropertyBlock (propBlock);
            val += multiplier * Time.deltaTime;
            val += val * multiCurve.Evaluate (Mathf.InverseLerp (0, 1, val));
            propBlock.SetFloat ("_Dissolve", val);
            meshRenderer.SetPropertyBlock (propBlock);
            yield return null;
        }
        Destroy (gameObject);
    }

    private void Start ()
    {
        propBlock = new MaterialPropertyBlock ();
        meshRenderer = GetComponent<Renderer> ();
    }
}