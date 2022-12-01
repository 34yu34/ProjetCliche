using NaughtyAttributes;
using UnityEngine;

public class RecipeProgressionBar : MonoBehaviour
{
    [SerializeField] private GameObject _insideBar;

    [ShowNonSerializedField] private float _barPercent;

    public float BarPercent
    {
        get => _barPercent;
        set
        {
            _barPercent = Mathf.Clamp(value, 0f, 1f);
            ResizeBar();
        }
    }

    [Button]
    private void ResizeBar()
    {
        var transformLocalScale = _insideBar.transform.localScale;
        transformLocalScale.y = _barPercent;
        _insideBar.transform.localScale = transformLocalScale;

        var transformPosition = _insideBar.transform.localPosition;
        transformPosition.y = -(1f - _barPercent) / 2f / 2f;
        _insideBar.transform.localPosition = transformPosition;
    }
}
