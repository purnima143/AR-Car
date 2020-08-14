using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;

//Custom 8
public partial class Wit3D : MonoBehaviour {

	public Text myHandleTextBox;
	private bool actionFound = false;

	void Handle (string jsonString) {
		
		if (jsonString != null) {

			RootObject theAction = new RootObject ();
			Newtonsoft.Json.JsonConvert.PopulateObject (jsonString, theAction);

			if (theAction.entities.open != null) {
				foreach (Open aPart in theAction.entities.open) {
					Debug.Log (aPart.value);
					carController.instance.triggerAnimation("DriversDoor");
					myHandleTextBox.text = aPart.value;
					actionFound = true;
				}
			}
			if (theAction.entities.close != null) {
				foreach (Close aPart in theAction.entities.close) {
					Debug.Log (aPart.value);
					carController.instance.triggerAnimation("closeDriversDoor");
					myHandleTextBox.text = aPart.value;
					actionFound = true;
				}
			}

			if (theAction.entities.start != null) {
				foreach (Start aPart in theAction.entities.start) {
					Debug.Log (aPart.value);
					carController.instance.playSound();
					myHandleTextBox.text = aPart.value;
					actionFound = true;
				}
			}
						if (theAction.entities.stop != null) {
				foreach (Stop aPart in theAction.entities.stop) {
					Debug.Log (aPart.value);
					carController.instance.stopSound();
					myHandleTextBox.text = aPart.value;
					actionFound = true;
				}
			}
						if (theAction.entities.colour != null) {
				foreach (Colour aPart in theAction.entities.colour) {
					Debug.Log (aPart.value);
					colourSwitcher.instance.colours(aPart.value);
					myHandleTextBox.text = aPart.value;
					actionFound = true;
				}
			}

			if (!actionFound) {
				myHandleTextBox.text = "Request unknown, please ask a different way.";
			} else {
				actionFound = false;
			}

 		}//END OF IF

 	}//END OF HANDLE VOID

}//END OF CLASS
	

//Custom 9
public class Open {
	public bool suggested { get; set; }
	public double confidence { get; set; }
	public string value { get; set; }
	public string type { get; set; }
}

public class Close {
	public bool suggested { get; set; }
	public double confidence { get; set; }
	public string value { get; set; }
	public string type { get; set; }
}
public class Start {
	public bool suggested { get; set; }
	public double confidence { get; set; }
	public string value { get; set; }
	public string type { get; set; }
}
public class Stop {
	public bool suggested { get; set; }
	public double confidence { get; set; }
	public string value { get; set; }
	public string type { get; set; }
}
public class Colour {
	public bool suggested { get; set; }
	public double confidence { get; set; }
	public string value { get; set; }
	public string type { get; set; }
}



public class Entities {
	public List<Open> open { get; set; }
	public List<Close> close { get; set; }
		public List<Start> start { get; set; }
		public List<Stop> stop { get; set; }
		public List<Colour> colour { get; set; }


}

public class RootObject {
	public string _text { get; set; }
	public Entities entities { get; set; }
	public string msg_id { get; set; }
}