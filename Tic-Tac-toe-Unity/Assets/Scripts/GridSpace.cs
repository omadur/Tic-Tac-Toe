using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // agregamos para poder interactuar con los botones

public class GridSpace : MonoBehaviour {

    public Button button;
    public Text buttonText;

    private GameController gamecontroller;

    public void SetSpace()
    {
        buttonText.text = gamecontroller.GetPlayerSide();
        button.interactable = false;
        gamecontroller.endTurn();
    }

    public void SetGameControllerReference(GameController controller)
    {
        this.gamecontroller = controller;
    }
}
