using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Deck deck;
    public List<DOM> doms = new List<DOM>();
    public List<DOM1> doms1 = new List<DOM1>();
    public List<DOM2> doms2 = new List<DOM2>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FieldFill()
    {
        deck.Shuffle();
        int count_card = 0;
        foreach (DOM dom in doms)
        {
            foreach (Vector3 pos in dom.Stack_positions)
            {
                for (int i = count_card; i < dom.Stack_positions.Count; i++)
                {
                    deck.Deck_list[i].transform.position = pos;
                }
            }
        }
        count_card = 0;
    }
}
