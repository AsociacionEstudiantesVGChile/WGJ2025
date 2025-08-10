using UnityEngine;

public enum Decision {
	Accepted, Rejected
}

public readonly struct JudgeResult {
	public readonly Decision Decision;

	public JudgeResult(Decision decision) {
		Decision = decision;
	}
}
