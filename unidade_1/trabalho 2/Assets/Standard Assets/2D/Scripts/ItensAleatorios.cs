using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensAleatorios : MonoBehaviour {

    public GameObject inventario;
    public Transform painel;
    public GameObject[] itens;

    private int qtdSlot;
    private Transform[] slots;

    // Use this for initialization
    void Start()
    {
        qtdSlot = painel.childCount;
        slots = new Transform[qtdSlot];
        DetectSlot();
    }

    // Update is called once per frame
    void Update()
    {   
        AddItem(itens[gerarIndice()]);
    }

    public void AddItem(GameObject item)
    {
        for (int i = 0; i < qtdSlot; i++)
        {
            if (!slots[i].GetComponent<Slot>().ocupado)
            {
                slots[i].GetComponent<Slot>().item = item;

                slots[i].GetComponent<Slot>().icone = item.GetComponent<Item>().icone;
                break;
            }
        }
    }

    private void DetectSlot()
    {
        for (int i = 0; i < qtdSlot; i++)
        {
            slots[i] = painel.GetChild(i);
            
        }
    }

    private int gerarIndice()
    {
        return Random.Range(0, itens.Length);
    }

    private void zerar()
    {
        for (int i = 0; i < qtdSlot; i++)
        {
            
            slots[i].GetComponent<Slot>().item = null;

            break;
            
        }
    }

    public GameObject getItem()
    {
        return slots[0].GetComponent<Slot>().item;
    }

}
