using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class ItemsMotor : MonoBehaviour
{
    [SerializeField] List<Sprite> _itemsSprites;
    [SerializeField] List<GameObject> _itemsObjects;

    [SerializeField] RectTransform _itemTransform;
    [SerializeField] Image _itemImage;
    [SerializeField] RectTransform _underDesk;
    [SerializeField] RectTransform _overDesk;

    [SerializeField] float _time = 1.0f;
    [SerializeField] bool _isUnderDesk;

    [SerializeField] bool _canMoveItem;

    void Start()
    {
        _itemTransform = GetComponent<RectTransform>();
        _itemImage = GetComponent<Image>();
        //StartCoroutine(MoveToPosition(_itemTransform, _overDesk.anchoredPosition, _time));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ChangeImage(1);
            _itemsObjects[0].SetActive(false);
            _itemsObjects[1].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            _canMoveItem = true;
            _isUnderDesk = !_isUnderDesk;
        }
        if (_isUnderDesk && _canMoveItem)
        {
            MoveItem(_overDesk.anchoredPosition, _time);
        } else if (!_isUnderDesk && _canMoveItem)
        {
            MoveItem(_underDesk.anchoredPosition, _time);
        }
        //_itemTransform.anchoredPosition = Vector2.MoveTowards (_underDesk.anchoredPosition, _overDesk.anchoredPosition);
    }

    private void ChangeImage(int _id)
    {
        _itemImage.sprite = _itemsSprites[_id];
        _itemImage.SetNativeSize();
    }

    private IEnumerator MoveToPosition(RectTransform _myObj, Vector2 _targetPos, float _myDuration)
    {
        Vector2 _startPos = _myObj.anchoredPosition;
        float _elapsedTime = 0;

        while (_elapsedTime < _myDuration)
        {
            _myObj.anchoredPosition = Vector2.Lerp(_startPos, _targetPos, _elapsedTime / _myDuration);
            _elapsedTime += Time.deltaTime;
            yield return null;
        }
        _myObj.anchoredPosition = _targetPos;
    }

    public void MoveItem(Vector2 _targetPos, float _myDuration)
    {
        _canMoveItem = false;
        StartCoroutine(MoveToPosition(_itemTransform, _targetPos, _myDuration));
    }
}
