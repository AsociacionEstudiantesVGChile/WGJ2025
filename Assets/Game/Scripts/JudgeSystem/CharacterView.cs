using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

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
		_portrait.transform.localPosition = Vector3.zero;
        _portrait.sprite = character.Portrait;

        _name.text = $"Name: {character.Name}";
        _weight.text = $"Weight: {character.Weight.ToString()}";
        _backStory.text = character.Backstory;
		_voiceSource.clip = character.VoiceClip;
		_voiceSource.Play();
		_dialogue.text = character.Dialogue;
    }

    public void DisplaceCharacter(JudgeResult judgeResult) {
		switch (judgeResult.Decision)
		{
			case Decision.Accepted:
			_portrait.transform.DOMoveX(1920, 2);
			break;
			case Decision.Rejected:
			_portrait.transform.DOMoveY(10, 1).SetEase(Ease.InBack);
			break;
			default:
				throw new System.Exception("????????????????????");
		}
    }
}
