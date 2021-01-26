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

    // Start is called before the first frame update
    void Start()
    {
        referenciaRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame 70 frame po segundo
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePressionada = true;
        }

        //Movimento horizontal
        eixoHorizontal = Input.GetAxis("Horizontal");
    }

    // 100 por segundo
    private void FixedUpdate()//para atualizações física
    {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
            print("Found an object - distance: " + hit.distance);


        /*if(Physics.OverlapSphere(CheckColisaoEsfera.position, 0.1f).Length == 0) //verifica colisão com a plataforma
        {
            return;
        }*/

        if ((spacePressionada) && (naPlataforma))
        {
            Debug.Log("space pressionada");
         
            referenciaRigidbody.AddForce(Vector3.up * 5, ForceMode.VelocityChange);

            spacePressionada = false;  
        }

        referenciaRigidbody.velocity = new Vector3(eixoHorizontal, referenciaRigidbody.velocity.y, 0);

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
