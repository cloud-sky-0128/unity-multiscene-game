using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundFollow : MonoBehaviour
{
    private Transform camTF;
    private Vector3 lastFrameCameraPos;
    private float textureUnitSizeX;
    [SerializeField] private Vector2 parallaxFactor;

    void Start()
    {
        camTF = Camera.main.transform;
        lastFrameCameraPos = camTF.position;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Sprite sprite = spriteRenderer.sprite;
        textureUnitSizeX = (sprite.texture.width / sprite.pixelsPerUnit) * transform.localScale.x;

    }

    void Update()
    { 
        Vector2 deltaMovement = camTF.position - lastFrameCameraPos;
        transform.position += new Vector3(deltaMovement.x * parallaxFactor.x, deltaMovement.y * parallaxFactor.y);
        lastFrameCameraPos = camTF.position;

        if (Mathf.Abs(camTF.position.x - transform.position.x) >= textureUnitSizeX)
        {
            float offsetPositionX = (camTF.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(camTF.position.x + offsetPositionX, transform.position.y);
        }
    }
}
