using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOM : MonoBehaviour
{
    private List<Vector3> Stack_positions = new List<Vector3>();
    List<Card> Cards = new List<Card>();
    // Start is called before the first frame update
    void Start()
    {
        Stack_positions.Add(transform.position);
        Vector3 adding_pos = new Vector3(-0.05f, -0.6f, 0.0f);
        for (int i = 0; i < 20; i++)
        {
            Vector3 pos = Stack_positions[i] + adding_pos;
            Stack_positions.Add(pos);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCard(Card card)
    {
        var last_card_position = card.transform.position;
        var last_card = Cards[Cards.Count - 1];
        if(last_card.Color != card.Color)
        {
            if(card.Rank+1 == last_card.Rank) 
            {
                Cards.Add(card);
                card.transform.position = Stack_positions[Cards.Count - 1];
                last_card.isHide = true;
                card.isHide = false;
            }
            else
            {
                card.transform.position = last_card_position;
            }           
        }
        else
        {
            card.transform.position = last_card_position;
        }
    }

    public void RemoveCard()
    {
        Card card = Cards[Cards.Count - 1];
        Cards.RemoveAt(Cards.Count - 1);
    }
}
