using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class Card : MonoBehaviour
{
    public Sprite active;
    public Sprite hide;
    public char Suit;
    public Rank Rank;
    public char Color;
    public bool isHide = true;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = hide;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Flip()
    {
        if(isHide)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = hide;
        } else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = active;
        }
    }
    
}

public enum Rank
{
    Ace = 1,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King
}
