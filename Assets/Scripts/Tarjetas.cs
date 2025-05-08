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
        void SetLevel2()
        {
            level2 = true;
        }
        void SetLevel3()
        {
            level3 = true;
        }
        bool GetLevel2()
        {
            return level2;
        }
        bool GetLevel3()
        {
            return level3;
        }

    }
}