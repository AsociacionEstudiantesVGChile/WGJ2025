using UnityEngine;

public enum Decision {
	Accepted, Rejected
}

public readonly struct JudgeResult {
	public readonly Decision Decision;
	public readonly CharacterInfo JudgedCharacter;

	public JudgeResult(Decision decision, CharacterInfo judgedCharacter) {
		Decision = decision;
		JudgedCharacter = judgedCharacter;
	}
}
