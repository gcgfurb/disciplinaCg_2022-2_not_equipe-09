using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour {

    public int tempo_morte;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, tempo_morte);
	}
}
