
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliensAmount : MonoBehaviour
{
    [SerializeField]
    private int amount = 20;


    public int getAmount()
    {
        return amount;
    }

    public void decreaseAmount()
    {
        amount--;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
