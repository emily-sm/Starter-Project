using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
 public SpriteRenderer spriteRenderer;
 public Sprite spriteOne;
 public Sprite spriteTwo;
 public int animalNumber;
 private Manager manager;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        manager = FindObjectOfType<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void OnMouseDown()
    {
        spriteRenderer.sprite = spriteTwo;
    }

    void OnMouseUp()
    {
        spriteRenderer.sprite = spriteOne;

        manager.AnimalClicked(animalNumber);
    }
}
