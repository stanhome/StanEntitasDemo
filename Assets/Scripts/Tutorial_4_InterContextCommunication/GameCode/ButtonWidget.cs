using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWidget : MonoBehaviour
{
	[SerializeField]
	protected Color onClickColor = Color.green;
	protected Color originalOffColor;

	public ClickEvent OnClick;
	private bool _state = false;

	private void OnEnable()
	{
		if (OnClick == null)
		{
			OnClick = new ClickEvent();
		}
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
