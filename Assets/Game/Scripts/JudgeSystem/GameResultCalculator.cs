using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public struct GameResultInfo {
    public Sprite Sprite;
    public string Text;
}

public class GameResultCalculator : MonoBehaviour {
    public GameResultInfo CalculateGameResult(IEnumerable<JudgeResult> judgements) {
        var acceptedCharacters = judgements.Where(judgement => judgement.Decision == Decision.Accepted).Select(judgement => judgement.JudgedCharacter);
        var rejectedCharacters = judgements.Where(judgement => judgement.Decision == Decision.Rejected).Select(judgement => judgement.JudgedCharacter);

        var acceptedSheeps = acceptedCharacters.Where(character => character.Animal == Animal.Sheep);
        var acceptedWolves = acceptedCharacters.Where(character => character.Animal == Animal.Wolf);

        var rejectedSheeps = rejectedCharacters.Where(character => character.Animal == Animal.Sheep);
        var rejectedWolves = rejectedCharacters.Where(character => character.Animal == Animal.Wolf);

        var acceptedCarnivorousSheeps = acceptedSheeps.Where(sheep => sheep.Diet == Diet.Carnivorous);
        var acceptedVeganSheeps = acceptedSheeps.Where(sheep => sheep.Diet == Diet.Vegan);

        var acceptedCarnivorousWolfs = acceptedWolves.Where(wolf => wolf.Diet == Diet.Carnivorous);
        var acceptedVeganWolfs = acceptedWolves.Where(wolf => wolf.Diet == Diet.Vegan);

        var rejectedCarnivorousSheeps = rejectedSheeps.Where(sheep => sheep.Diet == Diet.Carnivorous);
        var rejectedVeganSheeps = rejectedSheeps.Where(sheep => sheep.Diet == Diet.Vegan);

        var rejectedCarnivorousWolfs = rejectedWolves.Where(wolf => wolf.Diet == Diet.Carnivorous);
        var rejectedVeganWolfs = rejectedWolves.Where(wolf => wolf.Diet == Diet.Vegan);

		var gameResult = new GameResultInfo {
			Sprite = null,
			Text = "Continuará..."
		};

        return gameResult;
    }
}
