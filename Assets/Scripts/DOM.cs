using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOM : MonoBehaviour
{
    [SerializeField]
    List<Vector3> Stack_positions = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        Stack_positions.Add(transform.position);
        Vector3 adding_pos = new Vector3(0.0f, -0.6f, 0.0f);
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

    void AddCard()
    {
            
    }

    void RemoveCard()
    {

    }
}
