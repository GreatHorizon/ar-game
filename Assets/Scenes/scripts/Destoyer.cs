using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Assets.Scenes.scripts;
using UnityEngine.SceneManagement;

public class Destoyer : MonoBehaviour
{
    // Start is called before the first frame update


    private Text _text;
    bool isGameOver = false;

    [SerializeField]
    private Text _loseText;

    private GameObject _tower;

    private GameObject _cannon;

    [SerializeField]
    private GameObject _ball;

    public void SetText(Text text)
    {
        _text = text;
    }
    public void SetLoseText(Text text)
    {
        _loseText = text;
    }
    public void SetTower(GameObject tower)
    {
        _tower = tower;
    }
    public void SetCannon(GameObject cannon)
    {
        _cannon = cannon;
    }

    private void ShootToCannon()
    {

        GameObject towerTop = _tower.transform.Find("Tower_Top").gameObject;
        towerTop.GetComponent<SmoothRotation>().Move(_cannon.transform);

        Vector3 towerTopPos = towerTop.transform.position;
        GameObject ball = Instantiate(_ball);
        ball.transform.position = towerTopPos;
        ball.GetComponent<SmoothMovement>().Move(_cannon.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Alien")
        {
            Destroy(other.gameObject);
            int i = Convert.ToInt32(_text.text);
            if (i <= 0 && !isGameOver)
            {
                isGameOver = true;
                _loseText.gameObject.SetActive(true);
                ShootToCannon();
                return;
            }
            _text.text = (--i).ToString();

        } 
        else if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
        }
    }
}
