using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Sprite active;
    public Sprite hide;
    public char Suit;
    public string Rank;
    public char Color;
    public bool isHide;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = active;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHide == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = hide;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = active;
        }
    }
}
