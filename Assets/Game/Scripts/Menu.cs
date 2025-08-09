using UnityEngine;
using EasyTransition;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    [SerializeField] private TransitionSettings _transition;
    
    public void Play() {
        TransitionManager.Instance().Transition(sceneIndex: 1, _transition, startDelay: 0.0f);
    }

    public void Quit() {
        Application.Quit();
    }
}