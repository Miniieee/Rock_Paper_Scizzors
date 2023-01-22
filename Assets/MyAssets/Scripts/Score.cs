using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] int currentScore = 0;
    [SerializeField] int scoreToAdd = 10;
    [SerializeField] TextMeshProUGUI scoreText;
    int highScore;

    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI currentScoreText;

    [SerializeField] int gunAmmount = 1;

    [SerializeField] LoadScenesManagger revive;
    [SerializeField] TextMeshProUGUI gunScore;

    [SerializeField] GameObject adCanvasShow;

    [SerializeField] Admanageringame advertisement;

    [SerializeField] Button reviveButton;

    private void Start()
    {
        GetInformation();
    }

    public void GetInformation()
    {
        currentScore = PlayerPrefs.GetInt("currentScore");          // bekéri az elmentett score-t
        highScore = PlayerPrefs.GetInt("highScore", 0);         //bekéri a tárhelyről a mentett értéket
        gunAmmount = PlayerPrefs.GetInt("gunAmmount");          //bekérjük mennyi van

        if (gunAmmount > 0)
        {
            reviveButton.interactable = true;
        }
        else
        {
            reviveButton.interactable = false;
        }

        WriteInformation();
    }

    public void WriteInformation()
    {
        scoreText.text = "Score: " + currentScore.ToString();       //a számlálót szöveggé alakítja
        highScoreText.text = "High score: " + highScore.ToString();     //szöveggé alakítja pause menüben azonnal látható
        currentScoreText.text = "Score: " + currentScore.ToString();    //szöveggé alakítja pause menüben aonnal látható
        gunScore.text = "x " + gunAmmount.ToString();
    }

    public void AddScore()
    {
        currentScore += scoreToAdd;     //növeli a score értékét, collision handler-ből hívja meg ütközés esetén
        scoreText.text = "Score: " + currentScore.ToString();
        SetHighScore();
        currentScoreText.text = "Score: " + currentScore.ToString();
        PlayerPrefs.SetInt("currentScore", currentScore);
    }

    private void SetHighScore()
    {
        if (currentScore > PlayerPrefs.GetInt("highScore"))     //ha nagyobb az elért pontszám, akkor elmenti az értéket
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("highScore", currentScore);
        }

        highScoreText.text = "High score: " + highScore.ToString(); //kiírja az értéket a text-be
    }

    public void IfGunEnough()
    {
        if (gunAmmount > 0)
        {
            gunAmmount--;
            PlayerPrefs.SetInt("gunAmmount", gunAmmount);
            revive.Revive();
        }
        else
        {
            reviveButton.interactable = false;
        }  
    }

    public void AdPlusGun()
    {
        gunAmmount++;
        PlayerPrefs.SetInt("gunAmmount",gunAmmount);
    }
}
