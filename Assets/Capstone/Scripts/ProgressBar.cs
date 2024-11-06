using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField]
    private RectTransform cover;
    [SerializeField]
    private RectTransform bar;

    public float value = 100;
    public float padding = 10;
    
    private void Start()
    {
        Render();
    }
    public void Render()
    {
        bar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, GetPercent() - padding);
    }
    private float GetPercent()
    {
        return (cover.rect.width / 100) * value;
    }
}
