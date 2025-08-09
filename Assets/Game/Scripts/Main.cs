using System.Collections;
using UnityEngine;

public class Main : MonoBehaviour {
    [SerializeField] private DayInfo[] _days;

    [Header("Dependencies")]
    [SerializeField] private CharacterView _characterView;
    [SerializeField] private JudgeView _judgeView;

    private Judge _judge;

    private void Awake() {
        _judge = new Judge();
    }

    private IEnumerator Start() {
        foreach (DayInfo day in _days) {
            yield return StartCoroutine(ProcessDayCharactersRoutine(day.Characters));
        }
    }

    private IEnumerator ProcessDayCharactersRoutine(CharacterInfo[] characters) {
        foreach (CharacterInfo character in characters) {
            // 1.Display character information.
            _characterView.DisplayCharacter(character);
            // 2.Wait to display to finish.

            // 3.Wait to player judge to be emitted.

            // 4.Play feedback (sound, animation, etc...) based on the result.

            // 5.Wait for result feedback to finish.
            yield return null;
        }
    }
}