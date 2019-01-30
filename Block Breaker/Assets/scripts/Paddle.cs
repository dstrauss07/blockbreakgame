using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float screenwidth=16f;
    [SerializeField] float minXpos = 1f;
    [SerializeField] float maxXpos = 15f;

    //cached references
    GameStatus theGameStatus;
    Ball theBall;

    private void Start()
    {
        theGameStatus = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<Ball>();
    }


    // Update is called once per frame
    void Update () {
      // Debug.Log(Input.mousePosition.x / Screen.width * screenwidth);
        Vector2 paddlePos = new Vector2(transform.position.y, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minXpos, maxXpos);
        transform.position = paddlePos;
	}

    private float GetXPos()
    {
        if (theGameStatus.IsAutoPlayEnabled())
        {
            Debug.Log("AutoPlayIs Enabled");
            return theBall.transform.position.x;
        }
        else
        {
            Debug.Log("AutoPlayIs not Enabled");
            return Input.mousePosition.x / Screen.width * screenwidth;
        }
    }
}
