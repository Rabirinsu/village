
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharachterController : MonoBehaviour
{
   
     public  bool isMove;
    [SerializeField] private float MovementSpeed, lerpValue;
    private int layerMask;
    [SerializeField]
    private float RotationSpeed;
    private float touchPosition;
    [SerializeField]
    private Camera Camera;





    private void Start()
    {
      
    }
    void Update()
    {



        if (Input.touchCount > 0 && !IsSkilClicked())
        {
            if(EventSystem.current.IsPointerOverGameObject())
                return;
            var touch = Input.GetTouch(0);
            var targetVector = new Vector3(touch.deltaPosition.x, 0, touch.deltaPosition.y);

            if (touch.phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Moved) // TODO if not clicked spell
            {
                isMove = true;
                RotateFromTouch(touch);

            }
            else isMove = false;

        }

    }

    private void RotateFromTouch(Touch touch)
    {

        var touchPos = touch.position;
        touchPos = Camera.transform.localPosition;
        if (Physics.Raycast(Camera.ScreenPointToRay(touch.position), out var hit, maxDistance: 300f) && !EventSystem.current.IsPointerOverGameObject())
        {
            var target = hit.point; // TODO Chose target about moved position
            target.y = transform.position.y;
            transform.position = Vector3.MoveTowards(transform.position, Vector3.Lerp(transform.position, target, lerpValue), Time.deltaTime * MovementSpeed);
            var newMovePoint = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newMovePoint - transform.position), RotationSpeed * Time.deltaTime);
            Debug.Log("HITTED " + hit.transform.name);

        }
    }
    private bool IsSkilClicked()
    {


        if (Input.touchCount > 0 && Input.GetTouch(0).phase != TouchPhase.Moved)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                return true;
            }
        }
       
        return false;
    }
}
