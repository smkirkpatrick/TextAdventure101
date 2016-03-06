using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	
	private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom};
	private States myState;
	
	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		switch (myState) {
		case States.cell:
			state_cell ();
			break;
		case States.sheets_0:
			state_sheets_0 ();
			break;
		case States.mirror:
			state_mirror ();
			break;
		case States.lock_0:
			state_lock_0 ();
			break;
		case States.cell_mirror:
			state_cell_mirror ();
			break;
		case States.sheets_1:
			state_sheets_1 ();
			break;
		case States.lock_1:
			state_lock_1 ();
			break;
		case States.freedom:
			state_freedom ();
			break;
		};
	}
	
	void state_cell () {
		text.text = "You are in a prison cell, and you want to escape. There are " +
					"some dirty sheets on the bed, a mirror on the wall, and the door " +
					"is locked from the outside.\n\n" +
					"Press S to view the Sheets\n" +
					"Press M to view the Mirror\n" +
					"Press L to view the Lock";
		if (Input.GetKeyDown (KeyCode.S) ) {
			myState = States.sheets_0;
		} else if (Input.GetKeyDown (KeyCode.M) ) {
			myState = States.mirror;
		} else if (Input.GetKeyDown (KeyCode.L) ) {
			myState = States.lock_0;
		}
	}
	
	void state_sheets_0 () {
		text.text = "You can't believe you sleep in these things. Surely it's " +
					"time somebody changed them. The pleasures of prison life " +
					"I guess!\n\n" +
					"Press R to continue Roaming your cell";
		if (Input.GetKeyDown (KeyCode.R) ) {
			myState = States.cell;
		}
	}
	
	void state_mirror () {
		text.text = "You look at yourself in the mirror and no longer recognize " +
					"the person gazing back at you. You notice a broken section " +
					"in the lower right corner.\n\n" +
					"Press T to Take the broken shard\n" +
					"Press R to continue Roaming your cell";
		if (Input.GetKeyDown (KeyCode.T) ) {
			myState = States.cell_mirror;
		} else if (Input.GetKeyDown (KeyCode.R) ) {
			myState = States.cell;
		}
	}
	
	void state_lock_0 () {
		text.text = "You examine the lock to your cell. An electronic pad for " +
					"inputting the 3-digit lock code. Perhaps you could figure " +
					"out the code if you could see which numbers appear to have " +
					"been used most frequently.\n\n" +
					"Press R to continue Roaming your cell";
		if (Input.GetKeyDown (KeyCode.R) ) {
			myState = States.cell;
		}
	}
	
	void state_cell_mirror () {
		text.text = "You continue to pace the perimeter of your cell, carefully " +
					"fidgeting with the broken mirror shard. You can see only a " +
					"small section of your face in the reflection of the smaller " +
					"surface.\n\n" +
					"Press S to view the Sheets\n" +
					"Press L to view the Lock";
		if (Input.GetKeyDown (KeyCode.S) ) {
			myState = States.sheets_1;
		} else if (Input.GetKeyDown (KeyCode.L) ) {
			myState = States.lock_1;
		}
	}
	
	void state_sheets_1 () {
		text.text = "You cringe at the thought of another night in the cold with " +
					"only those horrid-smelling sheets to provide some small " +
					"protection against the winter night.\n\n" +
					"Press R to continue Roaming your cell";
		if (Input.GetKeyDown (KeyCode.R) ) {
			myState = States.cell_mirror;
		}
	}
	
	void state_lock_1 () {
		text.text = "You take yet another look at the lock. You reach through the " +
					"bars and turn the mirror to face the keypad. You can see which " +
					"numbers appear to be used most often.\n\n" +
					"Press R to continue Roaming your cell\n" +
					"Press P to try Pick the lock code";
		if (Input.GetKeyDown (KeyCode.R) ) {
			myState = States.cell_mirror;
		} else if (Input.GetKeyDown (KeyCode.P) ) {
			myState = States.freedom;
		}
	}
	
	void state_freedom () {
		text.text = "You made it out!\n\n" +
					"Press the Spacebar to start over.";
		if (Input.GetKeyDown (KeyCode.Space) ) {
			myState = States.cell;
		}
	}
}
