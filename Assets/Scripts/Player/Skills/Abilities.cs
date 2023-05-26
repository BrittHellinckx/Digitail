using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public float regularSpeed;
    public float sprintSpeed;
    public float jumpBoost;
    public string character;

    void Update()
    {
        switch (character)
        {
            case "Guitar":
                regularSpeed = GetComponentInChildren<Guitar>().regularSpeed;
                sprintSpeed = GetComponentInChildren<Guitar>().sprintSpeed;
                jumpBoost = GetComponentInChildren<Guitar>().jumpBoost;
                GetComponentInChildren<Guitar>().UseGuitarAbilities();
                break;
            case "Mic":
                regularSpeed = GetComponentInChildren<Mic>().regularSpeed;
                sprintSpeed = GetComponentInChildren<Mic>().sprintSpeed;
                jumpBoost = GetComponentInChildren<Mic>().jumpBoost;
                GetComponentInChildren<Mic>().UseMicAbilities();
                break;
            case "Drum":
                regularSpeed = GetComponentInChildren<Drum>().regularSpeed;
                sprintSpeed = GetComponentInChildren<Drum>().sprintSpeed;
                jumpBoost = GetComponentInChildren<Drum>().jumpBoost;
                GetComponentInChildren<Drum>().UseDrumAbilities();
                break;
            case "Piano":
                regularSpeed = GetComponentInChildren<Piano>().regularSpeed;
                sprintSpeed = GetComponentInChildren<Piano>().sprintSpeed;
                jumpBoost = GetComponentInChildren<Piano>().jumpBoost;
                GetComponentInChildren<Piano>().UsePianoAbilities();
                break;
        }
    }
}
