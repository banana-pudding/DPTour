using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveByClick : MonoBehaviour
{
	public float moveSpeed, mult, flingSpeed;
	private bool canMove = false;
	float horiz = 0f, vert = 0f, x, y;
	Quaternion camUp, contUp, camEnd, contEnd;
	public Transform container;

    void LateUpdate () {

		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began) {
				if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId) == true) {
					Debug.Log("Clicked on UI!");
					canMove = false;
				} else {
					canMove = true;
				}
			}

			if (canMove && touch.phase == TouchPhase.Moved) {
				horiz = Input.touches[0].deltaPosition.x;
				vert = Input.touches[0].deltaPosition.y;

				container.Rotate(new Vector3(0f, horiz*(-1), 0f)*Time.deltaTime*flingSpeed);
				transform.Rotate(new Vector3(vert, 0f, 0f)*Time.deltaTime*flingSpeed);
			}
		} else {
			if (Input.GetMouseButtonDown(0)) {
				if (EventSystem.current.IsPointerOverGameObject() == true) {
					Debug.Log("Clicked on UI!");
					canMove = false;
				} else {
					canMove = true;
				}
			}

			if (canMove && Input.GetMouseButton(0)) {
				horiz = Input.GetAxis("Mouse X");
				vert = Input.GetAxis("Mouse Y");

				container.Rotate(new Vector3(0f, horiz*(-1), 0f)*Time.deltaTime*moveSpeed);
				transform.Rotate(new Vector3(vert, 0f, 0f)*Time.deltaTime*moveSpeed);
			}
		}
	}
}
