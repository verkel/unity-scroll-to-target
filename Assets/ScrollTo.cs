using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollTo : MonoBehaviour {

	public void Start() {
		var colors = GetComponent<Button>().colors;
		var hue = (float) transform.GetSiblingIndex() / transform.parent.childCount;
		colors.normalColor = Color.HSVToRGB(hue, 0.5f, 0.5f);
		colors.highlightedColor = Color.HSVToRGB(hue, 0.7f, 0.7f);
		GetComponent<Button>().colors = colors;
	}

	public void ScrollToThis() {
		var scrollRect = GetComponentInParent<ScrollRect>();
		var content = transform.parent.GetComponent<RectTransform>();

		content.anchoredPosition = 
			(Vector2)scrollRect.transform.InverseTransformPoint(content.position)
			- (Vector2)scrollRect.transform.InverseTransformPoint(GetTopLeftPosition());
	}

	private Vector3 GetTopLeftPosition() {
		var rectTf = (RectTransform)transform;
		return (Vector2)rectTf.position +
			new Vector2(-rectTf.pivot.x * rectTf.sizeDelta.x, rectTf.pivot.y * rectTf.sizeDelta.y);
	}
}
