using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowInfoPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] float _timeToWait = 2f;
    [SerializeField] bool _poinerOver = false;
    [SerializeField] RectTransform _infoPanel;
    float _timeSpended = 0;
    public void OnPointerEnter(PointerEventData eventData)
    {
        _poinerOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _poinerOver = false;
        _infoPanel.gameObject.SetActive(false);
        _timeSpended = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(_poinerOver==true)
        {
            
            if (_timeSpended >= _timeToWait)
            {
                _infoPanel.gameObject.SetActive(true);
            }
            else
            {
                _timeSpended += Time.deltaTime;
            }
        }
    }
}
