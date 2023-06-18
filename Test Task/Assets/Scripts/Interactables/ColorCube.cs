using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCube : Interactable
{
    private Renderer cubeRenderer;
    private Color originalColor;

    private void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        originalColor = cubeRenderer.material.color;
    }

    protected override void Interact()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        cubeRenderer.material.color = randomColor;
    }
}
