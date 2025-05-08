
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Linq;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

namespace DSIFin
{
    public class DSIFinal : MonoBehaviour
    {

        private void OnEnable()
        {
            int Numero = 0;
            bool colisionverde = false;
            bool colisionrojo = false;
            bool colisionamarillo = false;
            bool colisiontodos = false;

            bool piedra1 = false;
            bool piedra2 = false;
            bool piedra3 = false;
            bool piedra4 = false;
            bool piedra5 = false;
            bool piedra6 = false;
            bool piedra7 = false;
            bool piedra8 = false;
            bool piedra9 = false;
            bool todaspiedras = false;
            UIDocument UIdoc = GetComponent<UIDocument>();
            VisualElement rootve = UIdoc.rootVisualElement;
            VisualElement ventanas = rootve.Query("Ventanas");
            VisualElement pestaña_1 = ventanas.Query("1");
            VisualElement pestaña_2 = ventanas.Query("2");
            VisualElement pestaña_3 = ventanas.Query("3");
            VisualElement Tesoro = rootve.Query("Cofre");

            bool Level2 = false;
            bool Level3 = false;
            VisualElement BotonCrear = rootve.Q("Crear");
            VisualElement contDer = rootve.Q("ContDer");
            TextField name = rootve.Q<TextField>("Nombre");
            TextField surname = rootve.Q<TextField>("Apellido");
            Individuo* individuoSelect;
            BotonCrear.RegisterCallBack<ClickEvent>();
            name.RegisterCallBack<ChangeEvent<string>>();
            surname.RegisterCallBack<ChangeEvent<string>>();
            contDer.RegisterCallBack<ClickEvent>(SelecciónTarjeta);


            VisualElement buttonPrincipal = rootve.Query("BotonPrincipal");
            VisualElement buttonLevel1 = rootve.Query("BotonNivel1");
            VisualElement buttonLevel2 = rootve.Query("BotonNivel2");
            VisualElement buttonLevel3 = rootve.Query("BotonNivel3");


            //NIVEL 1
            VisualElement cuadRojo = rootve.Query("RedCuad");
            VisualElement cuadAmarillo = rootve.Query("YellowCuad");
            VisualElement cuadVerde = rootve.Query("GreenCuad");
            cuadRojo.AddManipulator(new Mover());
            cuadVerde.AddManipulator(new Mover());
            cuadAmarillo.AddManipulator(new Mover());
            VisualElement centroRojo = rootve.Query("RedCenter");
            VisualElement centroAmarillo = rootve.Query("YellowCenter");
            VisualElement centroVerde = rootve.Query("GreenCenter");
            VisualElement ColisionerRojo = rootve.Query("RedCollision");
            VisualElement ColisionerAmarillo = rootve.Query("YellowCollision");
            VisualElement ColisionerVerde = rootve.Query("GreenCollision");
            VisualElement buttonNivel2 = rootve.Query("Bnivel1");

            rootve.schedule.Execute(() =>
            {
                colisionverde = Intersect(centroVerde, ColisionerVerde);
                colisionamarillo = Intersect(centroAmarillo, ColisionerAmarillo);
                colisionrojo = Intersect(centroRojo, ColisionerRojo);

                colisiontodos = colisionverde && colisionamarillo && colisionrojo;

                if (colisiontodos)
                {
                    Debug.Log("¡Todos en su sitio!");
                    buttonNivel2.style.display = DisplayStyle.Flex;
                }
            }).Every(100);

            //NIVEL 2
            VisualElement cuad1 = rootve.Query("BlackCuad1");

            List<VisualElement> list1 = cuad1.Children().ToList();
            VisualElement buttonNivel3 = rootve.Query("Bnivel2");
            list1 = list1.OrderBy(x => Random.Range(0f, 1f)).ToList();
            for (int i = 0; i < list1.Count; i++)
            {
                int expectedIndex = i;
                list1[i].AddManipulator(new Clicker(async () =>
                {
                    if (Numero == expectedIndex)
                    {
                        Numero++;
                    }
                    else
                    {
                        await System.Threading.Tasks.Task.Delay(300); // 300 ms
                        foreach (var elem in list1)
                        {
                            // Elimina los bordes en lugar de clases
                            elem.style.borderLeftWidth = 0;
                            elem.style.borderRightWidth = 0;
                            elem.style.borderTopWidth = 0;
                            elem.style.borderBottomWidth = 0;
                        }
                        Numero = 0;
                    }
                }));
            }
            rootve.schedule.Execute(() =>
            {
                if (Numero == list1.Count)
                {
                    buttonNivel3.style.display = DisplayStyle.Flex;
                }
            }).Every(100);

            //NIVEL3
            VisualElement cuad2 = rootve.Query("BlackCuad2");
            List<VisualElement> list2 = cuad2.Children().ToList();
            VisualElement buttonTreasure = rootve.Query("Bnivel3");
            VisualElement Salir = rootve.Query("Salir");
            foreach (var elem in list2)
            {
                elem.AddManipulator(new Rotator());
                elem.AddManipulator(new Pointer());
            }

            rootve.schedule.Execute(() =>
            {
                if (list2.Count >= 9)
                {
                    piedra1 = Mathf.Approximately(list2[0].transform.rotation.eulerAngles.z, 0f);
                    piedra2 = Mathf.Approximately(list2[1].transform.rotation.eulerAngles.z, 0f);
                    piedra3 = Mathf.Approximately(list2[2].transform.rotation.eulerAngles.z, 0f);
                    piedra4 = Mathf.Approximately(list2[3].transform.rotation.eulerAngles.z, 0f);
                    piedra5 = Mathf.Approximately(list2[4].transform.rotation.eulerAngles.z, 0f);
                    piedra6 = Mathf.Approximately(list2[5].transform.rotation.eulerAngles.z, 0f);
                    piedra7 = Mathf.Approximately(list2[6].transform.rotation.eulerAngles.z, 0f);
                    piedra8 = Mathf.Approximately(list2[7].transform.rotation.eulerAngles.z, 0f);
                    piedra9 = Mathf.Approximately(list2[8].transform.rotation.eulerAngles.z, 0f);

                    if (piedra1 && piedra2 && piedra3 && piedra4 && piedra5 &&
                        piedra6 && piedra7 && piedra8 && piedra9 && !todaspiedras)
                    {
                        todaspiedras = true;
                        buttonTreasure.style.display = DisplayStyle.Flex;
                    }
                }
            }).Every(100);

            //MENUS
            pestaña_1.RegisterCallback<MouseDownEvent>(evt => DisplayRed(rootve));
            pestaña_2.RegisterCallback<MouseDownEvent>(evt => DisplayGreen(rootve));
            pestaña_3.RegisterCallback<MouseDownEvent>(evt => DisplayBlue(rootve));
            Tesoro.RegisterCallback<MouseDownEvent>(evt => { Tesoro.AddToClassList("cofreabierto"); Tesoro.RemoveFromClassList("cofrecerrado"); });
            buttonPrincipal.RegisterCallback<MouseDownEvent>(evt => DisplayNiveles(rootve));
            buttonLevel1.RegisterCallback<MouseDownEvent>(evt => DisplayLevel1(rootve));
            buttonLevel2.RegisterCallback<MouseDownEvent>(evt => DisplayLevel2(rootve));
            buttonLevel3.RegisterCallback<MouseDownEvent>(evt => DisplayLevel3(rootve));
            buttonNivel2.RegisterCallback<MouseDownEvent>(evt => DisplayLevel2(rootve));
            buttonNivel3.RegisterCallback<MouseDownEvent>(evt => DisplayLevel3(rootve));
            buttonTreasure.RegisterCallback<MouseDownEvent>(evt => DisplayTreasure(rootve));
            Salir.RegisterCallback<MouseDownEvent>(evt => Salida(rootve));


        }
        void DisplayNiveles(VisualElement rootve)
        {
            VisualElement principal = rootve.Query("MenuPrincipal");
            VisualElement niveles = rootve.Query("MenuNiveles");
            principal.style.display = DisplayStyle.None;
            niveles.style.display = DisplayStyle.Flex;
        }
        void Salida(VisualElement rootve)
        {
            VisualElement Treasure = rootve.Query("Treasure");
            Treasure.style.display = DisplayStyle.None;
        }
        void DisplayTreasure(VisualElement rootve)
        {
            VisualElement Level3 = rootve.Query("Nivel3");
            VisualElement Treasure = rootve.Query("Treasure");
            Level3.style.display = DisplayStyle.None;
            Treasure.style.display = DisplayStyle.Flex;
        }
        void DisplayLevel1(VisualElement rootve)
        {
            VisualElement Level1 = rootve.Query("Nivel1");
            VisualElement niveles = rootve.Query("MenuNiveles");
            Level1.style.display = DisplayStyle.Flex;
            niveles.style.display = DisplayStyle.None;
        }
        void DisplayLevel2(VisualElement rootve)
        {
            VisualElement Level2 = rootve.Query("Nivel2");
            VisualElement niveles = rootve.Query("MenuNiveles");
            VisualElement Level1 = rootve.Query("Nivel1");
            Level2.style.display = DisplayStyle.Flex;
            niveles.style.display = DisplayStyle.None;
            Level1.style.display = DisplayStyle.None;
        }
        void DisplayLevel3(VisualElement rootve)
        {
            VisualElement Level3 = rootve.Query("Nivel3");
            VisualElement niveles = rootve.Query("MenuNiveles");
            VisualElement Level2 = rootve.Query("Nivel2");
            Level3.style.display = DisplayStyle.Flex;
            Level2.style.display = DisplayStyle.None;
            niveles.style.display = DisplayStyle.None;
        }
        void DisplayBlue(VisualElement rootve)
        {
            VisualElement red = rootve.Query("C1");
            VisualElement green = rootve.Query("C2");
            VisualElement blue = rootve.Query("C3");
            blue.style.display = DisplayStyle.Flex;
            red.style.display = DisplayStyle.None;
            green.style.display = DisplayStyle.None;

        }
        void DisplayGreen(VisualElement rootve)
        {
            VisualElement red = rootve.Query("C1");
            VisualElement green = rootve.Query("C2");
            VisualElement blue = rootve.Query("C3");
            green.style.display = DisplayStyle.Flex;
            red.style.display = DisplayStyle.None;
            blue.style.display = DisplayStyle.None;
        }
        void DisplayRed(VisualElement rootve)
        {
            VisualElement red = rootve.Query("C1");
            VisualElement green = rootve.Query("C2");
            VisualElement blue = rootve.Query("C3");
            red.style.display = DisplayStyle.Flex;
            green.style.display = DisplayStyle.None;
            blue.style.display = DisplayStyle.None;
        }
        bool Intersect(VisualElement a, VisualElement b)
        {
            Rect rectA = a.worldBound;
            Rect rectB = b.worldBound;
            return rectA.Overlaps(rectB);
        }

        void NuevaTarjeta(ClickEvent ev, VisualElement contDer, Individuo individuoSelect)
        {
            VisualTreeAsset plantilla = Resources.Load<VisualTreeAsset>("Tarjeta");
            VisualElement tarjetaPlantilla = plantilla.Instantiate;
            contDer.Add(tarjetaPlantilla);
            Individuo indi = new Individuo(name.value, surname.value);
            Tarjeta tarj = new Tarjeta(tarjetaPlantilla, indi);
            individuoSelect = indi;
        }
        void SelecciónTarjeta(ClickEvent ev, Individuo individuoSelect, ref bool level2, ref bool level3)
        {
            VisualElement miTarjeta = ev.target as VisualElement;
            individuoSelect = miTarjeta.userData as Individuo;
            level2 = miTarjeta.GetLevel2();
            level2 = miTarjeta.GetLevel3();
        }


    }
}

