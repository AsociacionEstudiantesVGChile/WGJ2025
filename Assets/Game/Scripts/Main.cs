using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Main : MonoBehaviour {
    [SerializeField] private DayInfo[] _days;

    [Header("Dependencies")]
    [SerializeField] private GameResultView _gameResultView;
    [SerializeField] private CharacterView _characterView;
    [SerializeField] private JudgeView _judgeView;

    private readonly List<JudgeResult> _judgements = new();
	private Decision _decision;

    private GameResultCalculator _gameResultCalculator;

    private void Awake() {
        _gameResultCalculator = new();
    }

    private IEnumerator Start() {
        foreach (DayInfo day in _days) {
            yield return StartCoroutine(ProcessDayCharactersRoutine(day.Characters));
        }

        GameResultInfo gameResult = _gameResultCalculator.CalculateGameResult(_judgements);
        _gameResultView.DisplayGameResult(gameResult);

        print("If you read this, the game already ended. Bye bye :).");
    }

    private IEnumerator ProcessDayCharactersRoutine(CharacterInfo[] characters) {
        foreach (CharacterInfo character in characters) {
            print($"Processing {character}");

            // 1. Display character information.
            _characterView.DisplayCharacter(character);

			// 2. Wait for display duration.
			yield return new WaitForSeconds(seconds: _characterView.EntranceDurationSec);

            // 3. Wait to player judge to be emitted.
			_judgeView.EnableButtons();
            _characterView.EnableButtons();
			yield return new WaitUntil(() => {
				return _judgeView.DecisionSelected(out _decision);
			});

			_judgeView.DisableButtons();
            _characterView.DisableButtons();

            var judgement = new JudgeResult(_decision, character);

            _judgements.Add(judgement);
			_characterView.DisplaceCharacter(judgement);
			print("Judgement: " + judgement.Decision + " " + judgement.JudgedCharacter);

			yield return new WaitForSeconds(_characterView.ExitDurationSec);

            yield return null;
        }
    }
}
