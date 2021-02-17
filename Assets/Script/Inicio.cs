using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inicio : MonoBehaviour
{
    public string cenaInicial;
    public float tempofixoSeg = 5;
    public enum TipoCarregamento { Carregamento, TempoFixo}; //barra de seleção

    public TipoCarregamento TipoDeCarregamento;

    public Text textContagem;
    private int contagem;
    private string textoOriginal; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
