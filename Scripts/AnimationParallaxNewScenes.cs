using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AnimationParallaxNewScenes : MonoBehaviour {
		
// ---------------------------------------- START: LIST OF VARIABLES ----------------------------------------
// --------------- PUBLIC VARIABLES ---------------
	public float SkyLengthA;
	public float SkyLengthB;
	public float SkyLengthC;
	public float SkyLengthD;
	public float SkyLengthE;
	public float SkyStartingPositionA;
	public float SkyStartingPositionB;
	public float SkyStartingPositionC;
	public float SkyStartingPositionD;
	public float SkyStartingPositionE;
	public Vector3 SkyUpdatedPositionA;
	public Vector3 SkyUpdatedPositionB;
	public Vector3 SkyUpdatedPositionC;
	public Vector3 SkyUpdatedPositionD;
	public Vector3 SkyUpdatedPositionE;
	public float SkyParallaxA;
	public float SkyParallaxB;
	public float SkyParallaxC;
	public float SkyParallaxD;
	public float SkyParallaxE;
	public GameObject MainCamera;
	public GameObject SkyA;
	public GameObject SkyB;
	public GameObject SkyC;
	public GameObject SkyD;
	public GameObject SkyE;
	public Renderer SkyRendererA;
	public Renderer SkyRendererB;
	public Renderer SkyRendererC;
	public Renderer SkyRendererD;
	public Renderer SkyRendererE;
	public float AddedXDistanceA;
	public float AddedXDistanceB;
	public float AddedXDistanceC;
	public float AddedXDistanceD;
	public float AddedXDistanceE;
	
// --------------- PRIVATE VARIABLES ---------------
	
	
// --------------- STATIC VARIABLES ---------------
	
	
// ---------------------------------------- END: LIST OF VARIABLES ----------------------------------------
// ---------------------------------------- START: CALLING OTHER SCRIPTS ----------------------------------------
	
	
// ---------------------------------------- END: CALLING OTHER SCRIPTS ----------------------------------------
// ---------------------------------------- START: INITIAL FUNCTIONS ----------------------------------------
// --------------- START FUNCTION ---------------
	void Start() {
		SkyStartingPositionA = AnimationParallax.NewSceneStartingPositionA;
		SkyStartingPositionB = AnimationParallax.NewSceneStartingPositionB;
		SkyStartingPositionC = AnimationParallax.NewSceneStartingPositionC;
		SkyStartingPositionD = AnimationParallax.NewSceneStartingPositionD;
		SkyStartingPositionE = AnimationParallax.NewSceneStartingPositionE;
		SkyLengthA = SkyRendererA.bounds.size.x;
		SkyLengthB = SkyRendererB.bounds.size.x;
		SkyLengthC = SkyRendererC.bounds.size.x;
		SkyLengthD = SkyRendererD.bounds.size.x;
		SkyLengthE = SkyRendererE.bounds.size.x;
		SkyParallaxA = 0.1f;
		SkyParallaxB = 0.3f;
		SkyParallaxC = 0.5f;
		SkyParallaxD = 0.7f;
		SkyParallaxE = 1.0f;
	}
	
// --------------- AWAKE FUNCTION ---------------
	void Awake() {
		
	}
	
// --------------- UPDATE FUNCTION ---------------
	void Update() {
		AddedXDistanceA += Time.deltaTime * SkyParallaxA * 10.0f;
		AddedXDistanceB += Time.deltaTime * SkyParallaxB * 10.0f;
		AddedXDistanceC += Time.deltaTime * SkyParallaxC * 10.0f;
		AddedXDistanceD += Time.deltaTime * SkyParallaxD * 10.0f;
		AddedXDistanceE += Time.deltaTime * SkyParallaxE * 10.0f;
		
		SkyUpdatedPositionA = new Vector3(AddedXDistanceA + SkyStartingPositionA, SkyA.transform.position.y, SkyA.transform.position.z);
		SkyUpdatedPositionB = new Vector3(AddedXDistanceB + SkyStartingPositionB, SkyB.transform.position.y, SkyB.transform.position.z);
		SkyUpdatedPositionC = new Vector3(AddedXDistanceC + SkyStartingPositionC, SkyC.transform.position.y, SkyC.transform.position.z);
		SkyUpdatedPositionD = new Vector3(AddedXDistanceD + SkyStartingPositionD, SkyD.transform.position.y, SkyD.transform.position.z);
		SkyUpdatedPositionE = new Vector3(AddedXDistanceE + SkyStartingPositionE, SkyE.transform.position.y, SkyE.transform.position.z);

		SkyA.transform.position = SkyUpdatedPositionA;
		SkyB.transform.position = SkyUpdatedPositionB;
		SkyC.transform.position = SkyUpdatedPositionC;
		SkyD.transform.position = SkyUpdatedPositionD;
		SkyE.transform.position = SkyUpdatedPositionE;

		if (SkyA.transform.position.x > 475.0f) {
			SkyStartingPositionA = -125.0f;
			AddedXDistanceA = 0.0f;
		}

		if (AddedXDistanceB > 475.0f) {
			SkyStartingPositionB = -125.0f;
			AddedXDistanceB = 0.0f;
		}

		if (AddedXDistanceC > 475.0f) {
			SkyStartingPositionC = -125.0f;
			AddedXDistanceC = 0.0f;
		}

		if (AddedXDistanceD > 475.0f) {
			SkyStartingPositionD = -125.0f;
			AddedXDistanceD = 0.0f;
		}

		if (AddedXDistanceE > 475.0f) {
			SkyStartingPositionE = -125.0f;
			AddedXDistanceE = 0.0f;
		}
	}
	
// ---------------------------------------- END: INITIAL FUNCTIONS ----------------------------------------
// ---------------------------------------- START: OTHER FUNCTIONS ----------------------------------------
    
	
// ---------------------------------------- END: OTHER FUNCTIONS ----------------------------------------
}