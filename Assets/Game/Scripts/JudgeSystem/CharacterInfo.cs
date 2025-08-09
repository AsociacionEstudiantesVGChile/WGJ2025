using UnityEngine;

public enum Gender {
    Male, Female, NonBinary, PreferNotToSay
}

[CreateAssetMenu(menuName = "CharacterInfo")]
public class CharacterInfo : ScriptableObject {
    public string Name;
    public byte Age;
    public Gender Gender;

    public Sprite Portrait;

    [TextArea]
    public string Backstory;
}