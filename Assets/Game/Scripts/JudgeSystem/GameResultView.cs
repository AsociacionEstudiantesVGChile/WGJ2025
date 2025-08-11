using UnityEngine.UI;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class GameResultView : MonoBehaviour {
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _final;

    public void DisplayGameResult(GameResultInfo gameResult) {
        _image.DOFade(1f, 2f).SetEase(Ease.InOutSine).OnComplete(() => {
            _final.text = gameResult.Text;
        });
    }
}
