using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{

    // ref-> referência do componete para movimentar o heroi
    private Rigidbody refRigidbody;
    //as coordenadas para a movimentação são valores flutuantes
    //valor para coordenada de z
    private float eixoVertical;
    //valor para coordenada de x
    private float eixoHorizontal;
    [SerializeField] public float velocidade;
    void Start()
    {
        refRigidbody = GetComponent<Rigidbody>();//a ref recebeu o rigidbody do heroi
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //quardar informação das teclas
        eixoHorizontal = Input.GetAxis("Horizontal");
        eixoVertical = Input.GetAxis("Vertical");

        //criar objeto Vector3 com os valores dos inputs
        Vector3 vetor = new Vector3(eixoHorizontal, 0.0f, eixoVertical);

        //adicionar força para o movimento
        refRigidbody.AddForce(vetor * 10);//mais velocidade 
    }
}
