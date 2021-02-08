using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Force : MonoBehaviour
{

    // ref-> referência do componete para movimentar o heroi
    private Rigidbody refRigidbody;
    //as coordenadas para a movimentação são valores flutuantes
    //valor para coordenada de z
    private float eixoVertical;
    //valor para coordenada de x
    private float eixoHorizontal;
    [SerializeField] public float velocidade = .0f;
    private string mensagem;
    private string msg;
    private int vida = 5;
    private int bonus = 0;
    Vector3 posiInicial;
    [SerializeField] public Text info;
  
    void Start()
    {
        refRigidbody = GetComponent<Rigidbody>();//a ref recebeu o rigidbody do heroi

        posiInicial = transform.position;//Editar para posição inicial
        mensagem = "Início";

        info.text = mensagem;
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
        refRigidbody.AddForce(vetor * velocidade);//mais velocidade 

        msg = "\n Vidas: " + vida.ToString() + "\n Bonus: " + bonus.ToString();
         
        info.text = mensagem + msg;

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Vida"))
        {
            mensagem = "Ganhou Vida";
            other.gameObject.SetActive(false);
            
            vida++;
        }

        if (other.gameObject.CompareTag("Bonus"))
        {
            mensagem = "Ganhou Bônus";
            other.gameObject.SetActive(false);
            bonus = bonus + 10;
        }
        
    }


    private void OnCollisionEnter(Collision collision) {
        
        if (collision.gameObject.CompareTag("Star"))
        {
            inicio();
            mensagem = "Perdeu Vida";

            vida--;
            
            
            if (vida <= 0)
            {
                mensagem = "Fim de Jogo";
                msg = "\nVidas: " + vida.ToString() + "\nBonus: " + bonus.ToString();
                info.text = mensagem + msg;
                this.gameObject.SetActive(false);
                
            }
        }

    }

    private void inicio()
    {

        posiInicial.x = 0.0f;
        posiInicial.y = 0.0f;
        posiInicial.z = 0.0f;

        transform.position = posiInicial;
    }

}
