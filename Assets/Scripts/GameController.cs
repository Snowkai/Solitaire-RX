using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Deck deck;
    public List<DOM> doms = new List<DOM>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Razdacha()
    {
        int count_card = 7;
        foreach (DOM dom in doms)
        {
            for(int i = 1;i <= count_card; i++)
            {
                GameObject card = deck.Deck_list.First();
                card.GetComponent<Card>().isFaceUp = false;
                Vector3 lastCardPosition = card.transform.position;
                deck.Deck_list.Remove(card);
                dom.AddCard(card,lastCardPosition);
                if (i == count_card)
                {
                    card.GetComponent <Card>().Flip();
                }
            }
            count_card--;
        }
    }

}
