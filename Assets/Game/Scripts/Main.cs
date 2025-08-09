using System.Collections;
using UnityEngine;

public class Main : MonoBehaviour {
    [SerializeField] private DayInfo[] _days;

    [Header("Dependencies")]
    [SerializeField] private CharacterView _characterView;
    [SerializeField] private JudgeView _judgeView;

	private JudgeResult _currentJudgeResult;
    private Judge _judge;

    private void Awake() {
        _judge = new Judge();
    }

    private IEnumerator Start() {
        int i = 0;
        foreach (DayInfo day in _days) {
            print($"Processing Day Nº{i++}");
            yield return StartCoroutine(ProcessDayCharactersRoutine(day.Characters));
        }
    }

    private IEnumerator ProcessDayCharactersRoutine(CharacterInfo[] characters) {
        foreach (CharacterInfo character in characters) {
            print($"Processing {character}");

            // 1. Display character information.
            _characterView.DisplayCharacter(character);

			// 2. Wait for display duration.
			Waiters.Wait(_characterView.EntranceDurationSec);

            // 3. Wait to player judge to be emitted.
			_judgeView.EnableButtons();
			yield return new WaitUntil(() => {
				return _judgeView.JudgeSelected(out _currentJudgeResult);
			});

			// judgeResult disponible.
			print("Result: " + _currentJudgeResult.Result);

            // 4. Play feedback (sound, animation, etc...) based on the result.

            // 5. Wait for result feedback to finish.
            yield return null;
        }
    }
}
