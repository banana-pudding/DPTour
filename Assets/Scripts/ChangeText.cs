using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class ChangeText : MonoBehaviour
{
    public GameObject textholder;
	public string startingText;
	Text infoText;

	void Start () {
		infoText = textholder.GetComponent<Text>();
		ChangeIt(startingText);
	}

	public void ChangeIt (string filename) {
		string path = "Assets/Text/" + filename;
		StreamReader reader = new StreamReader(path);
		infoText.text = "\n" + reader.ReadToEnd();
        reader.Close();
	}
}
