using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transfer_In_Scenes : MonoBehaviour
{
    public string Transfer_MapName;
    private Move_Char thePlayer;
    public Cameramanaget theCamera;
    public Transform target;
    public BoxCollider2D target_bound;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<Move_Char>();
        theCamera = FindObjectOfType<Cameramanaget>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            thePlayer.current_MapName = Transfer_MapName;
            theCamera.transform.position = new Vector3(target.position.x, target.position.y, theCamera.transform.position.z);
            thePlayer.transform.position = target.transform.position;
            theCamera.SetBound(target_bound);
        }
    }
}
