using UnityEngine;
using UnityEngine.EventSystems;


public class Elemento : MonoBehaviour, IDragHandler, IEndDragHandler

{
    public string nombre; 
    public enum TipoCategoria
    {
        Animales,
        Arboles,
        RecursosNaturales
    }

    public TipoCategoria categoria;
    public int puntaje = 5;

    private ControladorJuego controladorJuego;
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        controladorJuego = GameObject.FindObjectOfType<ControladorJuego>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / controladorJuego.canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        controladorJuego.ElementoArrastrado(this);
    }
}
