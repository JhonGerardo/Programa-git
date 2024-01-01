using UnityEngine;
using UnityEngine.UI;

public class BotonRegresar : MonoBehaviour
{
    public GameObject panelActual;
    public GameObject panelClasificacion;
    public ControladorJuego controladorJuego;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Regresar);
    }

    private void Regresar()
    {
        panelActual.SetActive(false);
        panelClasificacion.SetActive(true);
        controladorJuego.ActualizarPuntaje(); 
    }
}
