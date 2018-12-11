using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    public Image currentFuelBar;
    public Text ratioText;
    private Player player;

    private int currentFuelState;

    void Start()
    {
        player = GetComponent<Player>();
        currentFuelState = player.currentFuel;
    }

    private void UpdateFuelBar()
    {
        float ratio = (float)player.currentFuel/player.maxFuel;
        ratioText.text = (int)(ratio * 100) + "%";
        currentFuelBar.rectTransform.localScale = new Vector3( ratio,1,1);
    }

    private void Update()
    {
        if (currentFuelState != player.currentFuel)
        {
            UpdateFuelBar();
        }
    }
}
