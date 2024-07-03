using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIGray : MonoBehaviour
{
    [SerializeField]
    private Material m_GrayMaterial;

    [SerializeField]
    private bool m_IsGray;

    public bool IsGray
    {
        get => m_IsGray;
        set
        {
            m_IsGray = value;
            SetGray();
        }
    }

    private List<Graphic> m_GraphicList = new();

    void Start()
    {
        SetGray();
    }

    private void GetAllUIChild()
    {
        m_GraphicList = transform.GetComponentsInChildren<Graphic>().ToList();
        // 剔除不显示的遮罩组件
        m_GraphicList.RemoveAll(graphic => graphic.transform.TryGetComponent<Mask>(out var mask) && !mask.showMaskGraphic);
    }

    private void SetGray()
    {
        GetAllUIChild();
        foreach (var graphic in m_GraphicList)
        {
            graphic.material = m_IsGray ? m_GrayMaterial : null;
        }
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        IsGray = m_IsGray;
    }
#endif
}