using System.Collections;
using UnityEngine;

public class Main : MonoBehaviour {
    [SerializeField] private DayInfo[] _days;

    [Header("Dependencies")]
    [SerializeField] private CharacterView _characterView;

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
            // Display character information.

            // Wait to display to finish.

            // Wait to player judge to be emitted.

            // Play feedback (sound, animation, etc...) based on the result.

            // Wait for result feedback to finish.
            yield return null;
        }
    }
}