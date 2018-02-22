﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMouse
    : MonoBehaviour
{
    private Block hover;
    private Block click;

    public void OnEnable()
    {
        StartCoroutine(DoControls());
    }

    private void UpdateHover()
    {
        var cam = Camera.main;
        var pos = Input.mousePosition;
        var ray = cam.ScreenPointToRay(pos);
        var mask = LayerMask.GetMask("Default");

        var info = new RaycastHit();
        var hit = Physics.Raycast(ray, out info, float.MaxValue, mask, QueryTriggerInteraction.Collide);

        if (hit == false)
        {
            if (hover != null)
                hover.OnHoverOff();

            hover = null;
            return;
        }

        var obj = info.collider.gameObject;
        if (obj == null)
        {
            if (hover != null)
                hover.OnHoverOff();

            hover = null;
            return;
        }

        var block = obj.GetComponent<Block>();
        if (block == null)
        {
            if (hover != null)
                hover.OnHoverOff();

            hover = null;
            return;
        }

        if (hover == block)
            return;

        if (hover != null)
            hover.OnHoverOff();

        hover = block;
        hover.OnHoverOn();
    }

    private void UpdateClick()
    {
        if (click == null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hover != null)
                {
                    hover.OnHoverOff();

                    click = hover;
                    click.OnClickOn();
                }
            }

            return;
        }

        if (click != hover)
        {
            click.OnClickOff();
            click = null;

            return;
        }

        if (Input.GetMouseButtonUp(0))
        {
            click.OnClickOff();
            click = null;

            hover.OnHoverOn();
        }
    }

    public IEnumerator DoControls()
    {
        while (true)
        {
            UpdateHover();
            UpdateClick();

            yield return null;
        }
    }
}