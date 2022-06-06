using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EncapsulationExample : MonoBehaviour
{
    public EncapsulationVariables information;

    public Text oldValueText;
    public Text newValueText;

    public void PublicField()
    {
        oldValueText.text = "Old value: " + information.coinsPublic;

        information.coinsPublic = 11;

        newValueText.text = "New value: " + information.coinsPublic;
    }

    public void PrivateFieldGetSet() 
    {
        //information.coinsPrivate

        oldValueText.text = "Old value: " + information.GetCoins();

        information.SetCoins(22);

        newValueText.text = "New value: " + information.GetCoins();
    }

    public void PropertyAutomatic()
    {
        oldValueText.text = "Old value: " + information.CoinsAutomatic;

        information.CoinsAutomatic = 33;

        newValueText.text = "New value: " + information.CoinsAutomatic;
    }

    public void BackingFieldManual()
    {
        oldValueText.text = "Old value: " + information.CoinsManual;

        information.CoinsManual = 44;

        newValueText.text = "New value: " + information.CoinsManual;
    }

    public void BackingFieldCustom()
    {
        oldValueText.text = "Old value: " + information.CoinsCustom;

        information.CoinsCustom = 55;

        newValueText.text = "New value: " + information.CoinsCustom;
    }
}
