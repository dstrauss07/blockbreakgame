using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float screenwidth=16f;
    [SerializeField] float minXpos = 1f;
    [SerializeField] float maxXpos = 15f;

    // Update is called once per frame
    void Update () {
      // Debug.Log(Input.mousePosition.x / Screen.width * screenwidth);
       float mouseXpos = Input.mousePosition.x / Screen.width * screenwidth;
        Vector2 paddlePos = new Vector2(transform.position.y, transform.position.y);
        paddlePos.x = Mathf.Clamp(mouseXpos, minXpos, maxXpos);
        transform.position = paddlePos;
	}
}
