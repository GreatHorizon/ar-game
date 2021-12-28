using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Assets.Scenes.scripts;
using UnityEngine.SceneManagement;

public class BulletDestoyer : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Animator _anim;

    private GameObject _wonText;

    [SerializeField]
    private GameObject _winSound;


    [SerializeField]
    private GameObject _dieSound;
    private GameObject _gun;

    private AliensAmount _amount;

    public void SetAliensAmount(AliensAmount amount)
    {
        _amount = amount;
    }

    public void SetWonText(GameObject text)
    {
        _wonText = text;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGunObj(GameObject gun)
    {
        _gun = gun;
    }



    void SetWinState()
    {
        _wonText.transform.Find("Restart").gameObject.SetActive(true);
        _wonText.transform.Find("Win").gameObject.SetActive(true);    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Cannon" && other.gameObject.tag != "Tower")
        {
            if (other.gameObject.tag == "Alien" && other.gameObject.tag != "AlienDying")
            {
                Debug.Log("here");
                _anim = other.gameObject.GetComponent<Animator>();
            
                _anim.Play("Dead");
                Destroy(other.gameObject.GetComponent<SmoothMovement>());

                Destroy(this.transform.gameObject);
                Destroy(other.gameObject, _anim.GetCurrentAnimatorStateInfo(0).length + 1.5f);
                Instantiate(_dieSound).GetComponent<AudioSource>().Play();
                other.gameObject.tag = "AlienDying";

                _amount.decreaseAmount();
                Debug.Log(_amount.getAmount());
                if (_amount.getAmount() == _amount.GetKilledAmount())
                {
                    SetWinState();
                    _gun.GetComponent<GatlingGun>().StopCoroutine();
                    Instantiate(_winSound).GetComponent<AudioSource>().Play();
                }

            }
        }
    }

    public IEnumerator CheckAnimationCompleted(string CurrentAnim, GameObject obj)
    {
        yield return new WaitForSeconds(5.0f);
    }
}
