using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class colourSwitcher : MonoBehaviour {

	public static colourSwitcher instance;
	public GameObject[] carParts;
	private GameObject currentTracked;

	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}

 	public void colours(string newcol){
		currentTracked = getCurrentTracked ();
		Debug.Log (currentTracked.name);
		switch (newcol) {
		case "red":
			for (int i = 0; i < carParts.Length; i++) {
				GameObject.Find(currentTracked.name+"/activeItems/" + gameController.currentSelectCar).GetComponent<colourSwitcher>().carParts[i].GetComponent<Renderer> ().materials[0].color = Color.red;
  			}
 			break;
		case "green":
			for (int i = 0; i < carParts.Length; i++) {
				GameObject.Find(currentTracked.name+"/activeItems/" + gameController.currentSelectCar).GetComponent<colourSwitcher>().carParts[i].GetComponent<Renderer> ().materials[0].color = Color.green;
			}
			break;
		case "black":
			for (int i = 0; i < carParts.Length; i++) {
				GameObject.Find(currentTracked.name+"/activeItems/" + gameController.currentSelectCar).GetComponent<colourSwitcher>().carParts[i].GetComponent<Renderer> ().materials[0].color = Color.black;
			}
			break;
		case "blue":
			for (int i = 0; i < carParts.Length; i++) {
				GameObject.Find(currentTracked.name+"/activeItems/" + gameController.currentSelectCar).GetComponent<colourSwitcher>().carParts[i].GetComponent<Renderer> ().materials[0].color = Color.blue;
			}
			break;
		case "magenta":
			for (int i = 0; i < carParts.Length; i++) {
				GameObject.Find(currentTracked.name+"/activeItems/" + gameController.currentSelectCar).GetComponent<colourSwitcher>().carParts[i].GetComponent<Renderer> ().materials[0].color = Color.magenta;
			}
			break;
		case "white":
			for (int i = 0; i < carParts.Length; i++) {
				GameObject.Find(currentTracked.name+"/activeItems/" + gameController.currentSelectCar).GetComponent<colourSwitcher>().carParts[i].GetComponent<Renderer> ().materials[0].color = Color.white;
			}
			break;
		case "grey":
			for (int i = 0; i < carParts.Length; i++) {
				GameObject.Find(currentTracked.name+"/activeItems/" + gameController.currentSelectCar).GetComponent<colourSwitcher>().carParts[i].GetComponent<Renderer> ().materials[0].color = Color.grey;
			}
			break;
		case "yellow":
			for (int i = 0; i < carParts.Length; i++) {
				GameObject.Find(currentTracked.name+"/activeItems/" + gameController.currentSelectCar).GetComponent<colourSwitcher>().carParts[i].GetComponent<Renderer> ().materials[0].color = Color.yellow;
			}
			break;
		default:
			break;
		}

	}

	public GameObject getCurrentTracked(){
		// Get the Vuforia StateManager
		StateManager sm = TrackerManager.Instance.GetStateManager ();

		// Query the StateManager to retrieve the list of
		// currently 'active' trackables 
		//(i.e. the ones currently being tracked by Vuforia)
		IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours ();

		// Iterate through the list of active trackables
		//Debug.Log ("List of trackables currently active (tracked): ");
		foreach (TrackableBehaviour tb in activeTrackables) {
			currentTracked = tb.gameObject;
		}
		return currentTracked;
	}

}
