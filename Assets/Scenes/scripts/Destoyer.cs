using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Destoyer : MonoBehaviour
{
    // Start is called before the first frame update


    private Text _text;

    [SerializeField]
    private Text _loseText;

    public void SetText(Text text)
    {
        _text = text;
    }
    public void SetLoseText(Text text)
    {
        _loseText = text;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Alien")
        {
            Destroy(other.gameObject);
            int i = Convert.ToInt32(_text.text);
            if (i <= 0)
            {
                _loseText.gameObject.SetActive(true);
                return;
            }
            _text.text = (--i).ToString();

        } else if (other.gameObject.tag == "Tower")
        {
            Destroy(other.gameObject);
        }
    }
}
