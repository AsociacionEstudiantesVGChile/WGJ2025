using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assets.SimpleLocalization.Scripts
{
	/// <summary>
	/// Localize dropdown component.
	/// </summary>
    [RequireComponent(typeof(TMP_Dropdown))]
    public class LocalizedDropdown : MonoBehaviour
    {
        public string[] LocalizationKeys;

        public void Start() {
			Localize();
            LocalizationManager.OnLocalizationChanged += Localize;
        }

        public void OnDestroy()
        {
            LocalizationManager.OnLocalizationChanged -= Localize;
        }

        private void Localize()
        {
			LocalizationManager.Read();

			var dropdown = GetComponent<TMP_Dropdown>();

			for (var i = 0; i < LocalizationKeys.Length; i++)
	        {
		        dropdown.options[i].text = LocalizationManager.Localize($"Idiomas.{LocalizationKeys[i]}");
			}

	        if (dropdown.value < LocalizationKeys.Length)
	        {
		        dropdown.captionText.text = LocalizationManager.Localize($"Idiomas.{LocalizationKeys[dropdown.value]}");
	        }
        }
		/// <summary>
		/// Change localization at runtime.
		/// </summary>
		public void SetLocalization() {
			var dropdown = GetComponent<TMP_Dropdown>();
			var language = dropdown.captionText.text;

			switch (language) {
				case "Español":
					language = "Spanish";
					break;
				case "Inglés":
					language = "English";
					break;
				default:
					break;
			}
			LocalizationManager.Language = language;
		}
	}
}
