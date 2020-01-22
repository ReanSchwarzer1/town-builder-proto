using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuidingHandler : MonoBehaviour
{
    [SerializeField]
    private City city;
    [SerializeField]
    private UIController uiController;
    [SerializeField]
    private Building[] buildings;
    [SerializeField]
    private Board board;
    private Building selectedBuilding;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && selectedBuilding != null
            && Input.GetKey(KeyCode.LeftShift))
        {
            InteractWithBoard();
        }
        else if (Input.GetMouseButtonDown(0) && selectedBuilding != null)
        {
            InteractWithBoard();
        }
    }

    void InteractWithBoard()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 gridPosition = board.CalculateGridPosition(hit.point);
            if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() && 
                !board.CheckForBuildingAtPosition(gridPosition))
            {
                if (city.Cash >= selectedBuilding.cost)
                {
                    city.Cash -= selectedBuilding.cost;
                    uiController.UpdateCityData();
                    city.buildingCounts[selectedBuilding.id]++;
                    board.AddBuilding(selectedBuilding, gridPosition);
                }
            }
        }
    }

    public void EnableBuilder(int building)
    {
        selectedBuilding = buildings[building];
        Debug.Log("Selected building: " + selectedBuilding.buildingName);
    }
}
