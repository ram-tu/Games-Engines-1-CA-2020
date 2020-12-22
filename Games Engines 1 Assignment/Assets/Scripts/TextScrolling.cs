using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextScrolling : MonoBehaviour
{
    public TextMeshProUGUI component;
    public float speed;

    private TextMeshProUGUI copy;
    private string copyText;
    private string tempText;

    private RectTransform textTransform;

    private float width;
    private Vector3 pos;

    private float scrollPos;
    
    // Start is called before the first frame update
  
        
        //copy = Instantiate(component);
        //RectTransform copyTransform = copy.GetComponent<RectTransform>();
        //copyTransform.SetParent(textTransform);
        //copyTransform.anchorMin = new Vector2(1,0.5f);
    

   
    void Start()
    {
        textTransform = component.GetComponent<RectTransform>();
        width = component.preferredWidth;
        pos = textTransform.position;

        scrollPos = 0;
       // copy = Instantiate(component);
        //Destroy(copy.GetComponent<TextScrolling>());
        //RectTransform copyTransform = copy.GetComponent<RectTransform>();
        //copyTransform.SetParent(textTransform);
        //copyTransform.position = new Vector3(textTransform.position.x - 20,textTransform.position.y,textTransform.position.z);
        //copyTransform.anchorMin = new Vector2(1,0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(-scrollPos % width);
        textTransform.position = new Vector3(-scrollPos,pos.y,pos.z);
        if (-scrollPos % width < -240)
        {
            scrollPos = -80;
        }
        scrollPos += speed * Time.deltaTime;
    }
}
