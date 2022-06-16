using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameplayActions : MonoBehaviour {
		
// ---------------------------------------- START: LIST OF VARIABLES ----------------------------------------
// --------------- PUBLIC VARIABLES ---------------
	// Main Camera
	public Camera MainCamera;

	// Penguins
	public GameObject Catherine;
	public GameObject Hadrian;
	public GameObject Louis;
	public GameObject Victoria;

	// Snowballs
	public GameObject SnowballA;
	public GameObject SnowballB;
	public GameObject SnowballC;
	public GameObject SnowballD;

	// Specials
	public GameObject SnowballA2;
	public GameObject SnowballCrown;
	public GameObject SpecialWall;

	// Score Text
	public Text ScoreText;

	// Audio Files
	public AudioClip AudioClipCrown;
	public AudioClip AudioClipMirror;
	public AudioClip AudioClipPenguinHitFemale;
	public AudioClip AudioClipPenguinHitMale;
	public AudioClip AudioClipPenguinLaughA;
	public AudioClip AudioClipPenguinLaughB;
	public AudioClip AudioClipSnowballHit;
	public AudioClip AudioClipWallBuilding;
	public AudioSource AudioSourceCrown;
	public AudioSource AudioSourceMirror;
	public AudioSource AudioSourcePenguinHitFemale;
	public AudioSource AudioSourcePenguinHitMale;
	public AudioSource AudioSourcePenguinLaughA;
	public AudioSource AudioSourcePenguinLaughB;
	public AudioSource AudioSourceSnowballHit;
	public AudioSource AudioSourceWallBuilding;
	
// --------------- PRIVATE VARIABLES ---------------
	// Animation Controllers
	Animator AnimatorCatherine;
	Animator AnimatorHadrian;
	Animator AnimatorLouis;
	Animator AnimatorVictoria;

	// Raycasting
	RaycastHit PlayerThrow;
	Ray PlayerThrowRay;

	// Camera Movements
	Vector3 CameraPositionAttack;
	Vector3 CameraPositionDodge;
	Vector3 CameraPositionCurrent;
	float CameraMoveSpeed;

	// Wall Movements
	Vector3 WallStart;
	Vector3 WallEnd;
	Vector3 WallCurrent;
	float WallSpeedUp;
	float WallSpeedDown;
	float WallElapsedTime;

	// Player Hit
	Vector3 PlayerHit;

	// Snowball A
	Vector3 SnowballStartA;
	Vector3 SnowballArcA;
	Vector3 SnowballCurrentA;
	float ArcHeightA;
	float SnowballSpeedAUp;
	float SnowballSpeedADown;
	float ElapsedTimeSnowballA;

	// Snowball B
	Vector3 SnowballStartB;
	Vector3 SnowballArcB;
	Vector3 SnowballCurrentB;
	float ArcHeightB;
	float SnowballSpeedBUp;
	float SnowballSpeedBDown;
	float ElapsedTimeSnowballB;

	// Snowball C
	Vector3 SnowballStartC;
	Vector3 SnowballArcC;
	Vector3 SnowballCurrentC;
	float ArcHeightC;
	float SnowballSpeedCUp;
	float SnowballSpeedCDown;
	float ElapsedTimeSnowballC;

	// Snowball D
	Vector3 SnowballStartD;
	Vector3 SnowballArcD;
	Vector3 SnowballCurrentD;
	float ArcHeightD;
	float SnowballSpeedDUp;
	float SnowballSpeedDDown;
	float ElapsedTimeSnowballD;

	// Snowball A2
	Vector3 SnowballStartA2;
	Vector3 SnowballArcA2;
	Vector3 SnowballCurrentA2;
	float ArcHeightA2;
	float SnowballSpeedA2Up;
	float SnowballSpeedA2Down;
	float ElapsedTimeSnowballA2;

	// Special Crown
	Vector3 SnowballStartCrown;
	Vector3 SnowballArcCrown;
	Vector3 SnowballCurrentCrown;
	float ArcHeightCrown;
	float SnowballSpeedCrownUp;
	float SnowballSpeedCrownDown;
	float ElapsedTimeSnowballCrown;

	// Local Scales
	Vector3 LocalScaleSnowballA;
	Vector3 LocalScaleSnowballB;
	Vector3 LocalScaleSnowballC;
	Vector3 LocalScaleSnowballD;
	Vector3 LocalScaleSnowballA2;

	// Player Hitting Snowballs
	bool PlayerHitSnowballA;
	bool PlayerHitSnowballB;
	bool PlayerHitSnowballC;
	bool PlayerHitSnowballD;
	bool PlayerHitSnowballA2;

	// Elapsed Times
	float ElapsedTimeCatherine;
	float ElapsedTimeHadrian;
	float ElapsedTimeLouis;
	float ElapsedTimeVictoria;

	// Throwing Times
	float ThrowingTimeCatherine;
	float ThrowingTimeHadrian;
	float ThrowingTimeLouis;
	float ThrowingTimeVictoria;

	// Special Ability Times
	float UsingAbilityTimeCatherine;
	float UsingAbilityTimeHadrian;
	float UsingAbilityTimeLouis;
	float UsingAbilityTimeVictoria;

	// Dodge Random Int
	int DodgeDetermination;

	// Random Laughing
	float LaughElapsedTime;
	float LaughFinalTime;
	bool LaughIsPlaying;
	int RandomizedLaugh;
	
// --------------- STATIC VARIABLES ---------------
	// Parameters
	public static int AnimationParameterCatherine;
	public static int AnimationParameterHadrian;
	public static int AnimationParameterLouis;
	public static int AnimationParameterVictoria;

	// Ready To Play
	public static bool ReadyToPlay;
	
// ---------------------------------------- END: LIST OF VARIABLES ----------------------------------------
// ---------------------------------------- START: CALLING OTHER SCRIPTS ----------------------------------------
	public SceneGameplay PlayGameOverRun;
	
// ---------------------------------------- END: CALLING OTHER SCRIPTS ----------------------------------------
// ---------------------------------------- START: INITIAL FUNCTIONS ----------------------------------------
// --------------- START FUNCTION ---------------
	void Start() {
		// Set Controllers
		AnimatorCatherine = Catherine.GetComponent<Animator>();
		AnimatorHadrian = Hadrian.GetComponent<Animator>();
		AnimatorLouis = Louis.GetComponent<Animator>();
		AnimatorVictoria = Victoria.GetComponent<Animator>();

		// Set Parameters
		AnimationParameterCatherine = 0;
		AnimationParameterHadrian = 0;
		AnimationParameterLouis = 0;
		AnimationParameterVictoria = 0;

		// Set Camera Movements
		CameraPositionAttack = new Vector3(0.0f, 25.0f, -10.0f);
		CameraPositionDodge = new Vector3(-16.0f, 4.0f, -1.0f);
		CameraMoveSpeed = 0.0f;
		CameraPositionCurrent = CameraPositionAttack;
		MainCamera.transform.position = CameraPositionCurrent;
		DataPlayer.PlayerHiding = false;

		// Set Wall Movements
		WallStart = new Vector3 (0.0f, -35.0f, 90.0f);
		WallEnd = new Vector3 (0.0f, -11.0f, 90.0f);
		WallSpeedUp = 0.0f;
		WallSpeedDown = 0.0f;
		WallElapsedTime = 0.0f;
		WallCurrent = WallStart;
		SpecialWall.transform.position = WallCurrent;

		// Set Elapsed Times
		ElapsedTimeCatherine = 0.0f;
		ElapsedTimeHadrian = 0.0f;
		ElapsedTimeLouis = 0.0f;
		ElapsedTimeVictoria = 0.0f;

		// Set Throwing Times
		ThrowingTimeCatherine = 0.0f;
		ThrowingTimeHadrian = 0.0f;
		ThrowingTimeLouis = 0.0f;
		ThrowingTimeVictoria = 0.0f;

		// Set Special Ability Times
		UsingAbilityTimeCatherine = 0.0f;
		UsingAbilityTimeHadrian = 0.0f;
		UsingAbilityTimeLouis = 0.0f;
		UsingAbilityTimeVictoria = 0.0f;

		// Randomize Final Throwing Time
		DataPenguins.TimeBetweenThrowsCatherine = Random.Range(0.0f, 5.0f);
		DataPenguins.TimeBetweenThrowsHadrian = Random.Range(0.0f, 5.0f);
		DataPenguins.TimeBetweenThrowsLouis = Random.Range(0.0f, 5.0f);
		DataPenguins.TimeBetweenThrowsVictoria = Random.Range(0.0f, 5.0f);

		// Randomize Final Special Ability Time
		DataPenguins.TimeUntilSpecialCatherine = Random.Range(3.0f, 10.0f);
		DataPenguins.TimeUntilSpecialHadrian = Random.Range(3.0f, 10.0f);
		DataPenguins.TimeUntilSpecialLouis = Random.Range(3.0f, 10.0f);
		DataPenguins.TimeUntilSpecialVictoria = Random.Range(3.0f, 10.0f);

		// Set Dodge Determination
		DodgeDetermination = 0;

		// Set Player Hit
		PlayerHit = new Vector3(0.0f, 25.0f, -10.0f);

		// Set Snowball A
		SnowballSpeedAUp = 0.0f;
		SnowballSpeedADown = 0.0f;
		SnowballStartA = new Vector3(-27.0f, 0.0f, 112.0f);
		SnowballArcA = new Vector3(-13.5f, 55.0f, 65.0f);
		ArcHeightA = Random.Range(25.0f, 50.0f);
		ElapsedTimeSnowballA = 0.0f;
		SnowballA.SetActive(false);
		SnowballCurrentA = SnowballStartA;
		SnowballA.transform.position = SnowballCurrentA;

		// Set Snowball B
		SnowballSpeedBUp = 0.0f;
		SnowballSpeedBDown = 0.0f;
		SnowballStartB = new Vector3(-14.0f, -6.5f, 217.0f);
		SnowballArcB = new Vector3(-7.0f, 48.0f, 135.0f);
		ArcHeightB = Random.Range(25.0f, 50.0f);
		ElapsedTimeSnowballB = 0.0f;
		SnowballB.SetActive(false);
		SnowballCurrentB = SnowballStartB;
		SnowballB.transform.position = SnowballCurrentB;

		// Set Snowball C
		SnowballSpeedCUp = 0.0f;
		SnowballSpeedCDown = 0.0f;
		SnowballStartC = new Vector3(5.5f, 2.5f, 162.0f);
		SnowballArcC = new Vector3(2.75f, 65.0f, 105.0f);
		ArcHeightC = Random.Range(25.0f, 50.0f);
		ElapsedTimeSnowballC = 0.0f;
		SnowballC.SetActive(false);
		SnowballCurrentC = SnowballStartC;
		SnowballC.transform.position = SnowballCurrentC;

		// Set Snowball D
		SnowballSpeedDUp = 0.0f;
		SnowballSpeedDDown = 0.0f;
		SnowballStartD = new Vector3(42.0f, -1.0f, 143.0f);
		SnowballArcD = new Vector3(21.0f, 52.0f, 60.0f);
		ArcHeightD = Random.Range(25.0f, 50.0f);
		ElapsedTimeSnowballD = 0.0f;
		SnowballD.SetActive(false);
		SnowballCurrentD = SnowballStartD;
		SnowballD.transform.position = SnowballCurrentD;

		// Set Snowball A2
		SnowballSpeedA2Up = 0.0f;
		SnowballSpeedA2Down = 0.0f;
		SnowballStartA2 = new Vector3(-27.0f, 0.0f, 112.0f);
		SnowballArcA2 = new Vector3(-15.5f, 58.0f, 62.0f);
		ArcHeightA2 = Random.Range(25.0f, 50.0f);
		ElapsedTimeSnowballA2 = 0.0f;
		SnowballA2.SetActive(false);
		SnowballCurrentA2 = SnowballStartA2;
		SnowballA2.transform.position = SnowballCurrentA2;

		// Set Snowball Crown
		SnowballSpeedCrownUp = 0.0f;
		SnowballSpeedCrownDown = 0.0f;
		SnowballStartCrown = new Vector3(42.0f, -1.0f, 143.0f);
		SnowballArcCrown = new Vector3(21.0f, 52.0f, 60.0f);
		ArcHeightCrown = Random.Range(25.0f, 50.0f);
		ElapsedTimeSnowballCrown = 0.0f;
		SnowballCrown.SetActive(false);
		SnowballCurrentCrown = SnowballStartCrown;
		SnowballCrown.transform.position = SnowballCurrentCrown;

		// Player Hitting Snowballs
		PlayerHitSnowballA = false;
		PlayerHitSnowballB = false;
		PlayerHitSnowballC = false;
		PlayerHitSnowballD = false;
		PlayerHitSnowballA2 = false;

		// Set Volumes
		AudioSourceCrown.volume = 4.0f;
		AudioSourceMirror.volume = 4.0f;
		AudioSourcePenguinHitFemale.volume = 4.0f;
		AudioSourcePenguinHitMale.volume = 4.0f;
		AudioSourcePenguinLaughA.volume = 4.0f;
		AudioSourcePenguinLaughB.volume = 4.0f;
		AudioSourceSnowballHit.volume = 4.0f;
		AudioSourceWallBuilding.volume = 4.0f;

		// Random Laughing
		LaughElapsedTime = 0.0f;
		LaughFinalTime = Random.Range(3.0f, 10.0f);
		LaughIsPlaying = false;
		RandomizedLaugh = 1;

		// Playing Random Laughs
		StartCoroutine(UpdatingRandomLaughs());
	}
	
// --------------- AWAKE FUNCTION ---------------
	void Awake() {
		
	}
	
// --------------- UPDATE FUNCTION ---------------
	void Update() {
		if ((ReadyToPlay == true) && (DataPlayer.PlayerHiding == false)) {
			UpdatingMainActionsCatherine();
			UpdatingMainActionsHadrian();
			UpdatingMainActionsLouis();
			UpdatingMainActionsVictoria();
			UpdatingPlayerSnowballs();
			RotateAllSnowballs();
		}

		else if ((ReadyToPlay == false) || (DataPlayer.PlayerHiding == true)) {
			SnowballA.SetActive(false);
			SnowballB.SetActive(false);
			SnowballC.SetActive(false);
			SnowballD.SetActive(false);
			SnowballA2.SetActive(false);
			SnowballCrown.SetActive(false);
			SnowballA.transform.position = SnowballStartA;
			SnowballB.transform.position = SnowballStartB;
			SnowballC.transform.position = SnowballStartC;
			SnowballD.transform.position = SnowballStartD;
			SnowballA2.transform.position = SnowballStartA2;
			SnowballCrown.transform.position = SnowballStartCrown;
			ThrowingTimeCatherine = 0.0f;
			ThrowingTimeHadrian = 0.0f;
			ThrowingTimeLouis = 0.0f;
			ThrowingTimeVictoria = 0.0f;
			ElapsedTimeCatherine = 0.0f;
			ElapsedTimeHadrian = 0.0f;
			ElapsedTimeLouis = 0.0f;
			ElapsedTimeHadrian = 0.0f;
			ElapsedTimeSnowballA = 0.0f;
			ElapsedTimeSnowballB = 0.0f;
			ElapsedTimeSnowballC = 0.0f;
			ElapsedTimeSnowballD = 0.0f;
			ElapsedTimeSnowballA2 = 0.0f;
			ElapsedTimeSnowballCrown = 0.0f;
			SnowballSpeedAUp = 0.0f;
			SnowballSpeedADown = 0.0f;
			SnowballSpeedBUp = 0.0f;
			SnowballSpeedBDown = 0.0f;
			SnowballSpeedCUp = 0.0f;
			SnowballSpeedCDown = 0.0f;
			SnowballSpeedDUp = 0.0f;
			SnowballSpeedDDown = 0.0f;
			SnowballSpeedA2Up = 0.0f;
			SnowballSpeedA2Down = 0.0f;
			SnowballSpeedCrownUp = 0.0f;
			SnowballSpeedCrownDown = 0.0f;
			AnimationParameterCatherine = 0;
			AnimationParameterHadrian = 0;
			AnimationParameterLouis = 0;
			AnimationParameterVictoria = 0;
		}

		UpdatingCameraView();
		UpdatingPlayerScore();
		UpdatingIfGettingHit();
	}
	
// ---------------------------------------- END: INITIAL FUNCTIONS ----------------------------------------
// ---------------------------------------- START: OTHER FUNCTIONS ----------------------------------------
// Main Functions
	public void UpdatingMainActionsCatherine() {
		if (AnimationParameterCatherine == 1) {
			// Dodging
			AnimatorCatherine.SetInteger("CatherineParameter", 1);
			ThrowingTimeCatherine = 0.0f;

			if (ElapsedTimeCatherine < 2.08f) {
				ElapsedTimeCatherine += Time.deltaTime;
				DataPenguins.IsHidingCatherine = true;
			}

			else {
				DataPenguins.IsHidingCatherine = false;
				DataPenguins.TimeBetweenThrowsCatherine = Random.Range(0.0f, 5.0f);
				AnimationParameterCatherine = 0;
			}
		}

		else if (AnimationParameterCatherine == 2) {
			// Getting Hit
			AnimatorCatherine.SetInteger("CatherineParameter", 2);
			ThrowingTimeCatherine = 0.0f;

			if (ElapsedTimeCatherine < 2.08f) {
				ElapsedTimeCatherine += Time.deltaTime;
				DataPenguins.IsLosingCatherine = true;
			}

			else {
				DataPenguins.IsLosingCatherine = false;
				DataPenguins.TimeBetweenThrowsCatherine = Random.Range(0.0f, 5.0f);
				AnimationParameterCatherine = 0;
			}
		}

		else if (AnimationParameterCatherine == 3) {
			// Throwing
			AnimatorCatherine.SetInteger("CatherineParameter", 3);
			ThrowingTimeCatherine = 0.0f;

			if (ElapsedTimeCatherine < 1.0f) {
				ElapsedTimeCatherine += Time.deltaTime;
				DataPenguins.IsThrowingCatherine = true;
			}

			else if ((ElapsedTimeCatherine >= 1.0f) && (ElapsedTimeCatherine < 4.5f)) {
				if (PlayerHitSnowballA == false) {
					ElapsedTimeCatherine += Time.deltaTime;
					HittingSnowballA();
					GetToPlayerPositionA();
				}

				else {
					ElapsedTimeCatherine = 4.5f;
				}
			}

			else {
				SnowballSpeedAUp = 0.0f;
				SnowballSpeedADown = 0.0f;
				ArcHeightA = Random.Range(25.0f, 50.0f);
				ElapsedTimeSnowballA = 0.0f;
				SnowballA.SetActive(false);
				SnowballCurrentA = SnowballStartA;
				SnowballA.transform.position = SnowballCurrentA;
				UsingAbilityTimeCatherine += 1.0f;
				DataPenguins.TimeBetweenThrowsCatherine = Random.Range(0.0f, 5.0f);
				DataPenguins.IsThrowingCatherine = false;
				AnimationParameterCatherine = 0;
			}
		}

		else if (AnimationParameterCatherine == 4) {
			// Using Ability
			AnimatorCatherine.SetInteger("CatherineParameter", 4);
			UsingAbilityTimeCatherine = 0.0f;
			ThrowingTimeCatherine = 0.0f;

			if (ElapsedTimeCatherine < 1.0f) {
				ElapsedTimeCatherine += Time.deltaTime;
				DataPenguins.IsUsingSpecialCatherine = true;
			}

			else if ((ElapsedTimeCatherine >= 1.0f) && (ElapsedTimeCatherine < 4.5f)) {
				if ((PlayerHitSnowballA == false) || (PlayerHitSnowballA2 == false)) {
					ElapsedTimeCatherine += Time.deltaTime;
					HittingSnowballA();
					GetToPlayerPositionA();
					HittingSnowballA2();
					GetToPlayerPositionA2();
				}

				else {
					ElapsedTimeCatherine = 4.5f;
				}
			}

			else {
				SnowballSpeedAUp = 0.0f;
				SnowballSpeedADown = 0.0f;
				ArcHeightA = Random.Range(25.0f, 50.0f);
				ElapsedTimeSnowballA = 0.0f;
				SnowballA.SetActive(false);
				SnowballCurrentA = SnowballStartA;
				SnowballA.transform.position = SnowballCurrentA;
				SnowballSpeedA2Up = 0.0f;
				SnowballSpeedA2Down = 0.0f;
				ArcHeightA2 = Random.Range(25.0f, 50.0f);
				ElapsedTimeSnowballA2 = 0.0f;
				SnowballA2.SetActive(false);
				SnowballCurrentA2 = SnowballStartA2;
				SnowballA2.transform.position = SnowballCurrentA2;
				DataPenguins.IsUsingSpecialCatherine = false;
				DataPenguins.TimeBetweenThrowsCatherine = Random.Range(0.0f, 5.0f);
				DataPenguins.TimeUntilSpecialCatherine = Random.Range(3.0f, 10.0f);
				AnimationParameterCatherine = 0;
			}
		}

		else {
			// Idling
			AnimatorCatherine.SetInteger("CatherineParameter", 0);
			ElapsedTimeCatherine = 0.0f;
			PlayerHitSnowballA = false;
			PlayerHitSnowballA2 = false;

			if (UsingAbilityTimeCatherine < DataPenguins.TimeUntilSpecialCatherine) {
				if (ThrowingTimeCatherine < DataPenguins.TimeBetweenThrowsCatherine) {
					ThrowingTimeCatherine += Time.deltaTime;
				}

				else {
					AnimationParameterCatherine = 3;
				}
			}

			else {
				if (ThrowingTimeCatherine < DataPenguins.TimeBetweenThrowsCatherine) {
					ThrowingTimeCatherine += Time.deltaTime;
				}

				else {
					AnimationParameterCatherine = 4;
				}
			}
		}
	}

	public void UpdatingMainActionsHadrian() {
		if (AnimationParameterHadrian == 1) {
			// Dodging
			AnimatorHadrian.SetInteger("HadrianParameter", 1);
			ThrowingTimeHadrian = 0.0f;

			if (ElapsedTimeHadrian < 2.08f) {
				ElapsedTimeHadrian += Time.deltaTime;
				DataPenguins.IsHidingHadrian = true;
			}

			else {
				DataPenguins.IsHidingHadrian = false;
				DataPenguins.TimeBetweenThrowsHadrian = Random.Range(0.0f, 5.0f);
				AnimationParameterHadrian = 0;
			}
		}

		else if (AnimationParameterHadrian == 2) {
			// Getting Hit
			AnimatorHadrian.SetInteger("HadrianParameter", 2);
			ThrowingTimeHadrian = 0.0f;

			if (ElapsedTimeHadrian < 2.08f) {
				ElapsedTimeHadrian += Time.deltaTime;
				DataPenguins.IsLosingHadrian = true;
			}

			else {
				DataPenguins.IsLosingHadrian = false;
				DataPenguins.TimeBetweenThrowsHadrian = Random.Range(0.0f, 5.0f);
				AnimationParameterHadrian = 0;
			}
		}

		else if (AnimationParameterHadrian == 3) {
			// Throwing
			AnimatorHadrian.SetInteger("HadrianParameter", 3);
			ThrowingTimeHadrian = 0.0f;

			if (ElapsedTimeHadrian < 1.0f) {
				ElapsedTimeHadrian += Time.deltaTime;
				DataPenguins.IsThrowingHadrian = true;
			}

			else if ((ElapsedTimeHadrian >= 1.0f) && (ElapsedTimeHadrian < 4.5f)) {
				if (PlayerHitSnowballB == false) {
					ElapsedTimeHadrian += Time.deltaTime;
					HittingSnowballB();
					GetToPlayerPositionB();
				}

				else {
					ElapsedTimeHadrian = 4.5f;
				}
			}

			else {
				SnowballSpeedBUp = 0.0f;
				SnowballSpeedBDown = 0.0f;
				ArcHeightB = Random.Range(25.0f, 50.0f);
				ElapsedTimeSnowballB = 0.0f;
				SnowballB.SetActive(false);
				SnowballCurrentB = SnowballStartB;
				SnowballB.transform.position = SnowballCurrentB;
				UsingAbilityTimeHadrian += 1.0f;
				DataPenguins.TimeBetweenThrowsHadrian = Random.Range(0.0f, 5.0f);
				DataPenguins.IsThrowingHadrian = false;
				AnimationParameterHadrian = 0;
			}
		}

		else if (AnimationParameterHadrian == 4) {
			// Using Ability
			AnimatorHadrian.SetInteger("HadrianParameter", 4);
			UsingAbilityTimeHadrian = 0.0f;
			ThrowingTimeHadrian = 0.0f;
			DataPenguins.IsProtectingCatherine = true;
			DataPenguins.IsProtectingHadrian = true;
			DataPenguins.IsProtectingLouis = true;
			DataPenguins.IsProtectingVictoria = true;
			AudioSourceWallBuilding.Play();
			UseSpecialAbilityHadrian();

			if (ElapsedTimeHadrian < 7.0f) {
				ElapsedTimeHadrian += Time.deltaTime;
				DataPenguins.IsUsingSpecialHadrian = true;
			}

			else {
				DataPenguins.IsUsingSpecialHadrian = false;
				DataPenguins.IsProtectingCatherine = false;
				DataPenguins.IsProtectingHadrian = false;
				DataPenguins.IsProtectingLouis = false;
				DataPenguins.IsProtectingVictoria = false;
				WallSpeedUp = 0.0f;
				WallSpeedDown = 0.0f;
				WallElapsedTime = 0.0f;
				DataPenguins.TimeBetweenThrowsHadrian = Random.Range(0.0f, 5.0f);
				DataPenguins.TimeUntilSpecialHadrian = Random.Range(3.0f, 10.0f);
				AnimationParameterHadrian = 0;
			}
		}

		else {
			// Idling
			AnimatorHadrian.SetInteger("HadrianParameter", 0);
			ElapsedTimeHadrian = 0.0f;
			PlayerHitSnowballB = false;

			if (UsingAbilityTimeHadrian < DataPenguins.TimeUntilSpecialHadrian) {
				if (ThrowingTimeHadrian < DataPenguins.TimeBetweenThrowsHadrian) {
					ThrowingTimeHadrian += Time.deltaTime;
				}

				else {
					AnimationParameterHadrian = 3;
				}
			}

			else {
				if (ThrowingTimeHadrian < DataPenguins.TimeBetweenThrowsHadrian) {
					ThrowingTimeHadrian += Time.deltaTime;
				}

				else {
					AnimationParameterHadrian = 4;
				}
			}
		}
	}

	public void UpdatingMainActionsLouis() {
		if (AnimationParameterLouis == 1) {
			// Dodging
			AnimatorLouis.SetInteger("LouisParameter", 1);
			ThrowingTimeLouis = 0.0f;

			if (ElapsedTimeLouis < 2.08f) {
				ElapsedTimeLouis += Time.deltaTime;
				DataPenguins.IsHidingLouis = true;
			}

			else {
				DataPenguins.IsHidingLouis = false;
				DataPenguins.TimeBetweenThrowsLouis = Random.Range(0.0f, 5.0f);
				AnimationParameterLouis = 0;
			}
		}

		else if (AnimationParameterLouis == 2) {
			// Getting Hit
			AnimatorLouis.SetInteger("LouisParameter", 2);
			ThrowingTimeLouis = 0.0f;

			if (ElapsedTimeLouis < 2.08f) {
				ElapsedTimeLouis += Time.deltaTime;
				DataPenguins.IsLosingLouis = true;
			}

			else {
				DataPenguins.IsLosingLouis = false;
				DataPenguins.TimeBetweenThrowsLouis = Random.Range(0.0f, 5.0f);
				AnimationParameterLouis = 0;
			}
		}

		else if (AnimationParameterLouis == 3) {
			// Throwing
			AnimatorLouis.SetInteger("LouisParameter", 3);
			ThrowingTimeLouis = 0.0f;

			if (ElapsedTimeLouis < 1.0f) {
				ElapsedTimeLouis += Time.deltaTime;
				DataPenguins.IsThrowingLouis = true;
			}

			else if ((ElapsedTimeLouis >= 1.0f) && (ElapsedTimeLouis < 4.5f)) {
				if (PlayerHitSnowballC == false) {
					ElapsedTimeLouis += Time.deltaTime;
					HittingSnowballC();
					GetToPlayerPositionC();
				}

				else {
					ElapsedTimeLouis = 4.5f;
				}
			}

			else {
				SnowballSpeedCUp = 0.0f;
				SnowballSpeedCDown = 0.0f;
				ArcHeightC = Random.Range(25.0f, 50.0f);
				ElapsedTimeSnowballC = 0.0f;
				SnowballC.SetActive(false);
				SnowballCurrentC = SnowballStartC;
				SnowballC.transform.position = SnowballCurrentC;
				UsingAbilityTimeLouis += 1.0f;
				DataPenguins.TimeBetweenThrowsLouis = Random.Range(0.0f, 5.0f);
				DataPenguins.IsThrowingLouis = false;
				AnimationParameterLouis = 0;
			}
		}

		else if (AnimationParameterLouis == 4) {
			// Using Ability
			AnimatorLouis.SetInteger("LouisParameter", 4);
			UsingAbilityTimeLouis = 0.0f;
			ThrowingTimeLouis = 0.0f;

			if (ElapsedTimeLouis < 2.5f) {
				ElapsedTimeLouis += Time.deltaTime;
				DataPenguins.IsUsingSpecialLouis = true;
			}

			else {
				AudioSourceMirror.Play();
				UseSpecialAbilityLouis();
				DataPenguins.IsUsingSpecialLouis = false;
				DataPenguins.TimeBetweenThrowsLouis = Random.Range(0.0f, 5.0f);
				DataPenguins.TimeUntilSpecialLouis = Random.Range(3.0f, 10.0f);
				AnimationParameterLouis = 0;
			}
		}

		else {
			// Idling
			AnimatorLouis.SetInteger("LouisParameter", 0);
			ElapsedTimeLouis = 0.0f;
			PlayerHitSnowballC = false;

			if (UsingAbilityTimeLouis < DataPenguins.TimeUntilSpecialLouis) {
				if (ThrowingTimeLouis < DataPenguins.TimeBetweenThrowsLouis) {
					ThrowingTimeLouis += Time.deltaTime;
				}

				else {
					AnimationParameterLouis = 3;
				}
			}

			else {
				if (ThrowingTimeLouis < DataPenguins.TimeBetweenThrowsLouis) {
					ThrowingTimeLouis += Time.deltaTime;
				}

				else {
					AnimationParameterLouis = 4;
				}
			}
		}
	}

	public void UpdatingMainActionsVictoria() {
		if (AnimationParameterVictoria == 1) {
			// Dodging
			AnimatorVictoria.SetInteger("VictoriaParameter", 1);
			ThrowingTimeVictoria = 0.0f;

			if (ElapsedTimeVictoria < 2.08f) {
				ElapsedTimeVictoria += Time.deltaTime;
				DataPenguins.IsHidingVictoria = true;
			}

			else {
				DataPenguins.IsHidingVictoria = false;
				DataPenguins.TimeBetweenThrowsVictoria = Random.Range(0.0f, 5.0f);
				AnimationParameterVictoria = 0;
			}
		}

		else if (AnimationParameterVictoria == 2) {
			// Getting Hit
			AnimatorVictoria.SetInteger("VictoriaParameter", 2);
			ThrowingTimeVictoria = 0.0f;

			if (ElapsedTimeVictoria < 2.08f) {
				ElapsedTimeVictoria += Time.deltaTime;
				DataPenguins.IsLosingVictoria = true;
			}

			else {
				DataPenguins.IsLosingVictoria = false;
				DataPenguins.TimeBetweenThrowsVictoria = Random.Range(0.0f, 5.0f);
				AnimationParameterVictoria = 0;
			}
		}

		else if (AnimationParameterVictoria == 3) {
			// Throwing
			AnimatorVictoria.SetInteger("VictoriaParameter", 3);
			ThrowingTimeVictoria = 0.0f;

			if (ElapsedTimeVictoria < 1.0f) {
				ElapsedTimeVictoria += Time.deltaTime;
				DataPenguins.IsThrowingVictoria = true;
			}

			else if ((ElapsedTimeVictoria >= 1.0f) && (ElapsedTimeVictoria < 4.5f)) {
				if (PlayerHitSnowballD == false) {
					ElapsedTimeVictoria += Time.deltaTime;
					HittingSnowballD();
					GetToPlayerPositionD();
				}

				else {
					ElapsedTimeVictoria = 4.5f;
				}
			}

			else {
				SnowballSpeedDUp = 0.0f;
				SnowballSpeedDDown = 0.0f;
				ArcHeightD = Random.Range(25.0f, 50.0f);
				ElapsedTimeSnowballD = 0.0f;
				SnowballD.SetActive(false);
				SnowballCurrentD = SnowballStartD;
				SnowballD.transform.position = SnowballCurrentD;
				UsingAbilityTimeVictoria += 1.0f;
				DataPenguins.TimeBetweenThrowsVictoria = Random.Range(0.0f, 5.0f);
				DataPenguins.IsThrowingVictoria = false;
				AnimationParameterVictoria = 0;
			}
		}

		else if (AnimationParameterVictoria == 4) {
			// Using Ability
			AnimatorVictoria.SetInteger("VictoriaParameter", 4);
			UsingAbilityTimeVictoria = 0.0f;
			ThrowingTimeVictoria = 0.0f;

			if (ElapsedTimeVictoria < 1.0f) {
				ElapsedTimeVictoria += Time.deltaTime;
				DataPenguins.IsUsingSpecialVictoria = true;
			}

			else if ((ElapsedTimeVictoria >= 1.0f) && (ElapsedTimeVictoria < 4.5f)) {
				ElapsedTimeVictoria += Time.deltaTime;
				AudioSourceCrown.Play();
				SnowballCrown.SetActive(true);
				GetToPlayerPositionCrown();
			}

			else {
				AudioSourceCrown.Stop();
				SnowballSpeedCrownUp = 0.0f;
				SnowballSpeedCrownDown = 0.0f;
				ArcHeightCrown = Random.Range(25.0f, 50.0f);
				ElapsedTimeSnowballCrown = 0.0f;
				SnowballCrown.SetActive(false);
				SnowballCurrentCrown = SnowballStartCrown;
				SnowballCrown.transform.position = SnowballCurrentCrown;
				DataPenguins.IsUsingSpecialVictoria = false;
				DataPenguins.TimeBetweenThrowsVictoria = Random.Range(0.0f, 5.0f);
				DataPenguins.TimeUntilSpecialVictoria = Random.Range(3.0f, 10.0f);
				AnimationParameterVictoria = 0;
			}
		}

		else {
			// Idling
			AnimatorVictoria.SetInteger("VictoriaParameter", 0);
			ElapsedTimeVictoria = 0.0f;
			PlayerHitSnowballD = false;

			if (UsingAbilityTimeVictoria < DataPenguins.TimeUntilSpecialVictoria) {
				if (ThrowingTimeVictoria < DataPenguins.TimeBetweenThrowsVictoria) {
					ThrowingTimeVictoria += Time.deltaTime;
				}

				else {
					AnimationParameterVictoria = 3;
				}
			}

			else {
				if (ThrowingTimeVictoria < DataPenguins.TimeBetweenThrowsVictoria) {
					ThrowingTimeVictoria += Time.deltaTime;
				}

				else {
					AnimationParameterVictoria = 4;
				}
			}
		}
	}

// Snowballs
	public void GetToPlayerPositionA() {
		ElapsedTimeSnowballA += Time.deltaTime;

		if (ElapsedTimeSnowballA < 1.6f) {
			SnowballSpeedAUp += 0.75f * Time.deltaTime;
			SnowballCurrentA = new Vector3(
				Mathf.Lerp(SnowballStartA.x, SnowballArcA.x, SnowballSpeedAUp), 
				Mathf.Lerp(SnowballStartA.y, ArcHeightA, SnowballSpeedAUp), 
				Mathf.Lerp(SnowballStartA.z, SnowballArcA.z, SnowballSpeedAUp)
			);

			SnowballA.transform.position = SnowballCurrentA;
		}

		else {
			SnowballSpeedADown += 0.75f * Time.deltaTime;
			SnowballCurrentA = new Vector3(
				Mathf.Lerp(SnowballArcA.x, PlayerHit.x, SnowballSpeedADown), 
				Mathf.Lerp(ArcHeightA, PlayerHit.y, SnowballSpeedADown), 
				Mathf.Lerp(SnowballArcA.z, PlayerHit.z, SnowballSpeedADown)
			);

			SnowballA.transform.position = SnowballCurrentA;
		}
	}

	public void GetToPlayerPositionB() {
		ElapsedTimeSnowballB += Time.deltaTime;

		if (ElapsedTimeSnowballB < 1.6f) {
			SnowballSpeedBUp += 0.75f * Time.deltaTime;
			SnowballCurrentB = new Vector3(
				Mathf.Lerp(SnowballStartB.x, SnowballArcB.x, SnowballSpeedBUp), 
				Mathf.Lerp(SnowballStartB.y, ArcHeightB, SnowballSpeedBUp), 
				Mathf.Lerp(SnowballStartB.z, SnowballArcB.z, SnowballSpeedBUp)
			);

			SnowballB.transform.position = SnowballCurrentB;
		}

		else {
			SnowballSpeedBDown += 0.75f * Time.deltaTime;
			SnowballCurrentB = new Vector3(
				Mathf.Lerp(SnowballArcB.x, PlayerHit.x, SnowballSpeedBDown), 
				Mathf.Lerp(ArcHeightB, PlayerHit.y, SnowballSpeedBDown), 
				Mathf.Lerp(SnowballArcB.z, PlayerHit.z, SnowballSpeedBDown)
			);

			SnowballB.transform.position = SnowballCurrentB;
		}
	}

	public void GetToPlayerPositionC() {
		ElapsedTimeSnowballC += Time.deltaTime;

		if (ElapsedTimeSnowballC < 1.6f) {
			SnowballSpeedCUp += 0.75f * Time.deltaTime;
			SnowballCurrentC = new Vector3(
				Mathf.Lerp(SnowballStartC.x, SnowballArcC.x, SnowballSpeedCUp), 
				Mathf.Lerp(SnowballStartC.y, ArcHeightC, SnowballSpeedCUp), 
				Mathf.Lerp(SnowballStartC.z, SnowballArcC.z, SnowballSpeedCUp)
			);

			SnowballC.transform.position = SnowballCurrentC;
		}

		else {
			SnowballSpeedCDown += 0.75f * Time.deltaTime;
			SnowballCurrentC = new Vector3(
				Mathf.Lerp(SnowballArcC.x, PlayerHit.x, SnowballSpeedCDown), 
				Mathf.Lerp(ArcHeightC, PlayerHit.y, SnowballSpeedCDown), 
				Mathf.Lerp(SnowballArcC.z, PlayerHit.z, SnowballSpeedCDown)
			);

			SnowballC.transform.position = SnowballCurrentC;
		}
	}

	public void GetToPlayerPositionD() {
		ElapsedTimeSnowballD += Time.deltaTime;

		if (ElapsedTimeSnowballD < 1.6f) {
			SnowballSpeedDUp += 0.75f * Time.deltaTime;
			SnowballCurrentD = new Vector3(
				Mathf.Lerp(SnowballStartD.x, SnowballArcD.x, SnowballSpeedDUp), 
				Mathf.Lerp(SnowballStartD.y, ArcHeightD, SnowballSpeedDUp), 
				Mathf.Lerp(SnowballStartD.z, SnowballArcD.z, SnowballSpeedDUp)
			);

			SnowballD.transform.position = SnowballCurrentD;
		}

		else {
			SnowballSpeedDDown += 0.75f * Time.deltaTime;
			SnowballCurrentD = new Vector3(
				Mathf.Lerp(SnowballArcD.x, PlayerHit.x, SnowballSpeedDDown), 
				Mathf.Lerp(ArcHeightD, PlayerHit.y, SnowballSpeedDDown), 
				Mathf.Lerp(SnowballArcD.z, PlayerHit.z, SnowballSpeedDDown)
			);

			SnowballD.transform.position = SnowballCurrentD;
		}
	}

	public void GetToPlayerPositionA2() {
		ElapsedTimeSnowballA2 += Time.deltaTime;

		if (ElapsedTimeSnowballA2 < 1.6f) {
			SnowballSpeedA2Up += 0.75f * Time.deltaTime;
			SnowballCurrentA2 = new Vector3(
				Mathf.Lerp(SnowballStartA2.x, SnowballArcA2.x, SnowballSpeedA2Up), 
				Mathf.Lerp(SnowballStartA2.y, ArcHeightA2, SnowballSpeedA2Up), 
				Mathf.Lerp(SnowballStartA2.z, SnowballArcA2.z, SnowballSpeedA2Up)
			);

			SnowballA2.transform.position = SnowballCurrentA2;
		}

		else {
			SnowballSpeedA2Down += 0.75f * Time.deltaTime;
			SnowballCurrentA2 = new Vector3(
				Mathf.Lerp(SnowballArcA2.x, PlayerHit.x, SnowballSpeedA2Down), 
				Mathf.Lerp(ArcHeightA2, PlayerHit.y, SnowballSpeedA2Down), 
				Mathf.Lerp(SnowballArcA2.z, PlayerHit.z, SnowballSpeedA2Down)
			);

			SnowballA2.transform.position = SnowballCurrentA2;
		}
	}

	public void GetToPlayerPositionCrown() {
		ElapsedTimeSnowballCrown += Time.deltaTime;

		if (ElapsedTimeSnowballCrown < 1.6f) {
			SnowballSpeedCrownUp += 0.75f * Time.deltaTime;
			SnowballCurrentCrown = new Vector3(
				Mathf.Lerp(SnowballStartCrown.x, SnowballArcCrown.x, SnowballSpeedCrownUp), 
				Mathf.Lerp(SnowballStartCrown.y, ArcHeightCrown, SnowballSpeedCrownUp), 
				Mathf.Lerp(SnowballStartCrown.z, SnowballArcCrown.z, SnowballSpeedCrownUp)
			);

			SnowballCrown.transform.position = SnowballCurrentCrown;
		}

		else {
			SnowballSpeedCrownDown += 0.75f * Time.deltaTime;
			SnowballCurrentCrown = new Vector3(
				Mathf.Lerp(SnowballArcCrown.x, PlayerHit.x, SnowballSpeedCrownDown), 
				Mathf.Lerp(ArcHeightCrown, PlayerHit.y, SnowballSpeedCrownDown), 
				Mathf.Lerp(SnowballArcCrown.z, PlayerHit.z, SnowballSpeedCrownDown)
			);

			SnowballCrown.transform.position = SnowballCurrentCrown;
		}
	}

// If Player Gets Hit
	public void UpdatingIfGettingHit() {
		if ((SnowballA.transform.position == PlayerHit) || (SnowballB.transform.position == PlayerHit) || (SnowballC.transform.position == PlayerHit) || (SnowballD.transform.position == PlayerHit) || (SnowballA2.transform.position == PlayerHit) || (SnowballCrown.transform.position == PlayerHit)) {
			if (DataPlayer.PlayerHiding == false) {
				SnowballA.SetActive(false);
				SnowballB.SetActive(false);
				SnowballC.SetActive(false);
				SnowballD.SetActive(false);
				SnowballA2.SetActive(false);
				SnowballCrown.SetActive(false);
				SnowballA.transform.position = SnowballStartA;
				SnowballB.transform.position = SnowballStartB;
				SnowballC.transform.position = SnowballStartC;
				SnowballD.transform.position = SnowballStartD;
				SnowballA2.transform.position = SnowballStartA2;
				SnowballCrown.transform.position = SnowballStartCrown;
				DataPlayer.PlayerLosing = true;
				PlayGameOverRun.PlayGameOver();
			}

			else {
				SnowballA.SetActive(false);
				SnowballB.SetActive(false);
				SnowballC.SetActive(false);
				SnowballD.SetActive(false);
				SnowballA2.SetActive(false);
				SnowballCrown.SetActive(false);
				PlayerHitSnowballA = true;
				PlayerHitSnowballB = true;
				PlayerHitSnowballC = true;
				PlayerHitSnowballD = true;
				PlayerHitSnowballA2 = true;
				HittingSnowballA();
				HittingSnowballB();
				HittingSnowballC();
				HittingSnowballD();
				HittingSnowballA2();
				SnowballA.transform.position = SnowballStartA;
				SnowballB.transform.position = SnowballStartB;
				SnowballC.transform.position = SnowballStartC;
				SnowballD.transform.position = SnowballStartD;
				SnowballA2.transform.position = SnowballStartA2;
				SnowballCrown.transform.position = SnowballStartCrown;
				AnimationParameterCatherine = 0;
				AnimationParameterHadrian = 0;
				AnimationParameterLouis = 0;
				AnimationParameterVictoria = 0;
				ThrowingTimeCatherine = 0.0f;
				ThrowingTimeHadrian = 0.0f;
				ThrowingTimeLouis = 0.0f;
				ThrowingTimeVictoria = 0.0f;
			}
		}
	}

// Special Abilities
	public void UseSpecialAbilityCatherine() {
		// Already In Above Portion
	}

	public void UseSpecialAbilityHadrian() {
		WallElapsedTime += Time.deltaTime;

		if (WallElapsedTime < 4.0f) {
			WallSpeedUp += 0.5f * Time.deltaTime;
			WallCurrent = new Vector3(
				Mathf.Lerp(WallStart.x, WallEnd.x, WallSpeedUp), 
				Mathf.Lerp(WallStart.y, WallEnd.y, WallSpeedUp), 
				Mathf.Lerp(WallStart.z, WallEnd.z, WallSpeedUp)
			);

			SpecialWall.transform.position = WallCurrent;
		}

		else if (WallElapsedTime >= 3.0f) {
			WallSpeedDown += 0.5f * Time.deltaTime;
			WallCurrent = new Vector3(
				Mathf.Lerp(WallEnd.x, WallStart.x, WallSpeedDown), 
				Mathf.Lerp(WallEnd.y, WallStart.y, WallSpeedDown), 
				Mathf.Lerp(WallEnd.z, WallStart.z, WallSpeedDown)
			);

			SpecialWall.transform.position = WallCurrent;
		}
	}

	public void UseSpecialAbilityLouis() {
		// Already In SceneGameplay Script
	}

	public void UseSpecialAbilityVictoria() {
		// Already In Above Portion
	}

// Rotating Snowballs
	public void RotateAllSnowballs() {
		// Snowball A
		SnowballA.transform.Rotate(new Vector3(360, 360, 360) * Time.deltaTime * 0.5f);

		// Snowball B
		SnowballB.transform.Rotate(new Vector3(-360, 360, 360) * Time.deltaTime * 0.7f);

		// Snowball C
		SnowballC.transform.Rotate(new Vector3(360, -360, 360) * Time.deltaTime * 0.3f);

		// Snowball D
		SnowballD.transform.Rotate(new Vector3(360, 360, -360) * Time.deltaTime * 0.8f);

		// Snowball A2
		SnowballA2.transform.Rotate(new Vector3(360, 360, 360) * Time.deltaTime * 0.6f);

		// Snowball Crown
		SnowballCrown.transform.Rotate(new Vector3(360, 360, 360) * Time.deltaTime * 0.3f);
	}

// Hitting Snowballs
	public void HittingSnowballA() {
		if (PlayerHitSnowballA == true) {
			SnowballA.SetActive(false);
		}

		else {
			SnowballA.SetActive(true);
		}
	}

	public void HittingSnowballB() {
		if (PlayerHitSnowballB == true) {
			SnowballB.SetActive(false);
		}

		else {
			SnowballB.SetActive(true);
		}
	}

	public void HittingSnowballC() {
		if (PlayerHitSnowballC == true) {
			SnowballC.SetActive(false);
		}

		else {
			SnowballC.SetActive(true);
		}
	}

	public void HittingSnowballD() {
		if (PlayerHitSnowballD == true) {
			SnowballD.SetActive(false);
		}

		else {
			SnowballD.SetActive(true);
		}
	}

	public void HittingSnowballA2() {
		if (PlayerHitSnowballA2 == true) {
			SnowballA2.SetActive(false);
		}

		else {
			SnowballA2.SetActive(true);
		}
	}

// Player Throwing Snowballs
	public void UpdatingPlayerSnowballs() {
		if (DataPlayer.PlayerHiding == false) {
			if (ReadyToPlay == true) {
				if (Input.GetMouseButtonDown(0)) {
					PlayerThrowRay = MainCamera.ScreenPointToRay(Input.mousePosition);
					DodgeDetermination = Random.Range(1,11);

					if (Physics.Raycast(PlayerThrowRay, out PlayerThrow)) {
						if (PlayerThrow.collider != null) {
							// SnowballA
							if (PlayerThrow.collider.gameObject.name == "SnowballA") {
								// Animate Snowball
								AudioSourceSnowballHit.Play();
								PlayerHitSnowballA = true;

								// Add To Score
								DataPlayer.PlayerScore = DataPlayer.PlayerScore + 10;
								DataPlayer.PlayerSnowballsHit = DataPlayer.PlayerSnowballsHit + 1;

								// Reset Dodge Determination
								DodgeDetermination = 0;
							}

							// SnowballB
							else if (PlayerThrow.collider.gameObject.name == "SnowballB") {
								// Animate Snowball
								AudioSourceSnowballHit.Play();
								PlayerHitSnowballB = true;

								// Add To Score
								DataPlayer.PlayerScore = DataPlayer.PlayerScore + 10;
								DataPlayer.PlayerSnowballsHit = DataPlayer.PlayerSnowballsHit + 1;

								// Reset Dodge Determination
								DodgeDetermination = 0;
							}

							// SnowballC
							else if (PlayerThrow.collider.gameObject.name == "SnowballC") {
								// Animate Snowball
								AudioSourceSnowballHit.Play();
								PlayerHitSnowballC = true;

								// Add To Score
								DataPlayer.PlayerScore = DataPlayer.PlayerScore + 10;
								DataPlayer.PlayerSnowballsHit = DataPlayer.PlayerSnowballsHit + 1;

								// Reset Dodge Determination
								DodgeDetermination = 0;
							}

							// SnowballD
							else if (PlayerThrow.collider.gameObject.name == "SnowballD") {
								// Animate Snowball
								AudioSourceSnowballHit.Play();
								PlayerHitSnowballD = true;

								// Add To Score
								DataPlayer.PlayerScore = DataPlayer.PlayerScore + 10;
								DataPlayer.PlayerSnowballsHit = DataPlayer.PlayerSnowballsHit + 1;

								// Reset Dodge Determination
								DodgeDetermination = 0;
							}

							// SnowballA2
							else if (PlayerThrow.collider.gameObject.name == "SnowballA2") {
								// Animate Snowball
								AudioSourceSnowballHit.Play();
								PlayerHitSnowballA2 = true;

								// Add To Score
								DataPlayer.PlayerScore = DataPlayer.PlayerScore + 10;
								DataPlayer.PlayerSnowballsHit = DataPlayer.PlayerSnowballsHit + 1;

								// Reset Dodge Determination
								DodgeDetermination = 0;
							}

							// Catherine
							else if (PlayerThrow.collider.gameObject.name == "Catherine") {
								if ((AnimationParameterCatherine == 0) && (DataPenguins.IsProtectingCatherine == false)) {
									// Hit Penguin
									if (DodgeDetermination < 8) {
										// Animate Penguin
										AudioSourcePenguinHitFemale.Play();
										AnimationParameterCatherine = 2;

										// Add To Score
										DataPlayer.PlayerScore = DataPlayer.PlayerScore + 30;
										DataPlayer.PlayerPenguinsHit = DataPlayer.PlayerPenguinsHit + 1;

										// Reset Dodge Determination
										DodgeDetermination = 0;
									}

									// Dodged Penguin
									else {
										// Animate Penguin
										AnimationParameterCatherine = 1;

										// Reset Dodge Determination
										DodgeDetermination = 0;
									}
								}
							}

							// Hadrian
							else if (PlayerThrow.collider.gameObject.name == "Hadrian") {
								if ((AnimationParameterHadrian == 0) && (DataPenguins.IsProtectingHadrian == false)) {
									// Hit Penguin
									if (DodgeDetermination < 8) {
										// Animate Penguin
										AudioSourcePenguinHitMale.Play();
										AnimationParameterHadrian = 2;

										// Add To Score
										DataPlayer.PlayerScore = DataPlayer.PlayerScore + 30;
										DataPlayer.PlayerPenguinsHit = DataPlayer.PlayerPenguinsHit + 1;

										// Reset Dodge Determination
										DodgeDetermination = 0;
									}

									// Dodged Penguin
									else {
										// Animate Penguin
										AnimationParameterHadrian = 1;

										// Reset Dodge Determination
										DodgeDetermination = 0;
									}
								}
							}

							// Louis
							else if (PlayerThrow.collider.gameObject.name == "Louis") {
								if ((AnimationParameterLouis == 0) && (DataPenguins.IsProtectingLouis == false)) {
									// Hit Penguin
									if (DodgeDetermination < 8) {
										// Animate Penguin
										AudioSourcePenguinHitMale.Play();
										AnimationParameterLouis = 2;

										// Add To Score
										DataPlayer.PlayerScore = DataPlayer.PlayerScore + 30;
										DataPlayer.PlayerPenguinsHit = DataPlayer.PlayerPenguinsHit + 1;

										// Reset Dodge Determination
										DodgeDetermination = 0;
									}

									// Dodged Penguin
									else {
										// Animate Penguin
										AnimationParameterLouis = 1;

										// Reset Dodge Determination
										DodgeDetermination = 0;
									}
								}
							}

							// Victoria
							else if (PlayerThrow.collider.gameObject.name == "Victoria") {
								if ((AnimationParameterVictoria == 0) && (DataPenguins.IsProtectingVictoria == false)) {
									// Hit Penguin
									if (DodgeDetermination < 8) {
										// Animate Penguin
										AudioSourcePenguinHitFemale.Play();
										AnimationParameterVictoria = 2;

										// Add To Score
										DataPlayer.PlayerScore = DataPlayer.PlayerScore + 30;
										DataPlayer.PlayerPenguinsHit = DataPlayer.PlayerPenguinsHit + 1;

										// Reset Dodge Determination
										DodgeDetermination = 0;
									}

									// Dodged Penguin
									else {
										// Animate Penguin
										AnimationParameterVictoria = 1;

										// Reset Dodge Determination
										DodgeDetermination = 0;
									}
								}
							}
						}
					}
				}
			}
		}
	}

// Camera Movements
	public void UpdatingCameraView() {
		if (SceneGameplay.AttackingOrDodging == 1) {
			if (DataPlayer.PlayerHiding == false) {
				CameraMoveSpeed += 3.0f * Time.deltaTime;
				CameraPositionCurrent = new Vector3(
					Mathf.Lerp(CameraPositionDodge.x, CameraPositionAttack.x, CameraMoveSpeed), 
					Mathf.Lerp(CameraPositionDodge.y, CameraPositionAttack.y, CameraMoveSpeed), 
					Mathf.Lerp(CameraPositionDodge.z, CameraPositionAttack.z, CameraMoveSpeed)
				);

				MainCamera.transform.position = CameraPositionCurrent;
				CheckAttackDodgeTime();
			}

			else {
				CameraMoveSpeed += 3.0f * Time.deltaTime;
				CameraPositionCurrent = new Vector3(
					Mathf.Lerp(CameraPositionAttack.x, CameraPositionDodge.x, CameraMoveSpeed), 
					Mathf.Lerp(CameraPositionAttack.y, CameraPositionDodge.y, CameraMoveSpeed), 
					Mathf.Lerp(CameraPositionAttack.z, CameraPositionDodge.z, CameraMoveSpeed)
				);

				MainCamera.transform.position = CameraPositionCurrent;
				CheckAttackDodgeTime();
			}
		}
	}

	public void CheckAttackDodgeTime() {
		if (CameraMoveSpeed >= 1.0f) {
			SceneGameplay.AttackingOrDodging = 0;
			CameraMoveSpeed = 0.0f;
		}
	}

// Score
	public void UpdatingPlayerScore() {
		ScoreText.text = "SCORE" + "\n" + DataPlayer.PlayerScore.ToString("n0");
	}

// Random Laughs
	public IEnumerator UpdatingRandomLaughs() {
		while (LaughElapsedTime < LaughFinalTime) {
			LaughElapsedTime += Time.deltaTime;
			yield return null;
		}

		LaughIsPlaying = true;
		StartCoroutine(PlayLaughing());
	}

	public IEnumerator PlayLaughing() {
		float ElapsedTime = 0.0f;

		if (RandomizedLaugh == 1) {
			AudioSourcePenguinLaughA.Play();
		}

		else {
			AudioSourcePenguinLaughB.Play();
		}

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime;
			yield return null;
		}

		if (RandomizedLaugh == 1) {
			RandomizedLaugh = 2;
		}

		else {
			RandomizedLaugh = 1;
		}

		LaughElapsedTime = 0.0f;
		LaughFinalTime = Random.Range(3.0f, 10.0f);
		LaughIsPlaying = false;
		StartCoroutine(UpdatingRandomLaughs());
	}
	
// ---------------------------------------- END: OTHER FUNCTIONS ----------------------------------------
}