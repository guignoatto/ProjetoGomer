using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private int maxZoom;
    [SerializeField] private int minZoom;
    [Range(0, 10)] 
    [SerializeField] private float zoomOutDuration;
    [Range(0, 10)]
    [SerializeField] private float zoomInDuration;

    public bool zoomIn = false;
    public bool zoomOut = false;
    private float lerp;

    private void Update()
    {
        if (zoomIn)
        {
            zoomOut = false;
            ZoomInLerp(maxZoom, minZoom, lerp);
            lerp -= Time.deltaTime / zoomInDuration;
        }

        if (zoomOut)
        {
            zoomIn = false;
            ZoomOutLerp(maxZoom, minZoom, lerp);
            lerp += Time.deltaTime / zoomOutDuration;
        }
    }

    private void ZoomInLerp(int maxZoom, int minZoom, float lerp)
    {
        Camera.main.orthographicSize = Mathf.Lerp(minZoom, maxZoom, lerp);
        if (lerp <= 0)
        {
            lerp = 0;
            zoomIn = false;
        }
    }

    private void ZoomOutLerp(int maxZoom, int minZoom, float lerp)
    {
        Camera.main.orthographicSize = Mathf.Lerp(minZoom, maxZoom, lerp);
        if (lerp >= 1)
        {
            lerp = 1;
            zoomOut = false;
        }
    }
}