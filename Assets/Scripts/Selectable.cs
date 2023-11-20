using System.Collections;
using UnityEngine;

public abstract class Selectable : MonoBehaviour
{
    static readonly float selectionTime = 2;

    [SerializeField]
    Color selectedColor;

    MeshRenderer[] meshRenderers;
    Color[] originalColors;

    Coroutine selectionCoroutine = null;

    public abstract void OnPointerClick();

    protected virtual void Start()
    {
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        originalColors = new Color[meshRenderers.Length];
        for (int i = 0; i < meshRenderers.Length; ++i)
        {
            originalColors[i] = meshRenderers[i].material.color;
        }
    }

    public void OnPointerEnter()
    {
        if (selectionCoroutine == null)
        {
            selectionCoroutine = StartCoroutine(SelectByTime());
        }
        foreach (var meshRenderer in meshRenderers)
        {
            meshRenderer.material.color = selectedColor;
        }
    }

    public void OnPointerExit()
    {
        if (selectionCoroutine != null)
        {
            StopCoroutine(selectionCoroutine);
            selectionCoroutine = null;
        }
        for (int i = 0; i < originalColors.Length; ++i)
        {
            meshRenderers[i].material.color = originalColors[i];
        }
    }

    IEnumerator SelectByTime()
    {
        yield return new WaitForSeconds(selectionTime);
        OnPointerClick();
    }
}
