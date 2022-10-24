using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transfer_Map : MonoBehaviour
{
    public string Transfer_MapName;
    private Move_Char thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<Move_Char>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            thePlayer.current_MapName = Transfer_MapName;
            SceneManager.LoadScene(Transfer_MapName);
        }
    }
}
