using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour
{
    [SerializeField]
    private Button button;

    [SerializeField]
    private GameObject alien;    
    
    
    [SerializeField]
    private GameObject ship;    

    [SerializeField]
    private GameObject tower;    

    [SerializeField]
    private GameObject cannon;

    // Start is called before the first frame update
    void Start()
    {
        button.GetComponent<Button>().onClick.AddListener(() => {
            Vector3 towerPositon = tower.transform.position;
            Vector3 shipPosition = towerPositon;
            towerPositon.x = towerPositon.x + 0.1f;

            shipPosition.x = towerPositon.x + 0.1f;
            shipPosition.y = towerPositon.y + 0.1f;

   /*       towerPositon.y = towerPositon.y + 0.05f;
            towerPositon.z = towerPositon.z + 0.05f;*/

            GameObject alienObject = Instantiate(alien);
            GameObject shipObject = Instantiate(ship);

            alienObject.transform.position = towerPositon;
            shipObject.transform.position = shipPosition;



            Debug.Log("d");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
