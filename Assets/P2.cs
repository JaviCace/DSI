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
        VisualElement pestaña_blue = top.Query("blue");
        VisualElement pestaña_red= top.Query("red");
        VisualElement pestaña_green = top.Query("green");

       


        pestaña_blue.RegisterCallback<MouseDownEvent>(evt => DisplayBlue(rootve));
        pestaña_red.RegisterCallback<MouseDownEvent>(evt => DisplayRed(rootve));
        pestaña_green.RegisterCallback<MouseDownEvent>(evt => DisplayGreen(rootve));

        pestaña_blue.RegisterCallback<MouseEnterEvent>(evt => { pestaña_blue.AddToClassList("toggleblue"); pestaña_blue.RemoveFromClassList("blue"); });
        pestaña_red.RegisterCallback<MouseEnterEvent>(evt => { pestaña_red.AddToClassList("togglered"); pestaña_red.RemoveFromClassList("red"); });
        pestaña_green.RegisterCallback<MouseEnterEvent>(evt => { pestaña_green.AddToClassList("togglegreen"); pestaña_green.RemoveFromClassList("green"); });

        pestaña_blue.RegisterCallback<MouseLeaveEvent>(evt => { pestaña_blue.AddToClassList("blue"); pestaña_blue.RemoveFromClassList("toggleblue"); });
        pestaña_red.RegisterCallback<MouseLeaveEvent>(evt => { pestaña_red.AddToClassList("red"); pestaña_red.RemoveFromClassList("togglered"); });
        pestaña_green.RegisterCallback<MouseLeaveEvent>(evt => { pestaña_green.AddToClassList("green"); pestaña_green.RemoveFromClassList("togglegreen"); });

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
