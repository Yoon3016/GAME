using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public string startPoint;
    private Move_Char thePlayer;
    private Cameramanaget theCamera;
    // Start is called before the first frame update
    void Start()
    {
        theCamera = FindObjectOfType<Cameramanaget>();
        thePlayer = FindObjectOfType<Move_Char>();
    if(startPoint==thePlayer.current_MapName)
        {
            theCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, theCamera.transform.position.z);
            thePlayer.transform.position = this.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
