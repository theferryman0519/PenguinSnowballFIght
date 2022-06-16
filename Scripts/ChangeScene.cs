using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
		
// ---------------------------------------- START: LIST OF VARIABLES ----------------------------------------
// --------------- PUBLIC VARIABLES ---------------
	
	
// --------------- PRIVATE VARIABLES ---------------
	
	
// --------------- STATIC VARIABLES ---------------
	public static string Scene01 = "01TitleScreen";
	public static string Scene02 = "02Tutorial";
	public static string Scene03 = "03MainGamePlay";
	public static string Scene04 = "04GameOver";
	public static string Scene05 = "05ShareStats";
	
// ---------------------------------------- END: LIST OF VARIABLES ----------------------------------------
// ---------------------------------------- START: CALLING OTHER SCRIPTS ----------------------------------------
	
	
// ---------------------------------------- END: CALLING OTHER SCRIPTS ----------------------------------------
// ---------------------------------------- START: INITIAL FUNCTIONS ----------------------------------------
// --------------- START FUNCTION ---------------
	void Start() {
		
	}
	
// --------------- AWAKE FUNCTION ---------------
	void Awake() {
		
	}
	
// --------------- UPDATE FUNCTION ---------------
	void Update() {
		
	}
	
// ---------------------------------------- END: INITIAL FUNCTIONS ----------------------------------------
// ---------------------------------------- START: OTHER FUNCTIONS ----------------------------------------
	// Title Screen Scene
    public void Scene01Load() {
        SceneManager.LoadScene(Scene01);
    }

	// Tutorial Scene
    public void Scene02Load() {
        SceneManager.LoadScene(Scene02);
    }

	// Main Gameplay Scene
    public void Scene03Load() {
        SceneManager.LoadScene(Scene03);
    }

	// Game Over Scene
    public void Scene04Load() {
        SceneManager.LoadScene(Scene04);
    }

	// Share Stats Scene
    public void Scene05Load() {
        SceneManager.LoadScene(Scene05);
    }
	
// ---------------------------------------- END: OTHER FUNCTIONS ----------------------------------------
}