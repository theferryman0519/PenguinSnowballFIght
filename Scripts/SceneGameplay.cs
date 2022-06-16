using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SceneGameplay : MonoBehaviour {
		
// ---------------------------------------- START: LIST OF VARIABLES ----------------------------------------
// --------------- PUBLIC VARIABLES ---------------
	public Image AttackImage;
	public Image DodgeImage;
	public Button AttackButton;
	public Button DodgeButton;

	public Image PauseOverlay;
	public Image PauseImage;
	public Image PlayImage;
	public Image ScorePanel;
	public Text ScoreText;
	public Text ThreeText;
	public Text TwoText;
	public Text OneText;
	public Text StartText;
	public Text PauseText;
	public Image OverlayImage;
	public Image LightOverlay;

	public Button PauseButton;
	public Button PlayButton;

	public Color FadeBlackOriginal = new Color(0.1607843f, 0.1607843f, 0.1921569f, 1.0f);
	public Color FadeBlackAlpha = new Color(0.1607843f, 0.1607843f, 0.1921569f, 0.0f);
	public Color FadeTextOriginal = new Color(0.0f, 0.145098f, 0.3803922f, 1.0f);
	public Color FadeTextAlpha = new Color(0.0f, 0.145098f, 0.3803922f, 0.0f);
	public Color LightOriginal = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	public Color LightAlpha = new Color(1.0f, 1.0f, 1.0f, 0.0f);

	public AudioClip AudioClipGameOver;
	public AudioSource AudioSourceGameOver;
	
// --------------- PRIVATE VARIABLES ---------------
	int LouisLightInt = 0;
	
// --------------- STATIC VARIABLES ---------------
	public static bool HasTimerStarted;
	public static bool IsPaused;
	public static int AttackingOrDodging;
	
// ---------------------------------------- END: LIST OF VARIABLES ----------------------------------------
// ---------------------------------------- START: CALLING OTHER SCRIPTS ----------------------------------------
	public ChangeScene Scene04LoadRun;
	
// ---------------------------------------- END: CALLING OTHER SCRIPTS ----------------------------------------
// ---------------------------------------- START: INITIAL FUNCTIONS ----------------------------------------
// --------------- START FUNCTION ---------------
	void Start() {
		OverlayImage.GetComponent<Image>().color = FadeBlackOriginal;
		StartText.GetComponent<Text>().color = FadeTextAlpha;
		ThreeText.GetComponent<Text>().color = FadeTextOriginal;
		TwoText.GetComponent<Text>().color = FadeTextAlpha;
		OneText.GetComponent<Text>().color = FadeTextAlpha;

		LightOverlay.enabled = false;
		LightOverlay.GetComponent<Image>().color = LightOriginal;

		Button PauseButtonClick = PauseButton.GetComponent<Button>();
		Button PlayButtonClick = PlayButton.GetComponent<Button>();
		Button AttackButtonClick = AttackButton.GetComponent<Button>();
		Button DodgeButtonClick = DodgeButton.GetComponent<Button>();

		PauseButtonClick.onClick.AddListener(PauseButtonClicking);
		PlayButtonClick.onClick.AddListener(PlayButtonClicking);
		AttackButtonClick.onClick.AddListener(AttackButtonClicking);
		DodgeButtonClick.onClick.AddListener(DodgeButtonClicking);

		HasTimerStarted = false;
		IsPaused = false;
		AttackingOrDodging = 0;

		AudioSourceGameOver.volume = 4.0f;

		StartCoroutine(FadeOutOverlay());
	}
	
// --------------- AWAKE FUNCTION ---------------
	void Awake() {
		
	}
	
// --------------- UPDATE FUNCTION ---------------
	void Update() {
		// Timer
		if ((HasTimerStarted == true) && (IsPaused == false)) {
			RunTimer();
			GameplayActions.ReadyToPlay = true;
		}

		else {
			PauseTimer();
			GameplayActions.ReadyToPlay = false;
		}

		// Paused / Play
		if (IsPaused == false) {
			PauseImage.enabled = true;
			PlayImage.enabled = false;
			PauseOverlay.enabled = false;
			PauseText.enabled = false;
		}

		else {
			PauseImage.enabled = false;
			PlayImage.enabled = true;
			PauseOverlay.enabled = true;
			PauseText.enabled = true;
		}


		// Dodge / Atack
		if (DataPlayer.PlayerHiding == true) {
			AttackImage.enabled = true;
			DodgeImage.enabled = false;
		}

		else if (DataPlayer.PlayerHiding == false) {
			AttackImage.enabled = false;
			DodgeImage.enabled = true;
		}

		// Light Special
		if (DataPenguins.IsUsingSpecialLouis == true) {
			LouisLightInt = 1;
			StartCoroutine(FadeOutLightOverlay());
		}

		UsingSpacebar();
	}
	
// ---------------------------------------- END: INITIAL FUNCTIONS ----------------------------------------
// ---------------------------------------- START: OTHER FUNCTIONS ----------------------------------------
    public IEnumerator FadeOutOverlay() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 5.0f;
			OverlayImage.GetComponent<Image>().color = Color.Lerp(FadeBlackOriginal, FadeBlackAlpha, ElapsedTime);
			yield return null;
		}

		OverlayImage.enabled = false;
		StartCoroutine(FadeOut3());
	}

	public void PlayGameOver() {
		StartCoroutine(FadeInOverlayLost());
	}

	public IEnumerator FadeInOverlayLost() {
		float ElapsedTime = 0.0f;
		OverlayImage.enabled = true;
		OverlayImage.GetComponent<Image>().color = FadeBlackAlpha;
		DataPlayer.PlayerTime = DataPlayer.PlayerTime + 0;
		AudioSourceGameOver.Play();

		while (ElapsedTime < 2.0f) {
			ElapsedTime += Time.deltaTime;
			OverlayImage.GetComponent<Image>().color = Color.Lerp(FadeBlackAlpha, FadeBlackOriginal, ElapsedTime);
			yield return null;
		}

		while (ElapsedTime < 1.5f) {
			ElapsedTime += Time.deltaTime;
			yield return null;
		}

		Scene04LoadRun.Scene04Load();
	}

	public IEnumerator FadeOutStart() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime;
			StartText.GetComponent<Text>().color = Color.Lerp(FadeTextOriginal, FadeTextAlpha, ElapsedTime);
			yield return null;
		}

		StartText.enabled = false;
		HasTimerStarted = true;
		GameplayActions.ReadyToPlay = true;
	}

	public IEnumerator FadeInStart() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime;
			StartText.GetComponent<Text>().color = Color.Lerp(FadeTextAlpha, FadeTextOriginal, ElapsedTime);
			yield return null;
		}

		StartCoroutine(FadeOutStart());
	}

	public IEnumerator FadeOut3() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime;
			ThreeText.GetComponent<Text>().color = Color.Lerp(FadeTextOriginal, FadeTextAlpha, ElapsedTime);
			yield return null;
		}

		ThreeText.enabled = false;
		StartCoroutine(FadeIn2());
	}

	public IEnumerator FadeOut2() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime;
			TwoText.GetComponent<Text>().color = Color.Lerp(FadeTextOriginal, FadeTextAlpha, ElapsedTime);
			yield return null;
		}

		TwoText.enabled = false;
		StartCoroutine(FadeIn1());
	}

	public IEnumerator FadeIn2() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime;
			TwoText.GetComponent<Text>().color = Color.Lerp(FadeTextAlpha, FadeTextOriginal, ElapsedTime);
			yield return null;
		}

		StartCoroutine(FadeOut2());
	}

	public IEnumerator FadeOut1() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime;
			OneText.GetComponent<Text>().color = Color.Lerp(FadeTextOriginal, FadeTextAlpha, ElapsedTime);
			yield return null;
		}

		OneText.enabled = false;
		StartCoroutine(FadeInStart());
	}

	public IEnumerator FadeIn1() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime;
			OneText.GetComponent<Text>().color = Color.Lerp(FadeTextAlpha, FadeTextOriginal, ElapsedTime);
			yield return null;
		}

		StartCoroutine(FadeOut1());
	}

	public void PauseButtonClicking() {
		IsPaused = true;
		GameplayActions.ReadyToPlay = false;
	}

	public void PlayButtonClicking() {
		IsPaused = false;
		GameplayActions.ReadyToPlay = true;
	}

	public void AttackButtonClicking() {
		AttackingOrDodging = 1;
		DataPlayer.PlayerHiding = false;
	}

	public void DodgeButtonClicking() {
		AttackingOrDodging = 1;
		DataPlayer.PlayerHiding = true;
	}

	public void UsingSpacebar() {
		if (Input.GetKey(KeyCode.Space)) {
			if (DataPlayer.PlayerHiding == true) {
				AttackButtonClicking();
			}

			else if (DataPlayer.PlayerHiding == false) {
				DodgeButtonClicking();
			}
		}
	}

	public void RunTimer() {
		DataPlayer.PlayerTime += Time.deltaTime * 1.0f;
	}

	public void PauseTimer() {
		DataPlayer.PlayerTime = DataPlayer.PlayerTime + 0;
	}

	public IEnumerator FadeOutLightOverlay() {
		if (LouisLightInt == 1) {
			float ElapsedTime = 0.0f;
			LightOverlay.enabled = true;

			while (ElapsedTime < 1.0f) {
				ElapsedTime += Time.deltaTime;
				LightOverlay.GetComponent<Image>().color = Color.Lerp(LightOriginal, LightOriginal, ElapsedTime);
				yield return null;
			}

			while ((ElapsedTime >= 1.0f) && (ElapsedTime < 5.5f)) {
				ElapsedTime += Time.deltaTime;
				LightOverlay.GetComponent<Image>().color = Color.Lerp(LightOriginal, LightAlpha, ElapsedTime);
				yield return null;
			}

			LightOverlay.enabled = false;
			LightOverlay.GetComponent<Image>().color = LightOriginal;
			LouisLightInt = 0;
			DataPenguins.IsUsingSpecialLouis = false;
		}
	}
	
// ---------------------------------------- END: OTHER FUNCTIONS ----------------------------------------
}