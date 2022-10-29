using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramanaget : MonoBehaviour
{
    static public Cameramanaget instance;
    [SerializeField] public GameObject target;
    [SerializeField] public float moveSpeed;
    private Vector3 targetPosition;
    public BoxCollider2D bound;

    private Vector3 minbound;
    private Vector3 maxbound;
    // �ڽ� Collider�� �ּ�,�ִ� ���� ũ�� ���庯��


    private float halfWidth;
    private float halfHeight;
    // ī�޶��� �ݳ���, �ݱ��̸� ����.

    private Camera theCamera;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        theCamera = GetComponent<Camera>();
        minbound = bound.bounds.min;
        maxbound = bound.bounds.max;
        halfWidth = theCamera.orthographicSize;
        halfHeight = halfWidth * Screen.width / Screen.height;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target.gameObject!=null)
        {
            targetPosition.Set(target.transform.position.x, target.transform.position.y, transform.position.z);
            this.transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime); // 1�ʿ� moveSpeed ��ŭ �̵�

            float clampedX = Mathf.Clamp(this.transform.position.x,minbound.x+halfWidth,maxbound.x-halfWidth) ;
            float clampedY = Mathf.Clamp(this.transform.position.y, minbound.y + halfHeight, maxbound.y - halfHeight);
            this.transform.position = new Vector3(clampedX, clampedY, this.transform.position.z);
        }
    }

    public void SetBound(BoxCollider2D NewBound)
    {
        bound = NewBound;
        minbound = bound.bounds.min;
        maxbound = bound.bounds.max;
    }
}
