using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public struct GameResultInfo {
    public Sprite Sprite;
    public string Text;
}

public class GameResultCalculator {
    public GameResultInfo CalculateGameResult(IEnumerable<JudgeResult> judgements) {
        var acceptedCharacters = judgements.Where(judgement => judgement.Decision == Decision.Accepted).Select(judgement => judgement.JudgedCharacter);
        var rejectedCharacters = judgements.Where(judgement => judgement.Decision == Decision.Rejected).Select(judgement => judgement.JudgedCharacter);

        var acceptedSheeps = acceptedCharacters.Where(character => character.Animal == Animal.Sheep);
        var acceptedWolfs = acceptedCharacters.Where(character => character.Animal == Animal.Wolf);

        var rejectedSheeps = rejectedCharacters.Where(character => character.Animal == Animal.Sheep);
        var rejectedWolfs = rejectedCharacters.Where(character => character.Animal == Animal.Wolf);

        var acceptedCarnivorousSheeps = acceptedSheeps.Where(sheep => sheep.Diet == Diet.Carnivorous);
        var acceptedVeganSheeps = acceptedSheeps.Where(sheep => sheep.Diet == Diet.Vegan);
        
        var acceptedCarnivorousWolfs = acceptedWolfs.Where(wolf => wolf.Diet == Diet.Carnivorous);
        var acceptedVeganWolfs = acceptedWolfs.Where(wolf => wolf.Diet == Diet.Vegan);

        

        return default;
    }
}