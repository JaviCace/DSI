using System;
using UnityEngine;
using UnityEngine.UIElements;


namespace DSIFin
{
    public class Tarjeta
    {
        Individuo mIndividuo;
        VisualElement tarjetaRoot;
        Label nombre;
        Label apellido;
        bool level2 = false;
        bool level3 = false;
        public Tarjeta(VisualElement target, Individuo indi)
        {
            mIndividuo = indi;
            tarjetaRoot = target;
            nombre = tarjetaRoot.Q<Label>("Nombre");
            apellido = tarjetaRoot.Q<Label>("Apellido");
            tarjetaRoot.userData = mIndividuo;
            UpdateUI();
            mIndividuo.Cambio += UpdateUI;
        }
        void UpdateUI()
        {
            nombre.text = mIndividuo.Nombre;
            apellido.text = mIndividuo.Apellido;
        }
       

    }
}

/*
bool Level2 = false;
bool Level3 = false;

BotonCrear.RegisterCallBack<ClickEvent>(NuevaTarjeta);
name.RegisterCallBack<ChangeEvent<string>>(CambioNombre);
surname.RegisterCallBack<ChangeEvent<string>>(CambioApellido);
contDer.RegisterCallBack<ClickEvent>(SelecciónTarjeta);

void NuevaTarjeta(ClickEvent ev) 
{
  VisualTreeAsset plantilla = Resources.Load<VisualTreeAsset>("Tarjeta");
 VisualElement tarjetaPlantilla = plantilla.Instantiate;
 contDer.Add(tarjetaPlantilla);
Individuo indi  = new Individuo(name.value,surname.value);
Tarjeta tarj = new Tarjeta(tarjetaPlantilla,indi);
individuoSelect = indi;
}
void SelecciónTarjeta(ClickEvent ev)
{
VisualElement miTarjeta = ev.target as VisualElement;
individuoSelect = miTarjeta.userData as Individuo
 level2 = miTarjeta.GetLevel2();
 level2 = miTarjeta.GetLevel3();
}
 */
