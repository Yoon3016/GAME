using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transfer_Map : MonoBehaviour
{
    public string Transfer_MapName;
    private Move_Char thePlayer;
    public Cameramanaget theCamera;
    public BoxCollider2D target_bound;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<Move_Char>();
        theCamera = FindObjectOfType<Cameramanaget>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            thePlayer.current_MapName = Transfer_MapName;
            SceneManager.LoadScene(Transfer_MapName);
            theCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, theCamera.transform.position.z);
            theCamera.SetBound(target_bound);
        }
    }
}
