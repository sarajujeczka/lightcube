using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Map", menuName = "ZeTon/New Map", order = 2)]
public class Map : ScriptableObject
{
    public WallSlot[] walls;
}

[System.Serializable]
public class WallSlot {
    public BrickSlot slot1 = BrickSlot.Empty;
    public BrickSlot slot2 = BrickSlot.Empty;
    public BrickSlot slot3 = BrickSlot.Empty;
    public BrickSlot slot4 = BrickSlot.Empty;
    public BrickSlot slot5 = BrickSlot.Empty;
    public BrickSlot slot6 = BrickSlot.Empty;
}

public enum BrickSlot {
    Empty, Solid, Destoyable, Random, Red, Orange, Yellow, Green, Blue, Violett
}