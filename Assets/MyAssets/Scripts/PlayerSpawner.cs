using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] GameObject rockPlayerPrefab;
    [SerializeField] GameObject paperPlayerPrefab;
    [SerializeField] GameObject scizzorPlayerPrefab;
    [SerializeField] AudioManagger buttonClickSound;


    public void RockButtonSelected()
    {
        paperPlayerPrefab.SetActive(false);
        scizzorPlayerPrefab.SetActive(false);

        rockPlayerPrefab.SetActive(true);
        buttonClickSound.Play("ButtonClick");
    }

    public void PaperButtonSelected()
    {
        scizzorPlayerPrefab.SetActive(false);
        rockPlayerPrefab.SetActive(false);

        paperPlayerPrefab.SetActive(true);
        buttonClickSound.Play("ButtonClick");
    }

    public void ScizzorButtonSelected()
    {
        paperPlayerPrefab.SetActive(false);
        rockPlayerPrefab.SetActive(false);

        scizzorPlayerPrefab.SetActive(true);
        buttonClickSound.Play("ButtonClick");
    }
}
