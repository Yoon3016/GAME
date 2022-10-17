using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class Move_Char : MonoBehaviour
{
    [SerializeField] float speed;
    private Vector3 vector;
    private bool key_check = true;
   [SerializeField] float run_speed;
    private float apply_run_speed=1;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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

            vector.Set(Input.GetAxisRaw("Horizontal") * speed * apply_run_speed, Input.GetAxisRaw("Vertical") * speed * apply_run_speed, transform.position.z);
            if(vector.x!=0)
            {
                vector.y = 0;
            }
            animator.SetFloat("Dir_X", vector.x);
            animator.SetFloat("Dir_Y", vector.y);
            animator.SetBool("Working", true);

            for (int i = 0; i < 10 / apply_run_speed; i++)
            {
                if (vector.x != 0)
                {
                    transform.Translate(vector.x, 0, 0);
                }
                else if (vector.y != 0)
                {
                    transform.Translate(0, vector.y, 0);

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
