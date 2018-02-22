using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block
    : MonoBehaviour
{
    private Renderer meshRenderer;
    private Material meshMaterial;

    public void OnEnable()
    {
        meshRenderer = GetComponentInChildren<Renderer>();
        meshMaterial = meshRenderer.material;
    }

    public void OnHoverOff()
    {
        meshMaterial.color = Color.white;
    }

    public void OnHoverOn()
    {
        meshMaterial.color = Color.cyan;
    }

    public void OnClickOff()
    {
        meshMaterial.color = Color.white;
    }

    public void OnClickOn()
    {
        meshMaterial.color = Color.red;
    }

    public void SetClickTimer(float t)
    {
        meshMaterial.color = Color.Lerp(Color.red, Color.green, t);
    }

    public void Pop()
    {
        Destroy(gameObject);
    }
}
