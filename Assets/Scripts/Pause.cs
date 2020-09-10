using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    #region Properties
    public bool paused = true;
    public SpriteRenderer pauseObject;
    public Sprite pauseSprite;
    public Sprite playSprite;
    #endregion

    private void Start()
    {
        pauseObject.sprite = pauseSprite;
    }

    private void Update()
    {
        if (paused)
            pauseObject.sprite = pauseSprite;
        else
            pauseObject.sprite = playSprite;
    }
}
