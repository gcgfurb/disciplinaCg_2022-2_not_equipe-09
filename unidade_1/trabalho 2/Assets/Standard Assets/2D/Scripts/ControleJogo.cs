using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleJogo : MonoBehaviour {

    public float velocidadePersonagem ;
    [Header("Limite de movimento")]
    public float limiteMinimoY;
    public float limiteMaximoY;
    
       
    
    // Use this for initialization
    void Start () {
        velocidadePersonagem = 10;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
