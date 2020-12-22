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
    void Awake()
    {
        
        copy = Instantiate(component);
        RectTransform copyTransform = copy.GetComponent<RectTransform>();
        copyTransform.SetParent(textTransform);
        copyTransform.anchorMin = new Vector2(1,0.5f);
    }

   
    void Start()
    {
        textTransform = component.GetComponent<RectTransform>();
        width = component.preferredWidth;
        pos = textTransform.position;

        scrollPos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        textTransform.position = new Vector3(-scrollPos % width,pos.y,pos.z);
        scrollPos += speed * Time.deltaTime;
    }
}
