﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerColor
{
    public Color panelColor;
    public Color textColor;
}

[System.Serializable]
public class Player
{
    public Image panel;
    public Text text;
    public Button button;
}

public class GameController : MonoBehaviour {

    public Text[] buttonList;
    private string playerSide;

    public GameObject gameOverPanel;
    public Text gameOverText;

    private int moveCount;

    private bool winner = false;

    public GameObject restartButton;

    public Player playerX;
    public Player playerO;
    public PlayerColor activePlayerColor;
    public PlayerColor inactivePlayerColor;

    public GameObject startInfo;

    void SetPlayerButtons(bool toggle)
    {
        playerX.button.interactable = toggle;
        playerO.button.interactable = toggle;
    }


    private void Awake()
    {
        SetGameControllerReferenceOnButtons();
        gameOverPanel.SetActive(false);
        moveCount = 0;
        restartButton.SetActive(false);
    }

    void SetPlayerColors(Player newPlayer, Player oldPlayer)
    {
        newPlayer.panel.color = activePlayerColor.panelColor;
        newPlayer.text.color = activePlayerColor.textColor;
        oldPlayer.panel.color = inactivePlayerColor.panelColor;
        oldPlayer.text.color = inactivePlayerColor.textColor;
    }

    public void SetStartingSide(string setStartingSide)
    {
        playerSide = setStartingSide;

        if (playerSide == "X")
        {
            SetPlayerColors(playerX, playerO);
        }
        else
        {
            SetPlayerColors(playerO, playerX);
        }
        StartGame();
    }

    void StartGame()
    {
        SetBoardInteractable(true);
        SetPlayerButtons(false);
        startInfo.SetActive(false);
    }

    void SetPlayerColorsInactive()
    {
        playerX.panel.color = inactivePlayerColor.panelColor;
        playerX.text.color = inactivePlayerColor.textColor;
        playerO.panel.color = inactivePlayerColor.panelColor;
        playerO.text.color = inactivePlayerColor.textColor;
    }

    

    void SetGameControllerReferenceOnButtons()
    {
        for(int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    void ChangeSide()
    {
        playerSide = (playerSide == "X") ? "O" : "X";

        if(playerSide == "X")
        {
            SetPlayerColors(playerX, playerO);
        }
        else
        {
            SetPlayerColors(playerO, playerX);
        }
    }

    public void endTurn()
    {
        moveCount++;

        if(buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }

        else if (moveCount == 9 && winner == false)
        {
            GameOver("draw");
        }
        else
        {
            ChangeSide();
        }        
    }

    void GameOver(string winningPlayer)
    {
        SetBoardInteractable(false);
        winner = true;
        if (winningPlayer == "draw")
        {
            SetGameOverText("It's a Draw!");
            SetPlayerColorsInactive();
        }
        else
        {
            SetGameOverText(winningPlayer + " Wins!");
        }
        restartButton.SetActive(true);
    }

    void SetGameOverText(string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }

    public void RestartGame()
    {
        moveCount = 0;
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        winner = false;
        SetPlayerButtons(true);
        SetPlayerColorsInactive();
        startInfo.SetActive(true);

        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].text = "";
        }
    }

    void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }
}

