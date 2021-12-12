using Assets.Scenes.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BulletDestoyer : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Animator _anim;
    private int amount = 20;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Cannon" && other.gameObject.tag != "Tower")
        {
            if (other.gameObject.tag == "Alien")
            {
                Debug.Log("here");
                _anim = other.gameObject.GetComponent<Animator>();
            
                _anim.Play("Dead");
                Destroy(other.gameObject.GetComponent<SmoothMovement>());

                Destroy(this.transform.gameObject);
                Destroy(other.gameObject, _anim.GetCurrentAnimatorStateInfo(0).length + 1.5f);

            }
        }
    }

    public IEnumerator CheckAnimationCompleted(string CurrentAnim, GameObject obj)
    {
        yield return new WaitForSeconds(5.0f);
    }
}
