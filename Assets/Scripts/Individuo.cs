using UnityEngine;
using System;


namespace DSIFin
{
    public class Individuo
    {
        public event Action Cambio;
        private string nombre;
        public string Nombre
        {
            get
            { return nombre; }
            set
            {
                if (nombre != value)
                {
                    nombre = value;
                    Cambio?.Invoke();
                }
            }

        }
        private string apellido;
        public string Apellido
        {
            get
            { return apellido; }
            set
            {
                if (apellido != value)
                {
                    apellido = value;
                    Cambio?.Invoke();
                }
            }

        }
        public Individuo(string surname, string name)
        {
            this.nombre = name;
            this.apellido = surname;
        }
        bool nivel2 = false;
        bool nivel3 = false;
        void SetLevel2()
        {
            nivel2 = true;
        }
        void SetLevel3()
        {
            nivel3 = true;
        }
        bool GetLevel2()
        {
            return nivel2;
        }
        bool GetLevel3()
        {
            return nivel3;
        }
    }

}