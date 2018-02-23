using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block
    : MonoBehaviour
{
    private Renderer meshRenderer;
    private MaterialPropertyBlock meshMaterialProperty;

    public void OnEnable()
    {
        meshRenderer = GetComponentInChildren<Renderer>();
        meshMaterialProperty = new MaterialPropertyBlock();
    }

    public void OnHoverOff()
    {
        SetColor(Color.white);
    }

    public void OnHoverOn()
    {
        SetColor(Color.cyan);
    }

    public void OnClickOff()
    {
        SetColor(Color.white);
    }

    public void OnClickOn()
    {
        SetColor(Color.red);
    }

    public void SetClickTimer(float t)
    {
        SetColor(Color.Lerp(Color.red, Color.green, t));
    }

    public void Pop()
    {
        Destroy(gameObject);
    }

    private void SetColor(Color color)
    {
        meshMaterialProperty.SetColor("_Color", color);
        meshRenderer.SetPropertyBlock(meshMaterialProperty);
    }
}
