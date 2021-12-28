
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AliensAmount : MonoBehaviour
{
    [SerializeField]
    private Color _color;
    private Text text;
    private int _amount;
    private int _killed = 0;

    public void SetColor(Color color)
    {
        _color = color;
    }
    public int getAmount()
    {
        return _amount;
    }
    public int GetKilledAmount()
    {
        return _killed;
    }

    public void decreaseAmount()
    {
        gameObject.transform.GetChild(_killed).GetComponent<Image>().color = _color;

        _killed++;
    }

    // Start is called before the first frame update
    void Start()
    {
        _amount = gameObject.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
