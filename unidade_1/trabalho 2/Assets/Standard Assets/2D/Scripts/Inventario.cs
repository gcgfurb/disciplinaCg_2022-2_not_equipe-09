using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public GameObject inventario;
    public Transform painel;

    public GameObject inventarioAleatorio;
    public Transform painelAleatorio;
    public GameObject[] itens;

    private int qtdSlot;
    private int qtdSlotAleatorio;

    private Transform[] slots;
    private Transform[] slotsAleatorio;
    private int cont = 0;

    private ponto pontuacao;
    public GameObject branco;
    // Use this for initialization
    void Start()
    {
        qtdSlot = painel.childCount;
        qtdSlotAleatorio = painelAleatorio.childCount;
        slotsAleatorio = new Transform[qtdSlotAleatorio];
        slots = new Transform[qtdSlot];
        DetectSlot();
        DetectSlotAleatorio();
        AddItemAleatorio();
        pontuacao = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ponto>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.tag == "Item")
        {
            GameObject ItemColetado = outro.gameObject;
            if (outro.GetComponent<Item>().icone == slotsAleatorio[cont].GetComponent<Slot>().icone)
            {
                
                AddItem(ItemColetado);
                ItemColetado.transform.SetParent(this.transform);
                ItemColetado.SetActive(false);
                cont++;
                pontuacao.aumentaPlacar(5);
                
                if (cont >= 3)
                {
                    pontuacao.aumentaPlacar(10);
                    AddItemAleatorio();
                    removeItens();
                    cont = 0;
                    
                }
            }
            else
            {
                pontuacao.diminuirPlacar(5);
                ItemColetado.transform.SetParent(this.transform);
                ItemColetado.SetActive(false);
            }
            
        }

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

    public void removeItens()
    {
        for (int i = 0; i < qtdSlot; i++)
        {
            slots[i].GetComponent<Slot>().item = branco;
            slots[i].GetComponent<Slot>().ocupado = false;
            slots[i].GetComponent<Slot>().icone = null;
        }
    }

    public void removeItensAleatorios()
    {
        for (int i = 0; i < qtdSlot; i++)
        {
            slotsAleatorio[i].GetComponent<Slot>().item = branco;
            slotsAleatorio[i].GetComponent<Slot>().icone = null;
        }
    }

    public void AddItemAleatorio()
    {
        
        for (int i = 0; i < qtdSlot; i++)
        {
            GameObject item = itens[gerarIndice()];
           
            slotsAleatorio[i].GetComponent<Slot>().item = item;

            slotsAleatorio[i].GetComponent<Slot>().icone = item.GetComponent<Item>().icone;
            
        }
    }

    private void DetectSlot()
    {
        for(int i = 0; i < qtdSlot; i++)
        {
            slots[i] = painel.GetChild(i);
            
        }
    }

    private void DetectSlotAleatorio()
    {
        for (int i = 0; i < qtdSlot; i++)
        {
            slotsAleatorio[i] = painelAleatorio.GetChild(i);
        }
    }

    private int gerarIndice()
    {
        return Random.Range(0, itens.Length);
    }

    private void zerar()
    {
        
    }
}