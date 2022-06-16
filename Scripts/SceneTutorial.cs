using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SceneTutorial : MonoBehaviour {
		
// ---------------------------------------- START: LIST OF VARIABLES ----------------------------------------
// --------------- PUBLIC VARIABLES ---------------
	public GameObject SkyA;
	public GameObject SkyB;
	public GameObject SkyC;
	public GameObject SkyD;
	public GameObject SkyE;

	public Image TutorialPanel;
	public Text TitleGameplayText;
	public Text TitlePenguinText;
	public Text SlideText1A;
	public Text SlideText1B;
	public Image SlideImage1;
	public Text SlideText2A;
	public Text SlideText3A;
	public Text SlideText3B;
	public Image SlideImage3A;
	public Image SlideImage3B;
	public Text SlideText4A;
	public Image SlideImage4;
	public Text SlideText6A;
	public Image SlideImage6;
	public Text SlideText7A;
	public Image SlideImage7;
	public Text SlideText8A;
	public Image SlideImage8;
	public Text SlideText9A;
	public Image SlideImage9;
	public Text SlideText10A;
	public Text SlideText10B;
	public Image SlideImage10;
	public Image BackImage;
	public Image NextImage;
	public Image StartImage;
	public Image SkipToStartImage;

	public Button BackButton;
	public Button NextButton;
	public Button StartButton;
	public Button SkipToStartButton;

	public Image OverlayImage;

	public Color ObjectsOriginal = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	public Color ObjectsAlpha = new Color(1.0f, 1.0f, 1.0f, 0.0f);
	public Color ObjectsTitle = new Color(0.0f, 0.145098f, 0.3803922f, 1.0f);
	public Color ObjectsText = new Color(0.1607843f, 0.1607843f, 0.1921569f, 1.0f);
	public Color OverlayAlpha = new Color(0.1607843f, 0.1607843f, 0.1921569f, 0.0f);
	public Color OverlayOriginal = new Color(0.1607843f, 0.1607843f, 0.1921569f, 1.0f);

	public int SlideNumber;
	
// --------------- PRIVATE VARIABLES ---------------
	
	
// --------------- STATIC VARIABLES ---------------
	
	
// ---------------------------------------- END: LIST OF VARIABLES ----------------------------------------
// ---------------------------------------- START: CALLING OTHER SCRIPTS ----------------------------------------
	public ChangeScene Scene03LoadRun;
	
// ---------------------------------------- END: CALLING OTHER SCRIPTS ----------------------------------------
// ---------------------------------------- START: INITIAL FUNCTIONS ----------------------------------------
// --------------- START FUNCTION ---------------
	void Start() {
		// BackButton
		Button BackButtonClick = BackButton.GetComponent<Button>();
		BackButtonClick.onClick.AddListener(BackButtonClicking);

		// NextButton
		Button NextButtonClick = NextButton.GetComponent<Button>();
		NextButtonClick.onClick.AddListener(NextButtonClicking);

		// StartButton
		Button StartButtonClick = StartButton.GetComponent<Button>();
		StartButtonClick.onClick.AddListener(StartButtonClicking);

		// SkipToStartButton
		Button SkipToStartButtonClick = SkipToStartButton.GetComponent<Button>();
		SkipToStartButtonClick.onClick.AddListener(SkipToStartButtonClicking);

		SlideNumber = 1;

		TutorialPanel.GetComponent<Image>().color = ObjectsAlpha;
		BackImage.GetComponent<Image>().color = ObjectsAlpha;
		NextImage.GetComponent<Image>().color = ObjectsAlpha;
		StartImage.GetComponent<Image>().color = ObjectsAlpha;
		SkipToStartImage.GetComponent<Image>().color = ObjectsAlpha;
		TitleGameplayText.GetComponent<Text>().color = ObjectsAlpha;
		TitlePenguinText.GetComponent<Text>().color = ObjectsAlpha;
		SlideText1A.GetComponent<Text>().color = ObjectsAlpha;
		SlideText1B.GetComponent<Text>().color = ObjectsAlpha;
		SlideImage1.GetComponent<Image>().color = ObjectsAlpha;
		SlideText2A.GetComponent<Text>().color = ObjectsAlpha;
		SlideText3A.GetComponent<Text>().color = ObjectsAlpha;
		SlideText3B.GetComponent<Text>().color = ObjectsAlpha;
		SlideImage3A.GetComponent<Image>().color = ObjectsAlpha;
		SlideImage3B.GetComponent<Image>().color = ObjectsAlpha;
		SlideText4A.GetComponent<Text>().color = ObjectsAlpha;
		SlideImage4.GetComponent<Image>().color = ObjectsAlpha;
		SlideText6A.GetComponent<Text>().color = ObjectsAlpha;
		SlideImage6.GetComponent<Image>().color = ObjectsAlpha;
		SlideText7A.GetComponent<Text>().color = ObjectsAlpha;
		SlideImage7.GetComponent<Image>().color = ObjectsAlpha;
		SlideText8A.GetComponent<Text>().color = ObjectsAlpha;
		SlideImage8.GetComponent<Image>().color = ObjectsAlpha;
		SlideText9A.GetComponent<Text>().color = ObjectsAlpha;
		SlideImage9.GetComponent<Image>().color = ObjectsAlpha;
		SlideText10A.GetComponent<Text>().color = ObjectsAlpha;
		SlideText10B.GetComponent<Text>().color = ObjectsAlpha;
		SlideImage10.GetComponent<Image>().color = ObjectsAlpha;
		OverlayImage.GetComponent<Image>().color = OverlayOriginal;

		BackImage.enabled = false;
		StartImage.enabled = false;
		OverlayImage.enabled = true;

		StartCoroutine(FadeOutOverlay());
	}
	
// --------------- AWAKE FUNCTION ---------------
	void Awake() {
		
	}
	
// --------------- UPDATE FUNCTION ---------------
	void Update() {
		
	}
	
// ---------------------------------------- END: INITIAL FUNCTIONS ----------------------------------------
// ---------------------------------------- START: OTHER FUNCTIONS ----------------------------------------
	public void DetermineStartingParallax() {
		AnimationParallax.NewSceneStartingPositionA = SkyA.transform.position.x;
		AnimationParallax.NewSceneStartingPositionB = SkyB.transform.position.x;
		AnimationParallax.NewSceneStartingPositionC = SkyC.transform.position.x;
		AnimationParallax.NewSceneStartingPositionD = SkyD.transform.position.x;
		AnimationParallax.NewSceneStartingPositionE = SkyE.transform.position.x;
	}

	public void BackButtonClicking() {
		if (SlideNumber == 2) {
			StartCoroutine(FadeOutBack2());
		}

		else if (SlideNumber == 3) {
			StartCoroutine(FadeOutBack3());
		}

		else if (SlideNumber == 4) {
			StartCoroutine(FadeOutBack4());
		}

		else if (SlideNumber == 6) {
			StartCoroutine(FadeOutBack6());
		}

		else if (SlideNumber == 7) {
			StartCoroutine(FadeOutBack7());
		}

		else if (SlideNumber == 8) {
			StartCoroutine(FadeOutBack8());
		}

		else if (SlideNumber == 9) {
			StartCoroutine(FadeOutBack9());
		}

		else if (SlideNumber == 10) {
			StartCoroutine(FadeOutBack10());
		}
	}

	public void NextButtonClicking() {
		if (SlideNumber == 1) {
			StartCoroutine(FadeOutNext1());
		}

		else if (SlideNumber == 2) {
			StartCoroutine(FadeOutNext2());
		}

		else if (SlideNumber == 3) {
			StartCoroutine(FadeOutNext3());
		}

		else if (SlideNumber == 4) {
			StartCoroutine(FadeOutNext4());
		}

		else if (SlideNumber == 6) {
			StartCoroutine(FadeOutNext6());
		}

		else if (SlideNumber == 7) {
			StartCoroutine(FadeOutNext7());
		}

		else if (SlideNumber == 8) {
			StartCoroutine(FadeOutNext8());
		}

		else if (SlideNumber == 9) {
			StartCoroutine(FadeOutNext9());
		}
	}

	public void StartButtonClicking() {
		StartCoroutine(FadeInOverlayToStart());
	}

	public void SkipToStartButtonClicking() {
		StartCoroutine(FadeInOverlayToStart());
	}

	public IEnumerator FadeInAllObjects() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 5.0f;
			TutorialPanel.GetComponent<Image>().color = Color.Lerp(ObjectsAlpha, ObjectsOriginal, ElapsedTime);
			NextImage.GetComponent<Image>().color = Color.Lerp(ObjectsAlpha, ObjectsOriginal, ElapsedTime);
			SkipToStartImage.GetComponent<Image>().color = Color.Lerp(ObjectsAlpha, ObjectsOriginal, ElapsedTime);
			TitleGameplayText.GetComponent<Text>().color = Color.Lerp(ObjectsAlpha, ObjectsTitle, ElapsedTime);
			yield return null;
		}

		StartCoroutine(FadeIn1());
	}

	public IEnumerator FadeOutOverlay() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 5.0f;
			OverlayImage.GetComponent<Image>().color = Color.Lerp(OverlayOriginal, OverlayAlpha, ElapsedTime);
			yield return null;
		}

		OverlayImage.enabled = false;
		StartCoroutine(FadeInAllObjects());
	}

// Fading Out On Back Button
	public IEnumerator FadeOutBack2() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 25.0f;
			SlideText2A.GetComponent<Text>().color = Color.Lerp(ObjectsText, ObjectsAlpha, ElapsedTime);
			BackImage.GetComponent<Image>().color = Color.Lerp(ObjectsOriginal, ObjectsAlpha, ElapsedTime);
			yield return null;
		}

		BackImage.enabled = false;
		StartCoroutine(FadeIn1());
	}

	public IEnumerator FadeOutBack3() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 25.0f;
			SlideText3A.GetComponent<Text>().color = Color.Lerp(ObjectsText, ObjectsAlpha, ElapsedTime);
			SlideText3B.GetComponent<Text>().color = Color.Lerp(ObjectsText, ObjectsAlpha, ElapsedTime);
			SlideImage3A.GetComponent<Image>().color = Color.Lerp(ObjectsOriginal, ObjectsAlpha, ElapsedTime);
			SlideImage3B.GetComponent<Image>().color = Color.Lerp(ObjectsOriginal, ObjectsAlpha, ElapsedTime);
			yield return null;
		}

		StartCoroutine(FadeIn2());
	}

	public IEnumerator FadeOutBack4() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 25.0f;
			SlideText4A.GetComponent<Text>().color = Color.Lerp(ObjectsText, ObjectsAlpha, ElapsedTime);
			SlideImage4.GetComponent<Image>().color = Color.Lerp(ObjectsOriginal, ObjectsAlpha, ElapsedTime);
			yield return null;
		}

		StartCoroutine(FadeIn3());
	}

	public IEnumerator FadeOutBack6() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 25.0f;
			SlideText6A.GetComponent<Text>().color = Color.Lerp(ObjectsText, ObjectsAlpha, ElapsedTime);
			SlideImage6.GetComponent<Image>().color = Color.Lerp(ObjectsOriginal, ObjectsAlpha, ElapsedTime);
			TitlePenguinText.GetComponent<Text>().color = Color.Lerp(ObjectsText, ObjectsAlpha, ElapsedTime);
			yield return null;
		}

		StartCoroutine(FadeIn4());
	}

	public IEnumerator FadeOutBack7() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 25.0f;
			SlideText7A.GetComponent<Text>().color = Color.Lerp(ObjectsText, ObjectsAlpha, ElapsedTime);
			SlideImage7.GetComponent<Image>().color = Color.Lerp(ObjectsOriginal, ObjectsAlpha, ElapsedTime);
			yield return null;
		}

		StartCoroutine(FadeIn6());
	}

	public IEnumerator FadeOutBack8() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 25.0f;
			SlideText8A.GetComponent<Text>().color = Color.Lerp(ObjectsText, ObjectsAlpha, ElapsedTime);
			SlideImage8.GetComponent<Image>().color = Color.Lerp(ObjectsOriginal, ObjectsAlpha, ElapsedTime);
			yield return null;
		}

		StartCoroutine(FadeIn7());
	}

	public IEnumerator FadeOutBack9() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 25.0f;
			SlideText9A.GetComponent<Text>().color = Color.Lerp(ObjectsText, ObjectsAlpha, ElapsedTime);
			SlideImage9.GetComponent<Image>().color = Color.Lerp(ObjectsOriginal, ObjectsAlpha, ElapsedTime);
			yield return null;
		}

		StartCoroutine(FadeIn8());
	}

	public IEnumerator FadeOutBack10() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 25.0f;
			SlideText10A.GetComponent<Text>().color = Color.Lerp(ObjectsText, ObjectsAlpha, ElapsedTime);
			SlideText10B.GetComponent<Text>().color = Color.Lerp(ObjectsText, ObjectsAlpha, ElapsedTime);
			SlideImage10.GetComponent<Image>().color = Color.Lerp(ObjectsOriginal, ObjectsAlpha, ElapsedTime);
			StartImage.GetComponent<Image>().color = Color.Lerp(ObjectsOriginal, ObjectsAlpha, ElapsedTime);
			yield return null;
		}

		StartImage.enabled = false;
		StartCoroutine(FadeIn9());
	}

// Fading Out On Next Button
	public IEnumerator FadeOutNext1() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 25.0f;
			SlideText1A.GetComponent<Text>().color = Color.Lerp(ObjectsText, ObjectsAlpha, ElapsedTime);
			SlideText1B.GetComponent<Text>().color = Color.Lerp(ObjectsText, ObjectsAlpha, ElapsedTime);
			SlideImage1.GetComponent<Image>().color = Color.Lerp(ObjectsOriginal, ObjectsAlpha, ElapsedTime);
			yield return null;
		}

		StartCoroutine(FadeIn2());
	}

	public IEnumerator FadeOutNext2() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 25.0f;
			SlideText2A.GetComponent<Text>().color = Color.Lerp(ObjectsText, ObjectsAlpha, ElapsedTime);
			yield return null;
		}

		StartCoroutine(FadeIn3());
	}

	public IEnumerator FadeOutNext3() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 25.0f;
			SlideText3A.GetComponent<Text>().color = Color.Lerp(ObjectsText, ObjectsAlpha, ElapsedTime);
			SlideText3B.GetComponent<Text>().color = Color.Lerp(ObjectsText, ObjectsAlpha, ElapsedTime);
			SlideImage3A.GetComponent<Image>().color = Color.Lerp(ObjectsOriginal, ObjectsAlpha, ElapsedTime);
			SlideImage3B.GetComponent<Image>().color = Color.Lerp(ObjectsOriginal, ObjectsAlpha, ElapsedTime);
			yield return null;
		}

		StartCoroutine(FadeIn4());
	}

	public IEnumerator FadeOutNext4() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 25.0f;
			SlideText4A.GetComponent<Text>().color = Color.Lerp(ObjectsText, ObjectsAlpha, ElapsedTime);
			SlideImage4.GetComponent<Image>().color = Color.Lerp(ObjectsOriginal, ObjectsAlpha, ElapsedTime);
			TitleGameplayText.GetComponent<Text>().color = Color.Lerp(ObjectsText, ObjectsAlpha, ElapsedTime);
			yield return null;
		}

		StartCoroutine(FadeIn6());
	}

	public IEnumerator FadeOutNext6() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 25.0f;
			SlideText6A.GetComponent<Text>().color = Color.Lerp(ObjectsText, ObjectsAlpha, ElapsedTime);
			SlideImage6.GetComponent<Image>().color = Color.Lerp(ObjectsOriginal, ObjectsAlpha, ElapsedTime);
			yield return null;
		}

		StartCoroutine(FadeIn7());
	}

	public IEnumerator FadeOutNext7() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 25.0f;
			SlideText7A.GetComponent<Text>().color = Color.Lerp(ObjectsText, ObjectsAlpha, ElapsedTime);
			SlideImage7.GetComponent<Image>().color = Color.Lerp(ObjectsOriginal, ObjectsAlpha, ElapsedTime);
			yield return null;
		}

		StartCoroutine(FadeIn8());
	}

	public IEnumerator FadeOutNext8() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 25.0f;
			SlideText8A.GetComponent<Text>().color = Color.Lerp(ObjectsText, ObjectsAlpha, ElapsedTime);
			SlideImage8.GetComponent<Image>().color = Color.Lerp(ObjectsOriginal, ObjectsAlpha, ElapsedTime);
			yield return null;
		}

		StartCoroutine(FadeIn9());
	}

	public IEnumerator FadeOutNext9() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 25.0f;
			SlideText9A.GetComponent<Text>().color = Color.Lerp(ObjectsText, ObjectsAlpha, ElapsedTime);
			SlideImage9.GetComponent<Image>().color = Color.Lerp(ObjectsOriginal, ObjectsAlpha, ElapsedTime);
			NextImage.GetComponent<Image>().color = Color.Lerp(ObjectsOriginal, ObjectsAlpha, ElapsedTime);
			yield return null;
		}

		NextImage.enabled = false;
		StartCoroutine(FadeIn10());
	}

// Fading Out On Start Button
	public IEnumerator FadeInOverlayToStart() {
		float ElapsedTime = 0.0f;
		OverlayImage.enabled = true;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 5.0f;
			OverlayImage.GetComponent<Image>().color = Color.Lerp(OverlayAlpha, OverlayOriginal, ElapsedTime);
			yield return null;
		}

		Scene03LoadRun.Scene03Load();
	}

// Fading In Pages
	public IEnumerator FadeIn1() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 25.0f;
			SlideText1A.GetComponent<Text>().color = Color.Lerp(ObjectsAlpha, ObjectsText, ElapsedTime);
			SlideText1B.GetComponent<Text>().color = Color.Lerp(ObjectsAlpha, ObjectsText, ElapsedTime);
			SlideImage1.GetComponent<Image>().color = Color.Lerp(ObjectsAlpha, ObjectsOriginal, ElapsedTime);
			yield return null;
		}

		SlideNumber = 1;
	}

	public IEnumerator FadeIn2() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			if (SlideNumber == 1) {
				BackImage.enabled = true;
				BackImage.GetComponent<Image>().color = ObjectsAlpha;
				ElapsedTime += Time.deltaTime * 25.0f;
				SlideText2A.GetComponent<Text>().color = Color.Lerp(ObjectsAlpha, ObjectsText, ElapsedTime);
				BackImage.GetComponent<Image>().color = Color.Lerp(ObjectsAlpha, ObjectsOriginal, ElapsedTime);
				yield return null;
			}

			else if (SlideNumber == 3) {
				ElapsedTime += Time.deltaTime * 25.0f;
				SlideText2A.GetComponent<Text>().color = Color.Lerp(ObjectsAlpha, ObjectsText, ElapsedTime);
				yield return null;
			}
		}

		SlideNumber = 2;
	}

	public IEnumerator FadeIn3() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 25.0f;
			SlideText3A.GetComponent<Text>().color = Color.Lerp(ObjectsAlpha, ObjectsText, ElapsedTime);
			SlideText3B.GetComponent<Text>().color = Color.Lerp(ObjectsAlpha, ObjectsText, ElapsedTime);
			SlideImage3A.GetComponent<Image>().color = Color.Lerp(ObjectsAlpha, ObjectsOriginal, ElapsedTime);
			SlideImage3B.GetComponent<Image>().color = Color.Lerp(ObjectsAlpha, ObjectsOriginal, ElapsedTime);
			yield return null;
		}

		SlideNumber = 3;
	}

	public IEnumerator FadeIn4() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			if (SlideNumber == 6) {
				ElapsedTime += Time.deltaTime * 25.0f;
				SlideText4A.GetComponent<Text>().color = Color.Lerp(ObjectsAlpha, ObjectsText, ElapsedTime);
				SlideImage4.GetComponent<Image>().color = Color.Lerp(ObjectsAlpha, ObjectsOriginal, ElapsedTime);
				TitleGameplayText.GetComponent<Text>().color = Color.Lerp(ObjectsAlpha, ObjectsText, ElapsedTime);
				yield return null;
			}

			else if (SlideNumber == 3) {
				ElapsedTime += Time.deltaTime * 25.0f;
				SlideText4A.GetComponent<Text>().color = Color.Lerp(ObjectsAlpha, ObjectsText, ElapsedTime);
				SlideImage4.GetComponent<Image>().color = Color.Lerp(ObjectsAlpha, ObjectsOriginal, ElapsedTime);
				yield return null;
			}
		}

		SlideNumber = 4;
	}

	public IEnumerator FadeIn6() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			if (SlideNumber == 4) {
				ElapsedTime += Time.deltaTime * 25.0f;
				SlideText6A.GetComponent<Text>().color = Color.Lerp(ObjectsAlpha, ObjectsText, ElapsedTime);
				SlideImage6.GetComponent<Image>().color = Color.Lerp(ObjectsAlpha, ObjectsOriginal, ElapsedTime);
				TitlePenguinText.GetComponent<Text>().color = Color.Lerp(ObjectsAlpha, ObjectsText, ElapsedTime);
				yield return null;
			}

			else if (SlideNumber == 7) {
				ElapsedTime += Time.deltaTime * 25.0f;
				SlideText6A.GetComponent<Text>().color = Color.Lerp(ObjectsAlpha, ObjectsText, ElapsedTime);
				SlideImage6.GetComponent<Image>().color = Color.Lerp(ObjectsAlpha, ObjectsOriginal, ElapsedTime);
				yield return null;
			}
		}

		SlideNumber = 6;
	}

	public IEnumerator FadeIn7() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 25.0f;
			SlideText7A.GetComponent<Text>().color = Color.Lerp(ObjectsAlpha, ObjectsText, ElapsedTime);
			SlideImage7.GetComponent<Image>().color = Color.Lerp(ObjectsAlpha, ObjectsOriginal, ElapsedTime);
			yield return null;
		}

		SlideNumber = 7;
	}

	public IEnumerator FadeIn8() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 25.0f;
			SlideText8A.GetComponent<Text>().color = Color.Lerp(ObjectsAlpha, ObjectsText, ElapsedTime);
			SlideImage8.GetComponent<Image>().color = Color.Lerp(ObjectsAlpha, ObjectsOriginal, ElapsedTime);
			yield return null;
		}

		SlideNumber = 8;
	}

	public IEnumerator FadeIn9() {
		float ElapsedTime = 0.0f;

		while (ElapsedTime < 1.0f) {
			if (SlideNumber == 10) {
				NextImage.enabled = true;
				NextImage.GetComponent<Image>().color = ObjectsAlpha;
				ElapsedTime += Time.deltaTime * 25.0f;
				SlideText9A.GetComponent<Text>().color = Color.Lerp(ObjectsAlpha, ObjectsText, ElapsedTime);
				SlideImage9.GetComponent<Image>().color = Color.Lerp(ObjectsAlpha, ObjectsOriginal, ElapsedTime);
				NextImage.GetComponent<Image>().color = Color.Lerp(ObjectsAlpha, ObjectsOriginal, ElapsedTime);
				yield return null;
			}

			else if (SlideNumber == 8) {
				ElapsedTime += Time.deltaTime * 25.0f;
				SlideText9A.GetComponent<Text>().color = Color.Lerp(ObjectsAlpha, ObjectsText, ElapsedTime);
				SlideImage9.GetComponent<Image>().color = Color.Lerp(ObjectsAlpha, ObjectsOriginal, ElapsedTime);
				yield return null;
			}
		}

		SlideNumber = 9;
	}

	public IEnumerator FadeIn10() {
		float ElapsedTime = 0.0f;
		StartImage.enabled = true;

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * 25.0f;
			SlideText10A.GetComponent<Text>().color = Color.Lerp(ObjectsAlpha, ObjectsText, ElapsedTime);
			SlideText10B.GetComponent<Text>().color = Color.Lerp(ObjectsAlpha, ObjectsText, ElapsedTime);
			SlideImage10.GetComponent<Image>().color = Color.Lerp(ObjectsAlpha, ObjectsOriginal, ElapsedTime);
			StartImage.GetComponent<Image>().color = Color.Lerp(ObjectsAlpha, ObjectsOriginal, ElapsedTime);
			yield return null;
		}

		SlideNumber = 10;
	}
	
// ---------------------------------------- END: OTHER FUNCTIONS ----------------------------------------
}