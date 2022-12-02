using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GoalZone : MonoBehaviour
{

    //Referencia para acceder al marcador de  puntos
    public TextMeshProUGUI scoreText;

    //Variable para guardar los puntos marcados
    [SerializeField] int score;

    //Antes de que empiece el juego
    private void Awake()
    {
        //Ponemos la puntuaci�n a 0
        score = 0;

        //Cambiamos el texto de las puntuaciones al valor que tenga en ese momento el score
        scoreText.text = score.ToString();

        /* Para transformar un int en un string de 3 maneras
         * scoreText.text = score + ""; le sumo un string vaci� a ese int, luego ya todo es string
         * scoreText.text = score.ToString();transformo(cast) el int en un string
         * scoreText.text = "Score: " + score; a un string le ponemos despu�s un int, con lo cu�l ya todo es string
        */
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //M�todo para detectar cuando algo ha entrado en el trigger (zona de gol)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Solo aquellos gameObjects etiquetados como pelota, que  hayan entrado en el trigger
        if (collision.gameObject.tag == "Ball") 
        {
            //Sumo 1 a la puntuaci�n
            score++; //score++ <-> score = score + 1 <-> score += 1

            scoreText.text = score.ToString();

            //Ejecuto el m�todo de que se ha marcado un punto que est� programado en el GameManager
            GameManager.sharedInstance.GoalScored();
        }
    }
}
