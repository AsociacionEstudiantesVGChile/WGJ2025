using System;
using UnityEngine;

public enum Animal { Sheep, Wolf };
public enum Diet { Carnivorous, Vegan };

[CreateAssetMenu(menuName = "CharacterInfo")]
public class CharacterInfo : ScriptableObject {
    public string Name;
    public byte Weight;
    public Animal Animal;
    public Diet Diet;
    public Sprite Portrait;
    public string Dialogue;
    public AudioClip VoiceClip;

    [TextArea]
    public string Backstory;
}

