using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public enum ExtraInfo {
	Fur, Teeth, Eyes
}

public class CharacterView : MonoBehaviour {
	[Header("Settings")]
    [field: SerializeField, Min(0.0f)] public float EntranceDurationSec { get; set; }
    [field: SerializeField, Min(0.0f)] public float ExitDurationSec { get; set; }

	[Header("Dependencies")]
	[SerializeField] private AudioSource _voiceSource;
	[SerializeField] private Button _fur, _teeth, _eyes;
    [SerializeField] private TextMeshProUGUI _name, _weight, _dialogue, _backStory;
    [SerializeField] private Image _portrait, _extraInfo;

	private CharacterInfo _currentCharacter;
	private bool _isShowingExtraInfo;

	private void OnEnable() {
		_fur.onClick.AddListener(() => ToggleExtraInfo(_currentCharacter, ExtraInfo.Fur));
		_teeth.onClick.AddListener(() => ToggleExtraInfo(_currentCharacter, ExtraInfo.Teeth));
		_eyes.onClick.AddListener(() => ToggleExtraInfo(_currentCharacter, ExtraInfo.Eyes));
	}

	private void OnDisable() {
		_fur.onClick.RemoveAllListeners();
		_teeth.onClick.RemoveAllListeners();
		_eyes.onClick.RemoveAllListeners();
	}

	public void EnableButtons() {
		_fur.interactable = true;
		_teeth.interactable = true;
		_eyes.interactable = true;
	}

	public void DisableButtons() {
		_fur.interactable = false;
		_teeth.interactable = false;
		_eyes.interactable = false;
	}

    public void DisplayCharacter(CharacterInfo character) {
		_currentCharacter = character;

		_portrait.transform.localPosition = Vector3.zero;
        _portrait.sprite = character.Portrait;

		_portrait.transform.DOMoveX(0, 1).From().SetEase(Ease.OutBack);

        _name.text = $"Name: {character.Name}";
        _weight.text = $"Weight: {character.Weight.ToString()}";
        _backStory.text = character.Backstory;
		_voiceSource.clip = character.VoiceClip;
		_voiceSource.Play();
		_dialogue.text = character.Dialogue;
    }

    public void DisplaceCharacter(JudgeResult judgeResult) {
		switch (judgeResult.Decision) {
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

	private void ToggleExtraInfo(CharacterInfo character, ExtraInfo extraInfo) {
		_isShowingExtraInfo = !_isShowingExtraInfo; // First time will be true.

		Sprite sprite = extraInfo switch {
			ExtraInfo.Fur => character.Fur,
			ExtraInfo.Teeth => character.Teeth,
			ExtraInfo.Eyes => character.Eyes,
			_ => throw new System.Exception("WTF?? ??? ? ?? ?!")
		};

		_extraInfo.sprite = _isShowingExtraInfo ? sprite : null;
	}
}
