using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Colour", menuName = "ZeTon/Colour/New Colour", order = 2)]
public class Colour : ScriptableObject
{
    public Colours colour;
    public Colour nextColour;
    public Colour prevColour;
    public Material matEmit;
    public Material material;
    public GameObject particleSystem;
}

public enum Colours
{
    Red, Orange, Yellow, Green, Blue, Violett
}