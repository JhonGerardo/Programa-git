using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ControladorJuego : MonoBehaviour
{
    public Canvas canvas;
    public Text puntajeText;
    public GameObject panelAnimales;
    public GameObject panelArboles;
    public GameObject panelRecursosNaturales;
    public GameObject panelClasificacion;
    public Text mensajeText;
    public float tiempoDeMensajeVisible = 8.0f;

    private int puntaje = 15;
    private Elemento ultimoElementoArrastrado;

    private Dictionary<string, string> mensajes = new Dictionary<string, string>();

    private Coroutine mensajeCoroutine;

    private void Start()
    {
        InicializarMensajes();
        ActualizarPuntaje();
    }

    private void InicializarMensajes()
    {
        // Asocia mensajes con pares específicos
        mensajes.Add("Abeja_Flor", "¡Acierto!Las abejas supcionan el nectar de las flores y con ella crean la miel que es su alimento, y a su vez polinizan de esta forma las flores para que produzcan sus frutos.");
        mensajes.Add("Mono_Guayabo", "¡Acierto!Los monos se alimentan de frutos como este, y dispersan las semillas diversificando asi la fauna");
        mensajes.Add("Gusano_Lago", "Los gusanos habitan en estos medios ");
        mensajes.Add("Colibri_Pino", "Hacen nido");
        mensajes.Add("Oso_Naranjas", "Oso come Naranjas");
        mensajes.Add("Ave_Cipre",  "Hace nidos");
        mensajes.Add("Caballo_Rio", " El caballo toma agua del Rio");
        mensajes.Add("Siervo_Sol", "Sol calienta siervo"); 
        
    }

    public void ElementoArrastrado(Elemento elemento)
    {
        if (ultimoElementoArrastrado != null && SonRelacionados(ultimoElementoArrastrado, elemento))
        {
            puntaje += 15;
            string clave = $"{ultimoElementoArrastrado.nombre}_{elemento.nombre}";
            if (mensajes.ContainsKey(clave))
            {
                MostrarMensaje(mensajes[clave]);
            }
            else
            {
                MostrarMensaje("¡Acierto!");
            }

            // Resto de la lógica...
        }
        else
        {
            puntaje -= 5;
            // Resto de la lógica...
        }

        ultimoElementoArrastrado = elemento;
        ActualizarPuntaje();
    }

    private void MostrarMensaje(string mensaje)
    {
        if (mensajeCoroutine != null)
        {
            StopCoroutine(mensajeCoroutine);
        }

        mensajeText.text = mensaje;
        mensajeText.gameObject.SetActive(true);

        mensajeCoroutine = StartCoroutine(OcultarMensajeDespuesDeTiempo());
    }

    private IEnumerator OcultarMensajeDespuesDeTiempo()
    {
        yield return new WaitForSeconds(tiempoDeMensajeVisible);
        mensajeText.gameObject.SetActive(false);
    }

    public void ActualizarPuntaje()
    {
        puntaje = Mathf.Clamp(puntaje, 0, 100);
        puntajeText.text = "Puntaje: " + puntaje;

        if (puntaje <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("EscenaFin");
        }
    }

    private bool SonRelacionados(Elemento elemento1, Elemento elemento2)
    {
        // Lógica de relación específica entre elementos
        // Agrega más casos según tus relaciones
        if ((elemento1.nombre == "Abeja" && elemento2.nombre == "Flor") ||
            (elemento1.nombre == "Mono" && elemento2.nombre == "Guayabo") ||
            (elemento1.nombre == "Gusano" && elemento2.nombre == "Lago") ||
            (elemento1.nombre == "Colibri" && elemento2.nombre == "Pino") ||
            (elemento1.nombre == "Oso" && elemento2.nombre == "Naranjas") ||
            (elemento1.nombre == "Ave" && elemento2.nombre == "Cipre") ||
            (elemento1.nombre == "Caballo" && elemento2.nombre == "Rio") ||
            (elemento1.nombre == "Siervo" && elemento2.nombre == "Sol"))
        {
            return true;
        }

        return false;
    }
}
