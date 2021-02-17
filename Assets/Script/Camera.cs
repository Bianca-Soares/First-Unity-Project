using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    //a camera se movimenta com referência ao Heroi
    [SerializeField]public GameObject carro;//preencher essa referencia com o próprio heroi na interface
    //distância é um vetor de 3 posições
    private Vector3 distancia;
    void Start()
    {
        //usar referencia heroi e subtrair pela posi da camera
        distancia = transform.position - carro.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()//quando se traballha com a câmera
    {
        
        transform.position = carro.transform.position + distancia;//somar posição atual mais a distância
    }
}
