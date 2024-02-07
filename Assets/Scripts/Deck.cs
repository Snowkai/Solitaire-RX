using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<GameObject> Deck_list = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Shuffle()
    {
        for (int i = 0;i < Deck_list.Count; i++)
        {
            var rand = Random.Range(0, Deck_list.Count - 1);
            GameObject tmp = Deck_list[rand];
            Deck_list[rand] = Deck_list[i];
            Deck_list[i] = tmp;
        }
        
    }

}
