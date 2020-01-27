using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotSpot : MonoBehaviour
{
	public string input;
	public ChangeText changer;

    void OnMouseUp() {
		changer.ChangeIt(input);
	}
}
