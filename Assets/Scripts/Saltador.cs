using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saltador : MonoBehaviour
{
    private bool spacePressionada;
    private float eixoHorizontal;
    private Rigidbody referenciaRigidbody;
    private bool naPlataforma;
    private Transform CheckColisaoEsfera;
    public float disMax;
    public float forcaPulo;
    public LayerMask layerMask;
    public float raio;

    //Máscara layer  usada ​​por raycasting para seletivamente criar colisões
   
    // Start is called before the first frame update
       void Start()
    {
        referenciaRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame 70 frame po segundo
    void Update()
    {
        RaycastHit hit;// obter informações do raycast

        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePressionada = true;
        }

        if (Physics.SphereCast(transform.position, raio, -Vector3.up, out hit, 1, layerMask) && spacePressionada)
        {                                       //raio da esfera/direção/info    /layer plataforma

            var direcao = hit.point - transform.position;

            var poxPlataforma = hit.distance < disMax;

            direcao.Normalize();

            var angulo = Vector3.Angle(-Vector3.up, direcao);

            print("teste " + angulo);

            if (angulo < 90 && poxPlataforma)
            {
                referenciaRigidbody.AddForce(Vector3.up * forcaPulo, ForceMode.VelocityChange);
            }

            spacePressionada = false;
        }

        //Movimento horizontal
        eixoHorizontal = Input.GetAxis("Horizontal");
    }

    // 100 por segundo
    private void FixedUpdate()//para atualizações física
    {

        /* if(Physics.OverlapSphere((CheckColisaoEsfera.position, 0.1f).Length == 0) //verifica colisão com a plataforma
        {
            return;
        }*/

        if ((spacePressionada) && (naPlataforma))
        {
            Debug.Log("space pressionada");
         
            //referenciaRigidbody.AddForce(Vector3.up * 5, ForceMode.VelocityChange);

             
        }

        referenciaRigidbody.velocity = new Vector3(eixoHorizontal, referenciaRigidbody.velocity.y, 0);
    }

    

    private void OnDrawGizmos()//desenha linha criada
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position - Vector3.up * disMax);

    }

    private void OnCollisionEnter(Collision collision)
    {
        naPlataforma = true;
        Debug.Log("Colisão com a plataforma");
    }

    private void OnCollisionExit(Collision collision)
    {
        naPlataforma = false;
        Debug.Log("Sem colisão com a plataforma");
    }

    //Colisão para colatar objetos
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
    }
}
