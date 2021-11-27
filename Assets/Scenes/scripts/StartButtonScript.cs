using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scenes.scripts;

public class StartButtonScript : MonoBehaviour
{
    [SerializeField]
    private Button button;

    [SerializeField]
    private GameObject ship;
    [SerializeField]
    private GameObject towerTarget;
    [SerializeField]
    private GameObject cannon;
    [SerializeField] 
    private GameObject towerPrefab;
    private SmoothMovement movement = new SmoothMovement();

    // Start is called before the first frame update
    void Start()
    {
        button.GetComponent<Button>().onClick.AddListener(() => {
            button.enabled = false;
            var towerObj = towerTarget.transform.GetChild(0).gameObject;
            Vector3 towerPositon = towerObj.transform.position;
            var towerRotation = towerObj.transform.rotation;
            Vector3 shipPosition = towerPositon;
            var tower = Instantiate(towerPrefab);
            tower.transform.position = towerPositon;
            tower.transform.rotation = towerRotation;
            Destroy(towerTarget);

            shipPosition.x = towerPositon.x + 0.3f;
            shipPosition.y = towerPositon.y + 0.4f;


            GameObject shipObject = Instantiate(ship);
            SmoothMovementShip movementShip = shipObject.GetComponent<SmoothMovementShip>();
            movementShip.PassTower(tower);
            shipObject.transform.position = shipPosition;
            movementShip.Move(shipObject.transform, new Vector3(shipPosition.x, tower.transform.position.y, shipPosition.z));

        });
    }

    void UntargetObject()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }


}
