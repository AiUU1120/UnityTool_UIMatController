using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIGray : MonoBehaviour
{
    [SerializeField] private Material m_GrayMaterial;

    [SerializeField] private bool m_IsGray;
    
    public bool IsGray
    {
        set => SetGray(value);
    }

    private List<Graphic> m_GraphicList = new();

    void Start()
    {
        GetAllUIChild();
    }

    private void GetAllUIChild()
    {
        m_GraphicList = transform.GetComponentsInChildren<Graphic>().ToList();
    }

    private void SetGray(bool isGray)
    {
        foreach (var graphic in m_GraphicList)
        {
            graphic.material = isGray ? m_GrayMaterial : null;
        }
    }

    private void OnValidate()
    {
        IsGray = m_IsGray;
    }
}