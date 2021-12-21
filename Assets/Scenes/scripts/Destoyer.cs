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
    private AliensAmount _amount;
    bool isGameOver = false;


    private GameObject _tower;

    private GameObject _cannon;

    [SerializeField]
    private GameObject _ball;

    private GameObject _endGame;
    private AudioSource _loseSound;
    private AudioSource _winSound;

    public void SetAliensAmount(AliensAmount amount)
    {
        _amount = amount;
    }
    public void SetText(Text text)
    {
        _text = text;
    }
    public void SetTower(GameObject tower)
    {
        _tower = tower;
    }
    public void SetCannon(GameObject cannon)
    {
        _cannon = cannon;
    }

    public void SetEndGameObject(GameObject obj)
    {
        _endGame = obj;
    }

    public void SetLoseSound(AudioSource audio)
    {
        _loseSound = audio;
    }
    public void SetWinSound(AudioSource audio)
    {
        _winSound = audio;
    }

    private void ShootToCannon()
    {

        GameObject towerTop = _tower.transform.Find("Tower_Top").gameObject;
        towerTop.GetComponent<SmoothRotation>().Move(_cannon.transform);

        Vector3 towerTopPos = towerTop.transform.position;
        GameObject ball = Instantiate(_ball);
        ball.transform.position = towerTopPos + new Vector3(0, 0.015f, 0);
        ball.GetComponent<SmoothMovementBall>().Move(_cannon.transform.position);

    }

    void SetWinState()
    {
        _endGame.transform.Find("Restart").gameObject.SetActive(true);
        _endGame.transform.Find("Win").gameObject.SetActive(true);
    }

    void SetLoseState()
    {
        _endGame.transform.Find("Restart").gameObject.SetActive(true);
        _endGame.transform.Find("Lose").gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Alien")
        {
            Destroy(other.gameObject);
            int i = Convert.ToInt32(_text.text);
            if (i <= 1 && !isGameOver)
            {
                isGameOver = true;
                _loseSound.Play();

                SetLoseState();
                ShootToCannon();
                return;
            }
            if (i > 1)
            {
                _amount.decreaseAmount();
                if (_amount.getAmount() == 0)
                {
                    _winSound.Play();
                    SetWinState();
                    _cannon.GetComponent<GatlingGun>().StopCoroutine();
                }
                Debug.Log(_amount.getAmount());
                _text.text = (--i).ToString();
            }
        } 
        else if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
        }
    }
}
