using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterView : MonoBehaviour {
	[Header("Settings")]
    [field: SerializeField, Min(0.0f)] public float EntranceDurationSec { get; set; }
    [field: SerializeField, Min(0.0f)] public float ExitDurationSec { get; set; }

	[Header("Dependencies")]
	[SerializeField] private AudioSource _voiceSource;
    [SerializeField] private TextMeshProUGUI _name, _weight, _dialogue, _backStory;
    [SerializeField] private Image _portrait;

    private void OnEnable() {

    }

    private void OnDisable() {

    }

    public void DisplayCharacter(CharacterInfo character) {
        _portrait.sprite = character.Portrait;
        _name.text = $"Name: {character.Name}";
        _weight.text = $"Weight: {character.Weight.ToString()}";
        _backStory.text = character.Backstory;
		_voiceSource.clip = character.VoiceClip;
		_voiceSource.Play();
    }

    public void HideCharacter(CharacterInfo character) {

    }
}
