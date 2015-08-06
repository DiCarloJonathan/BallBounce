using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class canvasControles : MonoBehaviour {
	
	public GameObject canvas;
	public delegate void ReturnAction(GameObject inputField, int num);
	public static event ReturnAction OnReturn;

	void Awake () {
		OnReturn += AddUi;
		//canvas = AddCanvas ();
		GameObject inputField = AddInputField 
			(canvas, 				
			 new Vector2 (0, 0), 
			 new Vector2 (240, 60), 
			 Vector2.zero, 
			 new Vector2 (-20, -13), 
			 "How many buttons?");
		GetInput (inputField); 

	}
	void GetInput (GameObject inputField){
		InputField inputNumButtons = inputField.GetComponent <InputField> ();
		inputNumButtons.onEndEdit.AddListener (val =>  DealWithInput(inputField, val, OnReturn));
	}
	void DealWithInput (GameObject inputField, string val, ReturnAction rA){
		int value;
		if (Input.GetKeyDown("return")){
			if(int.TryParse(val, out value)){
			//	inputField.SetActive(false);
				rA(inputField,(int)value);
			}
			else{
				print(val+" is not a number");
				
			}
		}
	}
	
	void AddUi(GameObject inputField, int numButtons){
		inputField.SetActive(false);
		Vector3 location = new Vector3 (0, 0, 0);
		int scrollWindowH = 350;
		float containerHight;
		
		if ((float)scrollWindowH / ((float)numButtons * 40 + 40) > 1) {
			containerHight = scrollWindowH;
			location.y += .5f * containerHight - 20;
		} else {
			containerHight = numButtons * 40 + 40;
			location.y += .5f * (numButtons * 40);
		}

		GameObject vScrollBar = AddScroleBar (
			canvas, 
			new Vector2(90,0), 
			new Vector2 (20,
	        scrollWindowH));
		GameObject container = AddContainer (
			canvas, 
			new Vector2(0,(.5f * scrollWindowH) - (.5f * (numButtons * 40 + 40)) ), 
			new Vector2(170, containerHight));
		GameObject scrollArea = AddScrollArea (
			canvas, Vector2.zero, 
			new Vector2(180 ,scrollWindowH), 
			container, 
			vScrollBar);

		spawnButtons (
			numButtons,
		    location,
			container);

		SliderObj (
			container, 
			location -=new Vector3 (0,40*numButtons,0),
			new Vector2 (160, 10), 
			Slider.Direction.LeftToRight, 
			100, 0, 100);
	}
	void spawnButtons(int numButtons, Vector3 location , GameObject container){
		for (int i=0; i<numButtons; i++) {
			ButtonObj(
				container,
				location, 
				"Button", 
				new Vector2 (160, 30), 
				new Color (1f, .3f, .3f, 1f), 
				"Winner " + (i+1),
				0, 20,
				new Color (0f, 0f, 0f, 1f));
			location.y -= 40;
		}
		
		
	}
	GameObject AddInputField(GameObject go, Vector2 location, Vector2 size, Vector2 textLocation, Vector2 textSize, string placeholderText){
		GameObject inputField = new GameObject ("Input Field", typeof(RectTransform));
		inputField.transform.SetParent (go.transform, false);

		AddImageComponant (
			inputField, 
		    Color.white, "none", 
			location, size, 
			new Vector2(.5f, .5f), 
			new Vector2(.5f, .5f));

		InputField inputScript = inputField.AddComponent <InputField> ();

		AddInputCaret (
			inputField, 
			textLocation, textSize);

		IFAddAndSetText (
			inputField, inputScript, 
			textLocation, textSize, 
			placeholderText);

		SetLayerRecursively (inputField, 5);

		return inputField;
	}
	void IFAddAndSetText (GameObject go, InputField inputScript, Vector2 textLocation, Vector2 textSize,  string placeholderText){
		Text placeHolderText = AddTextObjChild (
			go, 0, 30, Color.grey, 
			placeholderText, 
			TextAnchor.MiddleLeft, 
			textLocation, textSize, 
			Vector2.zero, Vector2.one, 
			"Place Holder Text");
		Text inputText = AddTextObjChild(
			go, 0, 30, Color.black, 
		    "", TextAnchor.MiddleLeft,
			textLocation, textSize, 
			Vector2.zero, Vector2.one);
		placeHolderText.fontStyle = FontStyle.Italic;
		inputText.supportRichText = false;
		
		inputScript.textComponent = inputText;
		inputScript.placeholder = placeHolderText;

	}

	GameObject AddInputCaret (GameObject go, Vector2 textLocation, Vector2 textSize){
		GameObject inputCaret = new GameObject (
			"Input Field Input Caret", 
			typeof(RectTransform), 
			typeof(CanvasRenderer));
		LayoutElement layout = inputCaret.AddComponent<LayoutElement>();
		inputCaret.transform.SetParent (go.transform, false);
		layout.ignoreLayout = true;
		RectTransform inputCaretRect = inputCaret.GetComponent<RectTransform>();
		inputCaretRect.anchoredPosition = textLocation;
		inputCaretRect.sizeDelta = textSize;
		inputCaretRect.anchorMin = Vector2.zero;
		inputCaretRect.anchorMax = Vector2.one;

		return inputCaret;
	}

	GameObject AddScrollArea(GameObject go, Vector2 location, Vector2 size, GameObject container, GameObject vScrollBar, Scrollbar hScrollBar=null){

		ScrollRect sRect =null;

		GameObject scrollArea = SetScrollArea(
			go, ref sRect,
			location,  size);

		container.transform.SetParent (scrollArea.transform, false);

		SetSRect (sRect, container, vScrollBar);

		SetLayerRecursively (scrollArea, 5);

		return scrollArea;
	}

	GameObject SetScrollArea(GameObject go, ref ScrollRect sRect, Vector2 location, Vector2 size){
		GameObject scrollArea = new GameObject ("Scroll Area", typeof(RectTransform));
		scrollArea.transform.SetParent (go.transform, false);
		sRect = scrollArea.AddComponent<ScrollRect>();

		AddImageComponant (
			scrollArea, 
			Color.white, "none", 
			location, size, 
			new Vector2(.5f, .5f), 
			new Vector2(.5f, .5f));
		scrollArea.AddComponent<Mask>();

		return scrollArea;
	}
	void SetSRect(ScrollRect sRect, GameObject container, GameObject vScrollBar){
		sRect.movementType = ScrollRect.MovementType.Clamped;
		sRect.horizontal = false;
		sRect.inertia = false;
		sRect.content=container.GetComponent<RectTransform>();
		sRect.verticalScrollbar = vScrollBar.GetComponent<Scrollbar>();

	}

	GameObject AddContainer(GameObject go, Vector2 location, Vector2 size){
		GameObject container = new GameObject ("Container", typeof(RectTransform));
		container.transform.SetParent (go.transform, false);
		AddImageComponant (container, Color.white, "none", location, size, new Vector2(.5f, .5f), new Vector2(.5f, .5f));

		SetLayerRecursively (container, 5);	

		return container;
	}

	GameObject AddScroleBar (GameObject go, Vector2 location, Vector2 size){
		GameObject scrollBar = new GameObject ("Scroll Bar", typeof(RectTransform), typeof(CanvasRenderer));
		AddImageComponant (scrollBar, Color.magenta, "none", location, size, new Vector2 (.5f, .5f), new Vector2 (.5f, .5f));
		Scrollbar sBarAlt = scrollBar.AddComponent<Scrollbar> ();
		scrollBar.transform.SetParent (go.transform, false);

		GameObject slideArea = AddSlideArea (scrollBar);

		GameObject handle = new GameObject ("Handle", typeof(CanvasRenderer));
		AddImageComponant (handle, Color.blue, "Knob", Vector2.zero, new Vector2 (20, 20), new Vector2 (.8f, 0), Vector2.one);
		handle.transform.SetParent (slideArea.transform, false);

		SetSBarAlt (sBarAlt, handle);

		SetLayerRecursively (scrollBar, 5);
		
		return scrollBar;
	}
	void SetSBarAlt (Scrollbar sBarAlt, GameObject handle){
		sBarAlt.targetGraphic = handle.GetComponent<Image> ();
		sBarAlt.handleRect = handle.GetComponent<RectTransform> ();
		sBarAlt.direction = Scrollbar.Direction.BottomToTop;
	}

	GameObject AddSlideArea (GameObject go){
		GameObject slideArea = new GameObject ("Slide Area", typeof(RectTransform));
		slideArea.transform.SetParent (go.transform, false);
		RectTransform slideAreaRect = slideArea.GetComponent<RectTransform> ();
		slideAreaRect.sizeDelta = new Vector2 (-20, -20);
		slideAreaRect.anchorMin = new Vector2 (0, 0);
		slideAreaRect.anchorMax = new Vector2 (1, 1);
		slideAreaRect.anchoredPosition = new Vector2 (0, 0);

		return slideArea;

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
		AddImageComponant (
			background, Color.magenta, "none", 
		    Vector2.zero, Vector2.zero, 
		    new Vector2(0,.25f), new Vector2(1, .75f), 
		    Image.Type.Sliced);
		background.transform.SetParent (slider.transform, false);

		GameObject fillArea = SetFillArea (
			slider, "Fill Area",
			new Vector2(-20,0), new Vector2(-5f,0), 
			new Vector2(0,.25f), new Vector2(1,.75f));

		GameObject fill = new GameObject("Fill", typeof(CanvasRenderer));
		AddImageComponant (
			fill, 
			Color.blue, "none",
			Vector2.zero, new Vector2(10,0), 
			Vector2.zero, Vector2.one);
		fill.transform.SetParent (fillArea.transform, false);

		GameObject handleSlideArea = SetFillArea (
			slider, "Handle Slide Area",
			new Vector2(-20,0), new Vector2(0,0), 
			new Vector2(0,0), new Vector2(1,1));

		GameObject handle = new GameObject("Handle", typeof(CanvasRenderer));
		AddImageComponant (
			handle, 
			Color.green, "Knob", 
			Vector2.zero, new Vector2 (20, 0), 
			new Vector2 (1, 0), Vector2.one);
		handle.transform.SetParent (handleSlideArea.transform, false);

		SetSliderAlt (sliderAlt, handle, fill, direction, maxSValue, minSValue, startValue);

		SetLayerRecursively (slider, 5);
	}
	void SetSliderAlt(Slider sliderAlt, GameObject handle, GameObject fill, Slider.Direction direction, float maxSValue, float minSValue, float startValue){
		sliderAlt.targetGraphic = handle.GetComponent<Image>();
		sliderAlt.fillRect = fill.GetComponent<RectTransform> ();
		sliderAlt.handleRect = handle.GetComponent<RectTransform>();
		sliderAlt.direction = direction;
		sliderAlt.maxValue = maxSValue;
		sliderAlt.minValue = minSValue;
		sliderAlt.value = startValue;
	}
	GameObject SetFillArea(GameObject go, string name, Vector2 size, Vector2 position, Vector2 anchorMin, Vector2 anchorMax){
		GameObject fillArea = new GameObject(name, typeof(RectTransform));
		fillArea.transform.SetParent (go.transform, false);
		RectTransform fillAreaRect = fillArea.GetComponent<RectTransform>();
		fillAreaRect.sizeDelta =  size;
		fillAreaRect.anchorMin = anchorMin;
		fillAreaRect.anchorMax =  anchorMax;
		fillAreaRect.anchoredPosition = position;

		return fillArea;
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
	Text AddTextObjChild(GameObject go, int font, int fontSize, Color textColor, string textActual, TextAnchor textAnchor, Vector2 position, Vector2 size, Vector2 anchorMin, Vector2 anchorMax, string name = "Text"){
		GameObject text = new GameObject (name, typeof(CanvasRenderer));
		Text textC = AddTextComponent (
			text, font, fontSize, textColor,
			textActual, textAnchor,
			position, size,
			anchorMin, anchorMax);
		text.transform.SetParent(go.transform, false);
		SetLayerRecursively (text, 5);

		return textC;

	}
	Text AddTextComponent(GameObject go, int font, int fontSize, Color textColor, string textActual, TextAnchor textAnchor, Vector2 position, Vector2 size, Vector2 anchorMin, Vector2 anchorMax){
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

		return text;
	}
	public static void SetLayerRecursively(GameObject go, int layerNumber) {
		if (go == null) return;
		foreach (Transform trans in go.GetComponentsInChildren<Transform>(true)) {
			trans.gameObject.layer =5;
		}
	}
}

