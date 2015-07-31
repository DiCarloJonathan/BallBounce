using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class canvasControles : MonoBehaviour {
	//Canvas canvas;
	//GameObject canvas;

	public int numButtons=1;

	void Awake () {
		Vector3 location = new Vector3 (0,100,0);
	//	canvas = (Canvas) FindObjectOfType(typeof(Canvas));
	//	canvas = new GameObject("Canvas", typeof(RectTransform));
	//	gameObject
		int scrollWindowH = 350;

		GameObject canvas = AddCanvas ();

		GameObject container = AddContainer (canvas, Vector2.zero, new Vector2(170 ,scrollWindowH));// (numButtons* 30) +40));//make*buttonHighth

		for (int i=0; i<numButtons; i++) {
			ButtonObj(container ,location, "Button", new Vector2 (160, 30), new Color (1f, .3f, .3f, 1f), "Winner", 0, 20, new Color (0f, 0f, 0f, 1f));
			location.y -= 40;
		}
		SliderObj (container, location, new Vector2 (160, 10), Slider.Direction.LeftToRight, 100, 0, 100);
	}

//	void AddEventSystem(){
//		GameObject eventSystem  = new GameObject("Event System", typeof(Transform));
//		eventSystem.AddComponent<Touch>();
//	}
	GameObject AddContainer(GameObject go, Vector2 location, Vector2 size){
		AddScroleBar (go, new Vector2(100,0));//add dementions

		GameObject container = new GameObject ("Container", typeof(RectTransform));
		container.transform.SetParent (go.transform, false);
		ScrollRect sRect = container.AddComponent<ScrollRect>();
		sRect.movementType = ScrollRect.MovementType.Clamped;
		//dont forget image and mask
	

		return container;
	}

	GameObject AddScroleBar (GameObject go, Vector2 location ){
		GameObject scrollBar  = new GameObject("Scroll Bar", typeof(RectTransform), typeof(CanvasRenderer));
		AddImageComponant (scrollBar, Color.magenta, "none", location, new Vector2(10,160), new Vector2(.5f, .5f), new Vector2(.5f, .5f));
		Scrollbar SBarAlt = scrollBar.AddComponent<Scrollbar>();
		scrollBar.transform.SetParent(go.transform, false);

		GameObject slideArea = new GameObject("Slide Area", typeof(RectTransform));
		slideArea.transform.SetParent (scrollBar.transform, false);
		RectTransform slideAreaRect = slideArea.GetComponent<RectTransform>();
		slideAreaRect.sizeDelta = new Vector2 (-20,-20);
		slideAreaRect.anchorMin = new Vector2 (0,0);
		slideAreaRect.anchorMax = new Vector2 (1, 1);
		slideAreaRect.anchoredPosition = new Vector2(0, 0);

		GameObject handle = new GameObject("Handle", typeof(CanvasRenderer));
		AddImageComponant (handle, Color.blue, "Knob", Vector2.zero, new Vector2 (20, 20), new Vector2 (.8f, 0), Vector2.one);
		handle.transform.SetParent (slideArea.transform, false);

		SBarAlt.targetGraphic = handle.GetComponent<Image> ();
		SBarAlt.handleRect = handle.GetComponent<RectTransform>();
		SBarAlt.direction = Scrollbar.Direction.BottomToTop;

	//	scrol
	//	ScrollbarFunctionality (go, SBarAlt.onValueChanged);
	//	SBarAlt.OnDrag(ScrollbarFunctionality(what, 3));
	//	SBarAlt. //(ScrollbarFunctionality(go,3));
	
		
		return scrollBar;
	}
	public void ScrollbarFunctionality(GameObject what, float howmuch){
		Debug.Log ("here");
	}

	GameObject AddCanvas(){
		GameObject canvas  = new GameObject("Canvas", typeof(RectTransform));
		Canvas can = canvas.AddComponent<Canvas>();// add all components for change
		can.renderMode = RenderMode.ScreenSpaceOverlay;
		CanvasScaler canScale = canvas.AddComponent<CanvasScaler>();
		canvas.AddComponent<GraphicRaycaster>();
		canScale.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
		canScale.matchWidthOrHeight = 1;
		canvas.layer = 5;
		return canvas;
	}
	
	void ButtonObj(GameObject go, Vector3 location,string yourSprite ,Vector2 size, Color colorS,string buttonText, int font, int fontSize, Color textColor){

		GameObject button = new GameObject("Button", typeof(CanvasRenderer));
		AddImageComponant (button, colorS, "Button", location, size, new Vector2(.5f, .5f), new Vector2(.5f, .5f));
		Button buttonScript = button.AddComponent<Button>();
		button.transform.SetParent(go.transform, false);
		buttonScript.onClick.AddListener(() => Debug.Log("Yay Click Funtion"));//makes button do stuff
	//	buttonScript.onClick.AddListener(() =>ScrollbarFunctionality(go,3));

		AddTextObjChild (button, font, fontSize, textColor, buttonText, TextAnchor.MiddleCenter,new Vector2(.5f, .5f), Vector2.zero, Vector2.zero, Vector2.one);
		SetLayerRecursively (button, 5);
	
	}
	void SliderObj(GameObject go, Vector3 location, Vector2 size, Slider.Direction direction, float maxSValue, float minSValue, float startValue){
		GameObject slider = new GameObject("Slider");
		slider.transform.SetParent(go.transform, false);
		Slider sliderAlt = slider.AddComponent<Slider>();
		RectTransform sliderRect = slider.GetComponent<RectTransform>();
		sliderRect.anchoredPosition = location;
		sliderRect.sizeDelta = size;

		GameObject background = new GameObject("Background", typeof(CanvasRenderer));
		AddImageComponant (background, Color.white, "none", Vector2.zero, Vector2.zero, new Vector2(0,.25f), new Vector2(1, .75f), Image.Type.Sliced);
		background.transform.SetParent (slider.transform, false);

		GameObject fillArea = new GameObject("Fill Area", typeof(RectTransform));
		fillArea.transform.SetParent (slider.transform, false);
		RectTransform fillAreaRect = fillArea.GetComponent<RectTransform>();
		fillAreaRect.sizeDelta = new Vector2 (-20,0);
		fillAreaRect.anchorMin = new Vector2 (0,.25f);
		fillAreaRect.anchorMax = new Vector2 (1, .75f);
		fillAreaRect.anchoredPosition = new Vector2(-5f, 0);

		GameObject fill = new GameObject("Fill", typeof(CanvasRenderer));
		AddImageComponant (fill, Color.blue, "none", Vector2.zero, new Vector2(10,0), Vector2.zero, Vector2.one);
		fill.transform.SetParent (fillArea.transform, false);

		GameObject handleSlideArea = new GameObject("Handle Slide Area", typeof(RectTransform));
		handleSlideArea.transform.SetParent (slider.transform, false);
		RectTransform handleSlideAreaRect = handleSlideArea.GetComponent<RectTransform>();
		handleSlideAreaRect.sizeDelta = new Vector2 (-20,0);
		handleSlideAreaRect.anchorMin = new Vector2 (0,0);
		handleSlideAreaRect.anchorMax = new Vector2 (1, 1);
		handleSlideAreaRect.anchoredPosition = new Vector2(0, 0);

		GameObject handle = new GameObject("Handle", typeof(CanvasRenderer));
		AddImageComponant (handle, Color.green, "Knob", Vector2.zero, new Vector2 (20, 0), new Vector2 (1, 0), Vector2.one);
		handle.transform.SetParent (handleSlideArea.transform, false);

		SetLayerRecursively (slider, 5);

		sliderAlt.targetGraphic = handle.GetComponent<Image>();
		sliderAlt.fillRect = fill.GetComponent<RectTransform> ();
		sliderAlt.handleRect = handle.GetComponent<RectTransform>();
		sliderAlt.direction = direction;
		sliderAlt.maxValue = maxSValue;
		sliderAlt.minValue = minSValue;
		sliderAlt.value = startValue;
	}
	void AddImageComponant(GameObject go, Color colorS, string yourSprite, Vector2 position, Vector2 size, Vector2 anchorMin, Vector2 anchorMax, Image.Type imageType = Image.Type.Sliced){
		Image image = go.AddComponent<Image>();
		if (Resources.Load(yourSprite, typeof(Sprite)) as Sprite != null)
			image.overrideSprite = Resources.Load(yourSprite, typeof(Sprite)) as Sprite;
		image.rectTransform.sizeDelta = size;
		image.rectTransform.anchorMin =  anchorMin;
		image.rectTransform.anchorMax = anchorMax;
		image.rectTransform.anchoredPosition = position;
		image.color = colorS;
		image.type = imageType;
	}
	void AddTextObjChild(GameObject go, int font, int fontSize, Color textColor, string textActual, TextAnchor textAnchor, Vector2 position, Vector2 size, Vector2 anchorMin, Vector2 anchorMax){
		GameObject text = new GameObject ("Text", typeof(CanvasRenderer));
		AddTextComponent (text, font, fontSize, textColor, textActual, textAnchor, position, size, anchorMin, anchorMax);
		text.transform.SetParent(go.transform, false);

	}
	void AddTextComponent(GameObject go, int font, int fontSize, Color textColor, string textActual, TextAnchor textAnchor, Vector2 position, Vector2 size, Vector2 anchorMin, Vector2 anchorMax){
		Text text = go.AddComponent <Text>();
		text.rectTransform.sizeDelta = size;
		text.rectTransform.anchorMin = anchorMin;
		text.rectTransform.anchorMax = anchorMax;
		text.rectTransform.anchoredPosition = position;
		text.font = Resources.FindObjectsOfTypeAll<Font>()[font];
		text.text = textActual;
		text.fontSize = fontSize;
		text.color = textColor;
		text.alignment = textAnchor;

	}
	public static void SetLayerRecursively(GameObject go, int layerNumber) {
		if (go == null) return;
		foreach (Transform trans in go.GetComponentsInChildren<Transform>(true)) {
			trans.gameObject.layer =5;
		}
	}
}

