using UnityEngine;

public class VkGazeInteractor : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform endPoint;
        
    [SerializeField] public LayerMask layers = ~0;

    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private float endPointDistance = 1.2f;

    private WordText selectedWord;

    public void Start()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.forward * endPointDistance);
    }

    public void Update()
    {
        lineRenderer.SetPosition(0, transform.position);

        lineRenderer.SetPosition(1, transform.forward * endPointDistance); 
        endPoint.position = transform.position + transform.forward * endPointDistance;
            
        if (!Physics.Raycast(transform.position, transform.forward, out var hit, maxDistance, layers)) return;
            
        var interactable = hit.collider.GetComponent<WordText>();
        if (interactable == null) return;
                
        lineRenderer.SetPosition(1, transform.position);
        endPoint.position = interactable.transform.position - transform.forward * 0.1f;
            
        if(selectedWord != interactable)
            selectedWord?.DeselectThis();
        selectedWord = interactable;
        interactable.SelectThis();
    }
}