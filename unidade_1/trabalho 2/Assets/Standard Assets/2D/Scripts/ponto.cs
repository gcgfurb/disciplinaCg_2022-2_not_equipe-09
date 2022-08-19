using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ponto : MonoBehaviour
{

    int placar = 0;

    public object SceneMeneger { get; private set; }


    // Use this for initialization
    void Start()
    {
        InvokeRepeating("pontua", 1f, 1f);
    }

    void pontua()
    {
        placar += 1;
        if (placar > PlayerPrefs.GetInt("Recorde", 0))
        {
            PlayerPrefs.SetInt("Recorde", placar);
        }
    }

    public void aumentaPlacar(int pts)
    {
        placar += pts;
        if (placar > PlayerPrefs.GetInt("Recorde", 0))
        {
            PlayerPrefs.SetInt("Recorde", placar);
        }
    }

    public void diminuirPlacar(int pts)
    {
        placar -= pts;
    }

    private void OnGUI()
    {
        GUI.color = Color.black;
        GUI.Label(new Rect(10, 10, 100, 30), " Placar: " + placar);

        GUI.Label(new Rect(10, 30, 100, 30), " Recorde: " + PlayerPrefs.GetInt("Recorde", 0));
    }
    void Update()
    {

    }
}
