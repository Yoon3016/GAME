using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramanaget : MonoBehaviour
{
    [SerializeField] public GameObject target;
    [SerializeField] public float moveSpeed;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target.gameObject!=null)
        {
            targetPosition.Set(target.transform.position.x, target.transform.position.y, transform.position.z);
            this.transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime); // 1초에 moveSpeed 만큼 이동
        
        }
    }
}
