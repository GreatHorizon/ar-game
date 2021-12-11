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
    private Text text;
    [SerializeField]
    private Text closeText;

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
            Vector3 shipPosition1 = towerPositon;
            Vector3 shipPosition2 = towerPositon;
            var tower = Instantiate(towerPrefab);
            tower.transform.position = towerPositon;
            tower.transform.rotation = towerRotation;
            tower.GetComponent<Destoyer>().SetText(text);
            tower.GetComponent<Destoyer>().SetLoseText(closeText);

            tower.GetComponent<Destoyer>().SetTower(tower);
            tower.GetComponent<Destoyer>().SetCannon(cannon);
            

            //towerTop.GetComponent<SmoothRotation>().Move(cannon.transform);


            Destroy(towerTarget);

            shipPosition1.x = towerPositon.x + 0.15f;
            shipPosition1.y = towerPositon.y + 0.3f;

            shipPosition2.x = towerPositon.x - 0.15f;
            shipPosition2.y = towerPositon.y + 0.3f;


            GameObject shipObject1 = Instantiate(ship);
            GameObject shipObject2 = Instantiate(ship);
            SmoothMovementShip movementShip1 = shipObject1.GetComponent<SmoothMovementShip>();
            SmoothMovementShip movementShip2 = shipObject2.GetComponent<SmoothMovementShip>();

            movementShip1.PassTower(tower);
            movementShip2.PassTower(tower);
            shipObject1.transform.position = shipPosition1;
            shipObject2.transform.position = shipPosition2;

            movementShip1.Move(shipObject1.transform, new Vector3(shipPosition1.x, tower.transform.position.y, shipPosition1.z));
            movementShip2.Move(shipObject2.transform, new Vector3(shipPosition2.x, tower.transform.position.y, shipPosition2.z));

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
