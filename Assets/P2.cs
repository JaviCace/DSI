using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Linq;
using Unity.VisualScripting;
public class P2 : MonoBehaviour
{
    private void OnEnable() 
    {
   
        UIDocument UIdoc = GetComponent<UIDocument>();
        VisualElement rootve = UIdoc.rootVisualElement;
        VisualElement top = rootve.Query("Top");
        VisualElement pesta�a_blue = top.Query("blue");
        VisualElement pesta�a_red= top.Query("red");
        VisualElement pesta�a_green = top.Query("green");

       


        pesta�a_blue.RegisterCallback<MouseDownEvent>(evt => DisplayBlue(rootve));
        pesta�a_red.RegisterCallback<MouseDownEvent>(evt => DisplayRed(rootve));
        pesta�a_green.RegisterCallback<MouseDownEvent>(evt => DisplayGreen(rootve));

        pesta�a_blue.RegisterCallback<MouseEnterEvent>(evt => { pesta�a_blue.AddToClassList("toggleblue"); pesta�a_blue.RemoveFromClassList("blue"); });
        pesta�a_red.RegisterCallback<MouseEnterEvent>(evt => { pesta�a_red.AddToClassList("togglered"); pesta�a_red.RemoveFromClassList("red"); });
        pesta�a_green.RegisterCallback<MouseEnterEvent>(evt => { pesta�a_green.AddToClassList("togglegreen"); pesta�a_green.RemoveFromClassList("green"); });

        pesta�a_blue.RegisterCallback<MouseLeaveEvent>(evt => { pesta�a_blue.AddToClassList("blue"); pesta�a_blue.RemoveFromClassList("toggleblue"); });
        pesta�a_red.RegisterCallback<MouseLeaveEvent>(evt => { pesta�a_red.AddToClassList("red"); pesta�a_red.RemoveFromClassList("togglered"); });
        pesta�a_green.RegisterCallback<MouseLeaveEvent>(evt => { pesta�a_green.AddToClassList("green"); pesta�a_green.RemoveFromClassList("togglegreen"); });

        Label redtext = rootve.Query<Label>("RedText");
        redtext.style.color = new StyleColor(Color.magenta);



        Button buton = rootve.Query<Button>("BlueButton");
        buton.AddToClassList("button");
        buton.clicked += ()=> buton.style.scale = new Scale( new Vector3(1.5f, 1.5f, 1.5f));

        Scroller slider = rootve.Query<Scroller>().First();
        slider.AddToClassList("slider"); slider.RemoveFromClassList("unity-scroller"); slider.RemoveFromClassList("unity-scroller--horizontal");

        ProgressBar progress = rootve.Query<ProgressBar>().First();
        progress.AddToClassList("progress"); progress.RemoveFromClassList("unity-progress-bar");
    }
    void DisplayBlue(VisualElement rootve) 
    {
        VisualElement blue = rootve.Query(className: "blue").Last();
        VisualElement red = rootve.Query(className: "red").Last();
        VisualElement green = rootve.Query(className: "green").Last();
        blue.style.display = DisplayStyle.Flex;
        red.style.display = DisplayStyle.None;
        green.style.display = DisplayStyle.None;

        Label bluetext = rootve.Query<Label>("BlueText");
        Label redtext = rootve.Query<Label>("RedText");
        Label greentext = rootve.Query<Label>("GreenText");
        bluetext.style.color = new StyleColor(Color.cyan);
        redtext.style.color = new StyleColor(Color.black);
        greentext.style.color = new StyleColor(Color.black);

    }
    void DisplayGreen(VisualElement rootve)
    {
        VisualElement green = rootve.Query(className: "green").Last();
        VisualElement blue = rootve.Query(className: "blue").Last();
        VisualElement red = rootve.Query(className: "red").Last();
        green.style.display = DisplayStyle.Flex;
        red.style.display = DisplayStyle.None;
        blue.style.display = DisplayStyle.None;

        Label bluetext = rootve.Query<Label>("BlueText");
        Label redtext = rootve.Query<Label>("RedText");
        Label greentext = rootve.Query<Label>("GreenText");
        bluetext.style.color = new StyleColor(Color.black);
        redtext.style.color = new StyleColor(Color.black);
        greentext.style.color = new StyleColor(Color.yellow);

    }
    void DisplayRed(VisualElement rootve)
    {
        VisualElement red = rootve.Query(className: "red").Last();
        VisualElement blue = rootve.Query(className: "blue").Last();
        VisualElement green = rootve.Query(className: "green").Last();
        red.style.display = DisplayStyle.Flex;
        green.style.display = DisplayStyle.None;
        blue.style.display = DisplayStyle.None;

        Label bluetext = rootve.Query<Label>("BlueText");
        Label redtext = rootve.Query<Label>("RedText");
        Label greentext = rootve.Query<Label>("GreenText");
        bluetext.style.color    = new StyleColor(Color.black);
        redtext.style.color = new StyleColor(Color.magenta);
        greentext.style.color = new StyleColor(Color.black);

    }

}
