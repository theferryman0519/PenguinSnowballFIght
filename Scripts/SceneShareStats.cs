using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SceneShareStats : MonoBehaviour {
		
// ---------------------------------------- START: LIST OF VARIABLES ----------------------------------------
// --------------- PUBLIC VARIABLES ---------------
	public Image OverlayImage;
	public Text StatsPanelStats;

	public Color OverlayOriginal = new Color(0.1607843f, 0.1607843f, 0.1921569f, 1.0f);
	public Color OverlayAlpha = new Color(0.1607843f, 0.1607843f, 0.1921569f, 0.0f);

	public Button PlayAgainButton;
	public Button ReviewTutorialButton;
	
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
		OverlayImage.GetComponent<Image>().color = OverlayOriginal;
		StartCoroutine(FadeOutOverlay());

		Button PlayAgainButtonClick = PlayAgainButton.GetComponent<Button>();
		Button ReviewTutorialButtonClick = ReviewTutorialButton.GetComponent<Button>();

		PlayAgainButtonClick.onClick.AddListener(PlayAgainButtonClicking);
		ReviewTutorialButtonClick.onClick.AddListener(ReviewTutorialButtonClicking);
	}
	
// --------------- AWAKE FUNCTION ---------------
	void Awake() {
		
	}
	
// --------------- UPDATE FUNCTION ---------------
	void Update() {
		UpdateStatistics();
	}
	
// ---------------------------------------- END: INITIAL FUNCTIONS ----------------------------------------
// ---------------------------------------- START: OTHER FUNCTIONS ----------------------------------------
    public IEnumerator FadeOutOverlay() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 5.0f;
			OverlayImage.GetComponent<Image>().color = Color.Lerp(OverlayOriginal, OverlayAlpha, ElapsedTime);
			yield return null;
		}

		OverlayImage.enabled = false;
	}

	public void UpdateStatistics() {
		StatsPanelStats.text = 
			DataPlayer.PlayerScore.ToString() + "\n" + 
			DataPlayer.PlayerTime.ToString("n2") + " Seconds" + "\n" + 
			DataPlayer.PlayerPenguinsHit.ToString() + " Penguins" + "\n" + 
			DataPlayer.PlayerSnowballsHit.ToString() + " Snowballs";
	}

	public void PlayAgainButtonClicking() {
		StartCoroutine(FadeInOverlayPlayAgain());
	}

	public void ReviewTutorialButtonClicking() {
		StartCoroutine(FadeInOverlayReviewTutorial());
	}

	public IEnumerator FadeInOverlayPlayAgain() {
		float ElapsedTime = 0.0f;
		OverlayImage.enabled = true;
		OverlayImage.GetComponent<Image>().color = OverlayAlpha;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 5.0f;
			OverlayImage.GetComponent<Image>().color = Color.Lerp(OverlayAlpha, OverlayOriginal, ElapsedTime);
			yield return null;
		}

		// Reset Data
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

		Scene03LoadRun.Scene03Load();
	}

	public IEnumerator FadeInOverlayReviewTutorial() {
		float ElapsedTime = 0.0f;
		OverlayImage.enabled = true;
		OverlayImage.GetComponent<Image>().color = OverlayAlpha;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 5.0f;
			OverlayImage.GetComponent<Image>().color = Color.Lerp(OverlayAlpha, OverlayOriginal, ElapsedTime);
			yield return null;
		}

		// Reset Data
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

		Scene02LoadRun.Scene02Load();
	}
	
// ---------------------------------------- END: OTHER FUNCTIONS ----------------------------------------
}