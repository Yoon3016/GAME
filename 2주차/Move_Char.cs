using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class Move_Char : MonoBehaviour
{
    static public Move_Char instance;

    public string current_MapName;
    BoxCollider2D boxCollider2D;
    public LayerMask layerMask;
    [SerializeField] float speed;
    private Vector3 vector;
    private bool key_check = true;
   [SerializeField] float run_speed;
    private float apply_run_speed=1;
    [SerializeField] private int WalkCount=10;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            boxCollider2D = GetComponent<BoxCollider2D>();
            animator = GetComponent<Animator>();
            instance= this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    IEnumerator Move_Action()
    {
        while (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                apply_run_speed = run_speed;
            }
            else
            {
                apply_run_speed = 1;
            }

            vector.Set(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed, transform.position.z);
            if(vector.x!=0)
            {
                vector.y = 0;
            }
            animator.SetFloat("Dir_X", vector.x);
            animator.SetFloat("Dir_Y", vector.y);
            RaycastHit2D hit;
            Vector2 start=new Vector2(transform.position.x,transform.position.y);
            Vector2 end=start+ new Vector2(vector.x*speed*WalkCount/2, vector.y*speed*WalkCount/2);
            boxCollider2D.enabled = false;
            hit = Physics2D.Linecast(start, end, layerMask);
            boxCollider2D.enabled = true;

            if (hit.transform != null)
            {
               // Debug.Log("No!!");
                break;
            }
            animator.SetBool("Working", true);

            for (int i = 0; i < WalkCount / apply_run_speed; i++)
            {
                if (vector.x != 0)
                {
                    transform.Translate(vector.x * apply_run_speed, 0, 0);
                }
                else if (vector.y != 0)
                {
                    transform.Translate(0, vector.y * apply_run_speed, 0);

                }
                yield return new WaitForSeconds(0.01f);

            }
           
        }
        animator.SetBool("Working", false);

        key_check = true; 
    }
    // Update is called once per frame
    void Update()
    {
        if (key_check)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                key_check = false;

                StartCoroutine(Move_Action());

            }
        }
    }
}
