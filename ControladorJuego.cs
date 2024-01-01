using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorJuego : MonoBehaviour
{
    public Canvas canvas;
    public Text puntajeText;
    public GameObject panelAnimales;
    public GameObject panelArboles;
    public GameObject panelRecursosNaturales;
    public GameObject panelClasificacion;
   


    private int puntaje = 20;
    private Elemento ultimoElementoArrastrado;

    public void ElementoArrastrado(Elemento elemento)
    {
        if (ultimoElementoArrastrado != null && SonRelacionados(ultimoElementoArrastrado, elemento))
        {
            puntaje += 15; 
        }
        else
        {
            puntaje -= 5; 
        }

        ultimoElementoArrastrado = elemento;

        ActualizarPuntaje();
    }

    public void ActualizarPuntaje()
    {
        puntajeText.text = "Puntaje: " + puntaje;

        if (puntaje <= 0)
        {
            
            UnityEngine.SceneManagement.SceneManager.LoadScene("EscenaFin");
        }
    }

    public void BotonRegresarPresionado(GameObject panelActual)
    {
        panelActual.SetActive(false); 

       
        DesactivarElementosEnPanel(panelActual);

        panelClasificacion.SetActive(true);
        ultimoElementoArrastrado = null;
        puntaje -= 5;

        ActualizarPuntaje();
    }

    private void DesactivarElementosEnPanel(GameObject panel)
    {
        Elemento[] elementosEnPanel = panel.GetComponentsInChildren<Elemento>();

        foreach (Elemento elemento in elementosEnPanel)
        {
            elemento.gameObject.SetActive(false);
        }
    }

    private bool SonRelacionados(Elemento elemento1, Elemento elemento2)
    {
       
        if (elemento1.categoria == Elemento.TipoCategoria.Animales && elemento2.categoria == Elemento.TipoCategoria.Arboles)
        {
            
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
        }
        else if (elemento1.categoria == Elemento.TipoCategoria.RecursosNaturales && elemento2.categoria == Elemento.TipoCategoria.Arboles)
        {
            if (elemento1.nombre == "Sol" && elemento2.nombre == "Eucalipto")
            {
                return true;
            }
        }
       

        return false;
    }
}
