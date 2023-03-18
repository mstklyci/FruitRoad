using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Line : MonoBehaviour , IPointerDownHandler, IPointerUpHandler 
{
    GameObject LineGo;

    bool StartDrawing;

    Vector3 MousePos;
        
    LineRenderer LR;

    [SerializeField]
    Material LineMat;

    int CurrentIndex;

    [SerializeField]
    Camera cam;

    [SerializeField]
    Transform Collider_Prefab;

    Transform LastInstantiated_Collider;
    public void OnPointerDown(PointerEventData eventData)
    {
        StartDrawing = true;
        MousePos = Input.mousePosition;

        LR = LineGo.AddComponent<LineRenderer>();

        LR.startWidth = 0.2f;

        LR.material = LineMat;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        StartDrawing = false;
        LR.useWorldSpace = false;

        if (LastInstantiated_Collider != null)
        {
            Destroy(LastInstantiated_Collider.gameObject);
        }

        Start();

        CurrentIndex = 0;
    }
    void Start()
    {
        LineGo = new GameObject();
    }
    void Update()
    {
        if (StartDrawing)
        {
            Vector3 Dist = MousePos - Input.mousePosition;

            float Distance_SqrMag = Dist.sqrMagnitude;

            if (Dist.sqrMagnitude > 10f)
            {
                LR.SetPosition(CurrentIndex, cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 29f)));

                if (LastInstantiated_Collider != null)
                {
                    Vector3 CurrentLinePos = LR.GetPosition(CurrentIndex);

                    LastInstantiated_Collider.LookAt(CurrentLinePos);

                    LastInstantiated_Collider.localScale = new Vector3(LastInstantiated_Collider.localScale.x, LastInstantiated_Collider.localScale.y, Vector3.Distance(LastInstantiated_Collider.position, CurrentLinePos) * 0.9f);
                }
                LastInstantiated_Collider = Instantiate(Collider_Prefab,LR.GetPosition(CurrentIndex),Quaternion.identity,LineGo.transform);

                MousePos = Input.mousePosition;

                CurrentIndex++;

                LR.positionCount = CurrentIndex + 1;

                LR.SetPosition(CurrentIndex, cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 29f)));

            }
        }
    }
}
