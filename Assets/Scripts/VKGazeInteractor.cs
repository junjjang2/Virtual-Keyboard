﻿using System;
using UnityEngine;

public class VkGazeInteractor : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform endPoint;
        
    [SerializeField] public LayerMask layers = ~0;

    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private float endPointDistance = 1.2f;

    private WordText selectedWord;

    public void OnEnable()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.forward * endPointDistance);
        
        endPoint.gameObject.SetActive(true);
    }

    public void OnDisable()
    {
        if(selectedWord != null)
            selectedWord.DeselectThis();
        
        endPoint.gameObject.SetActive(false);
    }

    public void Update()
    {
        lineRenderer.SetPosition(0, transform.position);

        lineRenderer.SetPosition(1, transform.position + transform.forward * maxDistance); 
        endPoint.position = transform.position + transform.forward * maxDistance;
            
        if (!Physics.Raycast(transform.position, transform.forward, out var hit, maxDistance, layers)) 
            return;
            
        var interactable = hit.collider.GetComponent<WordText>();
        if (interactable == null) return;
                
        lineRenderer.SetPosition(1, interactable.transform.position - transform.forward * 0.1f);
        endPoint.position = interactable.transform.position - transform.forward * 0.1f;
            
        if(selectedWord != interactable)
            selectedWord?.DeselectThis();
        selectedWord = interactable;
        interactable.SelectThis();
    }
}