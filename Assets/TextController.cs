using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {
	
	public Text text;
	
	private enum States {cell, sheets_0, sheets_1, lock_0, lock_1, mirror, cell_mirror, freedom};
	private States MyState;
	
	void Start () {
		MyState = States.cell;
	}
	
	void Update () {
		print (MyState);
		if (MyState == States.cell)
			state_cell();
		else if (MyState == States.sheets_0)
			state_sheets_0();
		else if (MyState == States.sheets_1)
			state_sheets_1();
		else if (MyState == States.lock_0)
			state_lock_0();
		else if (MyState == States.lock_1)
			state_lock_1();
		else if (MyState == States.mirror)
			state_mirror();
		else if (MyState == States.cell_mirror)
			state_cell_mirror();
		else if (MyState == States.freedom)
			state_freedom();
	}
	
	void state_cell() {
		text.text = "You are in a prison cell, and you want to escape. There are " + 
					"some dirty sheets on the bed, a mirror on the wall, and the door " +
					"is locked from the outside.\n\n" +
					"Press S to view Sheets, M to view Mirror and L to view Lock"; 
		if (Input.GetKeyDown ("s"))
			MyState = States.sheets_0;
		else if (Input.GetKeyDown ("m"))
		    MyState = States.mirror;
		else if (Input.GetKeyDown ("l"))
		    MyState = States.lock_0;
	}
	
	void state_mirror() {
		text.text = "The dirty old mirror on the wall seems loose.\n\n" + 
					"Press T to Take the mirror, or R to Return to cell";
		if (Input.GetKeyDown ("t"))
			MyState = States.cell_mirror;
		else if (Input.GetKeyDown ("r"))
			MyState = States.cell;
	}
	
	void state_sheets_0 () {
		text.text = "You can't believe you sleep in these things. Surely it's " + 
					"time somebody changed them. The pleasures of prison life " + 
					"I guess!\n\n" + 
					"Press R to Return to roaming your cell";
		if (Input.GetKeyDown ("r"))
			MyState = States.cell;	
	}
	
	void state_sheets_1 () {
		text.text = "Holding a mirror in your hand doesn't make the sheets look " + 
					"any better.\n\n" +
					"Press R to Return to roaming your cell"; 
		if (Input.GetKeyDown ("r"))
			MyState = States.cell_mirror;					
	}
	
	void state_lock_0 () {
		text.text = "This is one of those button locks. You have no idea what the " + 
					"combination is. You wish you could somehow see where the dirty " + 
					"fingerprints were, maybe that would help.\n\n" + 
					"Press R to Return to roaming your cell";
		if (Input.GetKeyDown ("r"))
		    MyState = States.cell;		
	}
	
	void state_lock_1 () {
		text.text = "You carefully put the mirror through the bars, and turn it round " + 
					"so you can see the lock. You can just make out fingerprints around " + 
					"the buttons. You press the dirty buttons, and hear a click.\n\n" + 
					"Press O to Open, or R to Return to your cell" ;
		if (Input.GetKeyDown ("o"))
			MyState = States.freedom;
		else if (Input.GetKeyDown ("r"))
		    MyState = States.cell_mirror;	
	}
	
	void state_cell_mirror () {
		text.text = "You are still in your cell, and you STILL want to escape! There are " + 
					"some dirty sheets on the bed, a mark where the mirror was, " + 
					"and that pesky door is still there, and firmly locked!\n\n" + 
					"Press S to view Sheets, or L to view Lock";
		if (Input.GetKeyDown ("s"))
			MyState = States.sheets_1;
		else if (Input.GetKeyDown ("l"))
			MyState = States.lock_1;
	}
	
	void state_freedom () {
		text.text = "You are FREE!\n\n" + 
					"Press P to Play again";
		if (Input.GetKeyDown ("p"))
			MyState = States.cell;
	}
}