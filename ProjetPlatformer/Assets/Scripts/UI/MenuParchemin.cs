using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuParchemin : MonoBehaviour
{

    public GameObject parcheminManager;

    void Start()
    {
        parcheminManager.SetActive(false);
      //  GetComponent<Button>().onClick.Invoke();
    }

  
    void Update()
    {
  
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                   GetBig();
                   Debug.Log("Aller");
                }
            }
        }
    
        
        void GetBig()
        {
        transform.DOScale(5,2);
        transform.DOMove(new Vector3(0,0,0),5);
        
        
        }
        }
    
}

    

