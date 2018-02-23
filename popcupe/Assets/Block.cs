using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block
    : MonoBehaviour
{
    public GameObject prefabDebris;

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
        for (int i = 0; i < 4; ++i)
        {
            var p = transform.position + Random.onUnitSphere * transform.localScale.x * 0.5f;
            var o = GameObject.Instantiate(prefabDebris);

            o.transform.position = p;
            o.transform.rotation = Quaternion.LookRotation(Random.onUnitSphere);

            var rb = o.GetComponent<Rigidbody>();

            rb.AddForce(Vector3.up * 200.0f, ForceMode.Acceleration);
            rb.AddForce(Random.onUnitSphere * 100.0f, ForceMode.Acceleration);
        }

        Destroy(gameObject);
    }

    private void SetColor(Color color)
    {
        meshMaterialProperty.SetColor("_Layer0Tint", color);
        meshMaterialProperty.SetColor("_Color", color);
        meshRenderer.SetPropertyBlock(meshMaterialProperty);
    }
}
