using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuUIText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gunAmmountText;
    [SerializeField] TextMeshProUGUI highScoreText;
    int gunAmmount;
    int highScore;

    public void Start()
    {
        gunAmmount = PlayerPrefs.GetInt("gunAmmount",0);
        gunAmmountText.text = "x " + gunAmmount.ToString();

        highScore = PlayerPrefs.GetInt("highScore", 0);
        highScoreText.text = "High Score: " + highScore.ToString() + " points";
    }
}
