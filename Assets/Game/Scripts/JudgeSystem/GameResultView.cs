using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameResultView : MonoBehaviour {
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _final;

    public void DisplayGameResult(GameResultInfo gameResult) {
        return;
        _image.sprite = gameResult.Sprite;
        _final.text = gameResult.Text;
    }
}