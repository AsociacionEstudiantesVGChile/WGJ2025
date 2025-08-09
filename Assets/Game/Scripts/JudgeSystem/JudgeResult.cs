using UnityEngine;

public enum Result {
	Accepted, Rejected
}

public readonly struct JudgeResult {
	public readonly Result Result;

	public JudgeResult(Result result) {
		Result = result;
	}
}
