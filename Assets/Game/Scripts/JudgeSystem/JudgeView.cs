using UnityEngine;
using UnityEngine.UI;

public class JudgeView : MonoBehaviour {
    [SerializeField] private Button _accept, _reject;

	private bool _trigger = false;
	private Result _result;

	private void OnEnable() {
		_accept.onClick.AddListener(() => TriggerJudgement(Result.Accepted));
		_reject.onClick.AddListener(() => TriggerJudgement(Result.Rejected));
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

	private void TriggerJudgement(Result result) {
		_result = result;
		_trigger = true;
	}

	public bool JudgeSelected(out JudgeResult judgeResult) {
		Result result = _result;

		judgeResult = new JudgeResult(result: result);

		bool savedTrigger = _trigger;
		_trigger = false;

		return savedTrigger;
	}
}
