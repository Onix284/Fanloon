using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroller : MonoBehaviour
{
    public Renderer meshRenderer;
    public float speed = 1.0f;
    public FanManager1 fanManager;
    Vector2 offset;

    void Start()
    {
        offset = meshRenderer.material.mainTextureOffset;
    }

    void Update()
    {
        if (fanManager == null) return;

        if (fanManager.baloonIsBlowed)
        {
            offset += new Vector2(-speed * Time.deltaTime, 0);
        }
        else
        {
            offset = offset + new Vector2(speed * Time.deltaTime, 0);;
        }

        meshRenderer.material.mainTextureOffset = offset;
    }
}
