using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDebris
    : MonoBehaviour
{
    private float scaleTimer;
    private Vector3 initialScale;

    public void OnEnable()
    {
        scaleTimer = 2.5f;
        initialScale = transform.localScale;
    }

    public void Update()
    {
        scaleTimer -= Time.deltaTime;

        transform.localScale = Mathf.Clamp01(scaleTimer) * initialScale;

        if (scaleTimer <= 0.0f)
            Destroy(gameObject);
    }
}
