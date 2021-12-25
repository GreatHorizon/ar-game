
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AliensAmount : MonoBehaviour
{
    private Text text;

    public int getAmount()
    {
        return Convert.ToInt32(text.text);
    }

    public void decreaseAmount()
    {
        int currAmount = Convert.ToInt32(text.text);
        text.text = Convert.ToString(--currAmount);
    }

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
