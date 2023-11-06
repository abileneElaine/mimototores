using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

public int velocidade = 10;
public int forcaPulo = 7;
public bool noChao;
private Rigidbody rb;
private AudioSource source;
public AudioClip clipPulo, clipMoeda;

    
    // Start is called before the first frame update
    void Start()
    {
       Debug.Log("UPDATE");
       TryGetComponent(out rb);
       TryGetComponent(out source);
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Chão"){
            noChao = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
       float h = Input.GetAxis("Horizontal"); //-1 esquerda, 0 nada, -1 direita
       float v = Input.GetAxis("Vertical"); //-1 para tras, 0 nada, -1 pra frente
       Vector3 direcao = new Vector3(h, 0, v);
       rb.AddForce(direcao * velocidade * Time.deltaTime,ForceMode.Impulse);
     
       if(Input.GetKeyDown(KeyCode.Space) && noChao){//se apertou espaço
      //pulo 
      source.Play();
       
        //aplica força para cima
        rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
        noChao = false;
       }


       if(transform.position.y <= -10){
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       }
    }
}
