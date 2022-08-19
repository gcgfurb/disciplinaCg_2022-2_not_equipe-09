using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour {

    private bool mouse;
    public bool ocupado;
    public GameObject item;
    public Texture icone;

	// Use this for initialization
	void Start () {
        mouse = false;
        ocupado = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (item)
        {
            ocupado = true;
            this.GetComponent<RawImage>().texture = item.GetComponent<Item>().icone;
        }
	}
    public void OnPointerEnter(PointerEventData e)
    {
        mouse = true;
    }
    public void OnPointerExit(PointerEventData e)
    {
        mouse = false;
    }
}
