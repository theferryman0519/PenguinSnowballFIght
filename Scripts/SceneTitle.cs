using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SceneTitle : MonoBehaviour {
		
// ---------------------------------------- START: LIST OF VARIABLES ----------------------------------------
// --------------- PUBLIC VARIABLES ---------------
	public Button TutorialButton;
	public Button StartButton;

	public Image TutorialImage;
	public Image StartImage;
	public Image RACLogo;
	public Image MainLogo;
	public Image OverlayImage;

	public Color FadeOutBlack = new Color(0.1607843f, 0.1607843f, 0.1921569f, 1.0f);
	public Color FadeOutAlpha = new Color(0.1607843f, 0.1607843f, 0.1921569f, 0.0f);
	public Color FadeInOriginal = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	public Color FadeInAlpha = new Color(1.0f, 1.0f, 1.0f, 0.0f);

	public GameObject SkyA;
	public GameObject SkyB;
	public GameObject SkyC;
	public GameObject SkyD;
	public GameObject SkyE;
	
// --------------- PRIVATE VARIABLES ---------------
	
	
// --------------- STATIC VARIABLES ---------------
	
	
// ---------------------------------------- END: LIST OF VARIABLES ----------------------------------------
// ---------------------------------------- START: CALLING OTHER SCRIPTS ----------------------------------------
	public ChangeScene Scene02LoadRun;
	public ChangeScene Scene03LoadRun;
	
// ---------------------------------------- END: CALLING OTHER SCRIPTS ----------------------------------------
// ---------------------------------------- START: INITIAL FUNCTIONS ----------------------------------------
// --------------- START FUNCTION ---------------
	void Start() {
		// TutorialButton
		Button TutorialButtonClick = TutorialButton.GetComponent<Button>();
		TutorialButtonClick.onClick.AddListener(TutorialButtonClicking);

		// StartButton
		Button StartButtonClick = StartButton.GetComponent<Button>();
		StartButtonClick.onClick.AddListener(StartButtonClicking);

		TutorialImage.GetComponent<Image>().color = FadeInAlpha;
		StartImage.GetComponent<Image>().color = FadeInAlpha;
		RACLogo.GetComponent<Image>().color = FadeInAlpha;
		MainLogo.GetComponent<Image>().color = FadeInAlpha;
		OverlayImage.GetComponent<Image>().color = FadeOutBlack;

		StartCoroutine(FadeOutOverlay());

		// Set Data
		DataPenguins.IsHidingCatherine = false;
		DataPenguins.IsLosingCatherine = false;
		DataPenguins.IsProtectingCatherine = false;
		DataPenguins.IsThrowingCatherine = false;
		DataPenguins.IsUsingSpecialCatherine = false;
		DataPenguins.TimeBetweenThrowsCatherine = 0.0f;
		DataPenguins.TimeInHidingCatherine = 0.0f;
		DataPenguins.TimeInOpenCatherine = 0.0f;
		DataPenguins.TimeUntilSpecialCatherine = 0.0f;
		DataPenguins.IsHidingHadrian = false;
		DataPenguins.IsLosingHadrian = false;
		DataPenguins.IsProtectingHadrian = false;
		DataPenguins.IsThrowingHadrian = false;
		DataPenguins.IsUsingSpecialHadrian = false;
		DataPenguins.TimeBetweenThrowsHadrian = 0.0f;
		DataPenguins.TimeInHidingHadrian = 0.0f;
		DataPenguins.TimeInOpenHadrian = 0.0f;
		DataPenguins.TimeUntilSpecialHadrian = 0.0f;
		DataPenguins.IsHidingLouis = false;
		DataPenguins.IsLosingLouis = false;
		DataPenguins.IsProtectingLouis = false;
		DataPenguins.IsThrowingLouis = false;
		DataPenguins.IsUsingSpecialLouis = false;
		DataPenguins.TimeBetweenThrowsLouis = 0.0f;
		DataPenguins.TimeInHidingLouis = 0.0f;
		DataPenguins.TimeInOpenLouis = 0.0f;
		DataPenguins.TimeUntilSpecialLouis = 0.0f;
		DataPenguins.IsHidingVictoria = false;
		DataPenguins.IsLosingVictoria = false;
		DataPenguins.IsProtectingVictoria = false;
		DataPenguins.IsThrowingVictoria = false;
		DataPenguins.IsUsingSpecialVictoria = false;
		DataPenguins.TimeBetweenThrowsVictoria = 0.0f;
		DataPenguins.TimeInHidingVictoria = 0.0f;
		DataPenguins.TimeInOpenVictoria = 0.0f;
		DataPenguins.TimeUntilSpecialVictoria = 0.0f;
		DataPlayer.PlayerHiding = false;
		DataPlayer.PlayerLosing = false;
		DataPlayer.PlayerScore = 0;
		DataPlayer.PlayerThrowing = false;
		DataPlayer.PlayerTime = 0.0f;
		DataPlayer.PlayerSnowballsHit = 0;
		DataPlayer.PlayerPenguinsHit = 0;
	}
	
// --------------- AWAKE FUNCTION ---------------
	void Awake() {
		
	}
	
// --------------- UPDATE FUNCTION ---------------
	void Update() {
		
	}
	
// ---------------------------------------- END: INITIAL FUNCTIONS ----------------------------------------
// ---------------------------------------- START: OTHER FUNCTIONS ----------------------------------------
    public void TutorialButtonClicking() {
		StartCoroutine(FadeOutObjectsTutorial());
	}

	public void StartButtonClicking() {
		StartCoroutine(FadeOutObjectsStart());
	}

	public void DetermineStartingParallax() {
		AnimationParallax.NewSceneStartingPositionA = SkyA.transform.position.x;
		AnimationParallax.NewSceneStartingPositionB = SkyB.transform.position.x;
		AnimationParallax.NewSceneStartingPositionC = SkyC.transform.position.x;
		AnimationParallax.NewSceneStartingPositionD = SkyD.transform.position.x;
		AnimationParallax.NewSceneStartingPositionE = SkyE.transform.position.x;
	}

	public IEnumerator FadeOutOverlay() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 5.0f;
			OverlayImage.GetComponent<Image>().color = Color.Lerp(FadeOutBlack, FadeOutAlpha, ElapsedTime);
			yield return null;
		}

		OverlayImage.enabled = false;
		StartCoroutine(FadeInLogos());
	}

	public IEnumerator FadeInLogos() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 5.0f;
			RACLogo.GetComponent<Image>().color = Color.Lerp(FadeInAlpha, FadeInOriginal, ElapsedTime);
			MainLogo.GetComponent<Image>().color = Color.Lerp(FadeInAlpha, FadeInOriginal, ElapsedTime);
			yield return null;
		}

		StartCoroutine(FadeInButtons());
	}

	public IEnumerator FadeInButtons() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 5.0f;
			TutorialImage.GetComponent<Image>().color = Color.Lerp(FadeInAlpha, FadeInOriginal, ElapsedTime);
			StartImage.GetComponent<Image>().color = Color.Lerp(FadeInAlpha, FadeInOriginal, ElapsedTime);
			yield return null;
		}
	}

	public IEnumerator FadeOutObjectsTutorial() {
		float ElapsedTime = 0.0f;
		OverlayImage.enabled = true;
		OverlayImage.GetComponent<Image>().color = FadeOutAlpha;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 5.0f;
			OverlayImage.GetComponent<Image>().color = Color.Lerp(FadeOutAlpha, FadeOutBlack, ElapsedTime);
			yield return null;
		}

		DetermineStartingParallax();
		Scene02LoadRun.Scene02Load();
	}

	public IEnumerator FadeOutObjectsStart() {
		float ElapsedTime = 0.0f;
		OverlayImage.enabled = true;
		OverlayImage.GetComponent<Image>().color = FadeOutAlpha;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 5.0f;
			OverlayImage.GetComponent<Image>().color = Color.Lerp(FadeOutAlpha, FadeOutBlack, ElapsedTime);
			yield return null;
		}

		DetermineStartingParallax();
		Scene03LoadRun.Scene03Load();
	}
	
// ---------------------------------------- END: OTHER FUNCTIONS ----------------------------------------
}