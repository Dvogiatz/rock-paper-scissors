using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum GameChoices {

    ROCK,
    PAPER,
    SCISSORS,
    NONE
}

public class GameplayController : MonoBehaviour {
    [SerializeField]
    private Sprite rock_Sprite, paper_Sprite, scissors_Sprite;

    [SerializeField]
    private Image playerChoice_Img, opponentChoice_Img;

    [SerializeField]
    private TMP_Text infoText;

    private GameChoices player_Choice = GameChoices.NONE, opponent_Choice = GameChoices.NONE;

    private AnimationController animationController;

    void Awake() {
        animationController = GetComponent<AnimationController>();
    }

    public void SetChoices(GameChoices gameChoices) {
        switch(gameChoices) {

            case GameChoices.ROCK:
                playerChoice_Img.sprite = rock_Sprite;

                player_Choice = GameChoices.ROCK;
                break;

            case GameChoices.PAPER:
                playerChoice_Img.sprite = paper_Sprite;

                player_Choice = GameChoices.PAPER;
                break;

            case GameChoices.SCISSORS:
                playerChoice_Img.sprite = scissors_Sprite;

                player_Choice = GameChoices.SCISSORS;
                break;

        }

        SetOppoenntChoice();

        DetermineWinnerElegant();
    }

    void  SetOppoenntChoice() {
        int rnd = Random.Range(0, 3);
        
        switch(rnd) {
            case 0:
                opponentChoice_Img.sprite = rock_Sprite;
                opponent_Choice = GameChoices.ROCK;
                break;
            
            case 1:
                opponentChoice_Img.sprite = paper_Sprite;
                opponent_Choice = GameChoices.PAPER;
                break;

            case 2:
                opponentChoice_Img.sprite = scissors_Sprite;
                opponent_Choice = GameChoices.SCISSORS;
                break;
        }
    }

    // void DetermineWinner() {
    //     if(player_Choice == opponent_Choice) {
    //         infoText.text = "It's a Draw!";
    //         StartCoroutine(DisplayWinnerAndRestart());

    //         return;
    //     }

    //     if(player_Choice == GameChoices.PAPER && opponent_Choice == GameChoices.ROCK) {
    //         infoText.text = "You Win!";
    //         StartCoroutine(DisplayWinnerAndRestart());

    //         return;
    //     }

    //     if(player_Choice == GameChoices.ROCK && opponent_Choice == GameChoices.SCISSORS) {
    //         infoText.text = "You Win!";
    //         StartCoroutine(DisplayWinnerAndRestart());

    //         return;
    //     }

    //     if(player_Choice == GameChoices.SCISSORS && opponent_Choice == GameChoices.PAPER) {
    //         infoText.text = "You Win!";
    //         StartCoroutine(DisplayWinnerAndRestart());

    //         return;
    //     }

    //     if(opponent_Choice == GameChoices.PAPER && player_Choice == GameChoices.ROCK) {
    //         infoText.text = "You Lose!";
    //         StartCoroutine(DisplayWinnerAndRestart());

    //         return;
    //     }

    //     if(opponent_Choice == GameChoices.ROCK && player_Choice == GameChoices.SCISSORS) {
    //         infoText.text = "You Lose!";
    //         StartCoroutine(DisplayWinnerAndRestart());

    //         return;
    //     }

    //     if(opponent_Choice == GameChoices.SCISSORS && player_Choice == GameChoices.PAPER) {
    //         infoText.text = "You Lose!";
    //         StartCoroutine(DisplayWinnerAndRestart());

    //         return;
    //     }

    // }

    void DetermineWinnerElegant() {

        int result = (player_Choice - opponent_Choice + 3) % 3;
        
        switch (result)
        {
            case 0:
                infoText.text = "It's a Draw!";
                StartCoroutine(DisplayWinnerAndRestart());
                break;
            case 1:
                infoText.text = "You Win!";
                StartCoroutine(DisplayWinnerAndRestart());
                break;
            case 2:
                infoText.text = "You Lose!";
                StartCoroutine(DisplayWinnerAndRestart());
                break;
        }
        return;  
    }

    IEnumerator DisplayWinnerAndRestart() {
        yield return new WaitForSeconds(2f);
        infoText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);
        infoText.gameObject.SetActive(false);

        animationController.ResetAnimations();
    }
}
