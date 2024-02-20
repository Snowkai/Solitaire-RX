using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class DOM : MonoBehaviour
{
    private Vector3[] StackPositions = new Vector3[20]; 
    public GameObject[] StackCards = new GameObject[20];
    // Start is called before the first frame update
    void Start()
    {
        StackPositions[0] = gameObject.transform.position;
        Vector3 adding_pos = new Vector3(0f, -0.6f, -0.001f);
        for (int i = 1; i < StackPositions.Length; i++)
        {
            Vector3 pos = StackPositions[i-1] + adding_pos;
            StackPositions[i]=pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCard(GameObject card, Vector3 last—ardPosition)
    {
        if (!card.GetComponent<Card>().isFaceUp)
        {
            //Using in Razdacha()
            int indexFreePlace = StackCards.Select((item, i) => new { Item = item, Index = i })
                 .Where(x => x.Item == null)
                 .Select(x => x.Index)
                 .FirstOrDefault();
            card.transform.position = StackPositions[indexFreePlace];
            StackCards[indexFreePlace] = card;
            card.GetComponent<Card>().MyLastDOM = gameObject;
        } else if (card.GetComponent<Card>().isFaceUp)
        {
            //find Index with free(null) position in StackCards and index last card in StackCards
            int indexFreePlace = StackCards.Select((item, i) => new { Item = item, Index = i })
                 .Where(x => x.Item == null)
                 .Select(x => x.Index)
                 .FirstOrDefault();
            int indexLastCardOfStackCards = indexFreePlace - 1;
            if (indexLastCardOfStackCards < 0)
            {
                indexLastCardOfStackCards = 0;
                card.transform.position = StackPositions[indexLastCardOfStackCards];
                StackCards[indexLastCardOfStackCards] = card;
                card.GetComponent<Card>().MyLastDOM = gameObject;
            }
            else
            {
                //Checking on requirements for adding card
                if (StackCards[indexLastCardOfStackCards].GetComponent<Card>().Color != card.GetComponent<Card>().Color)
                {
                    if (StackCards[indexLastCardOfStackCards].GetComponent<Card>().Rank == card.GetComponent<Card>().Rank + 1)
                    {
                        //Adding in new DOM
                        card.transform.position = StackPositions[indexFreePlace];
                        StackCards[indexFreePlace] = card;
                        //Remove From old DOM
                        card.GetComponent<Card>().MyLastDOM = gameObject;
                        GameObject lastDOM = card.GetComponent<Card>().MyLastDOM;
                        lastDOM.GetComponent<DOM>().RemoveCard(card);
                    }
                    else
                    {
                        card.transform.position = last—ardPosition;
                    }
                }
                else
                {
                    card.transform.position = last—ardPosition;
                }
            }
        }
    }

    public void RemoveCard(GameObject card)
    {
        int index = Array.IndexOf(StackCards, card);
        StackCards[index] = null;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("A 1");
        if (other.GetComponent<Drag>().isMouseUp)
        {
            AddCard(other.gameObject, other.GetComponent<Drag>().LastCardPosition);
            Debug.Log("A 2");
        }
    }
}
