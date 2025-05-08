

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
