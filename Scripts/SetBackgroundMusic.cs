using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SetBackgroundMusic : MonoBehaviour {
		
// ---------------------------------------- START: LIST OF VARIABLES ----------------------------------------
// --------------- PUBLIC VARIABLES ---------------
	public SetBackgroundMusic Instance {
		get {
			return MusicInstance;
		}
	}
	
// --------------- PRIVATE VARIABLES ---------------
	SetBackgroundMusic MusicInstance = null;
	
// --------------- STATIC VARIABLES ---------------
	
	
// ---------------------------------------- END: LIST OF VARIABLES ----------------------------------------
// ---------------------------------------- START: CALLING OTHER SCRIPTS ----------------------------------------
	
	
// ---------------------------------------- END: CALLING OTHER SCRIPTS ----------------------------------------
// ---------------------------------------- START: INITIAL FUNCTIONS ----------------------------------------
// --------------- START FUNCTION ---------------
	void Start() {
		
	}
	
// --------------- AWAKE FUNCTION ---------------
	void Awake() {
		if ((MusicInstance != null) && (MusicInstance != this)) {
			Destroy(this.gameObject);
			return;
		}

		else {
			MusicInstance = this;
		}

		DontDestroyOnLoad(this.gameObject);
		AudioListener.volume = 1;
	}
	
// --------------- UPDATE FUNCTION ---------------
	void Update() {
		
	}
	
// ---------------------------------------- END: INITIAL FUNCTIONS ----------------------------------------
// ---------------------------------------- START: OTHER FUNCTIONS ----------------------------------------
    
	
// ---------------------------------------- END: OTHER FUNCTIONS ----------------------------------------
}