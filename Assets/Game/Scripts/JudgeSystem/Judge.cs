using UnityEngine;
using System;

public class Judge : MonoBehaviour {

    public event Action<CharacterInfo> OnCharacterJudged;
    
    private JudgeResult JudgeCharacter(CharacterInfo character) {
        return default;
    }
}