using UnityEngine;
using UnityEngine.UI;

public class JudgeView : MonoBehaviour {
    [SerializeField] private Button _accept, _reject;

	private bool _trigger = false;
	private Decision _decision;

	private void OnEnable() {
		_accept.onClick.AddListener(() => TriggerJudgement(Decision.Accepted));
		_reject.onClick.AddListener(() => TriggerJudgement(Decision.Rejected));
	}

	private void OnDisable() {
		_accept.onClick.RemoveAllListeners();
		_reject.onClick.RemoveAllListeners();
	}

    public void EnableButtons() {
		_accept.interactable = true;
		_reject.interactable = true;
	}

	public void DisableButtons() {
		_accept.interactable = false;
		_reject.interactable = false;
	}

	private void TriggerJudgement(Decision decision) {
		_decision = decision;
		_trigger = true;
	}

	public bool JudgeSelected(out JudgeResult judgeResult) {
		judgeResult = new JudgeResult(_decision);

		bool savedTrigger = _trigger;
		_trigger = false;

		return savedTrigger;
	}
}
