using UnityEngine;
using UnityEngine.UI;

public class Tiempo1 : MonoBehaviour
{
    public Text textoContador;
    private float tiempoTranscurrido = 0f;
    static public int contador = 0;
    private float intervaloDeActualizacion = 0.5f; // Intervalo de actualización en segundos

    void Start()
    {
        contador = 0;
    }
    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;

        // Comprueba si ha pasado el intervalo de actualización (1 segundo)
        if (tiempoTranscurrido >= intervaloDeActualizacion)
        {
            // Suma 10 al contador
            contador += 5;
            ActualizarTextoContador();

            // Reinicia el tiempo transcurrido
            tiempoTranscurrido = 0f;
        }
        /*if (contador == 300f)
        {
            
        }*/
    }


    void ActualizarTextoContador()
    {
        // Actualiza el texto en pantalla con el valor del contador
        textoContador.text = "LightYears:" + contador;
    }
}