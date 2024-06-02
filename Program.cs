//using System.Collections;
using TareaNamespace;
//CAMBIAMOS LA CODIFICACION DE LA CONSOLA.
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

//Funciones
//Funcion que crea las tareas pendientes.
List<Tarea> crearTareasPendientes(int cantidad){ 
    Random rnd = new();
    List<Tarea> tareasPendientes = new List<Tarea>();
    string[] descripciones = {
        "Hacer la tarea","Jugar a la play 2","Crear un acelerador de hadrones con maizena, javascript y 3 horas de sueño diario","Dormir la siesta","Viajar a San Juan","Crear una máquina de transporte instantaneo"
    };
    for (int i = 0; i < cantidad; i++)
    {
        Tarea nuevaTarea = new Tarea(descripciones.GetValue(rnd.Next(descripciones.Length)).ToString(),rnd.Next(100));
        tareasPendientes.Add(nuevaTarea);
    }
    return tareasPendientes;
}
//Funcion que mueve una tarea pendiente a una tarea realizada.
void moverTarea(List<Tarea> tareasPendientes, List<Tarea> tareasRealizadas,int id){
    //Busco si existe una tarea de ese indice.
    int indexTarea = tareasPendientes.FindIndex(e => e.TareaID==id);
    if(tareasPendientes.Count != 0 && indexTarea != -1){
        Tarea tareaObtenida = tareasPendientes[indexTarea];
        tareasPendientes.RemoveAt(indexTarea);
        tareasRealizadas.Add(tareaObtenida);
        Console.WriteLine("Tarea realizada con exito.");
    }else{
        Console.WriteLine("La tarea ingresada no es válida");
    }
}
//Funcion que busca una tarea dada una descripcion.
void buscarTarea(string descripcion, List<Tarea> tareasPendientes){
    int indexTarea = tareasPendientes.FindIndex( e => e.Descripcion == descripcion);
    if(indexTarea!=-1){
        Tarea tareaObtenida = tareasPendientes[indexTarea];
        Console.WriteLine($"Se encontró una tarea de descripción: {descripcion}");
        Console.WriteLine($"Tarea id: {tareaObtenida.TareaID}");
    }else{
        Console.WriteLine("No se encontró ninguna tarea que cumpla con esa descripción.");
    }
}
//Funcion para validar enteros.
int EscribirYValidarI(){
    int variable;
    while(!int.TryParse(Console.ReadLine(),out variable)){
        Console.WriteLine("El valor ingresado no es válido");
    }
    return variable;
};


//Codigo principal
Console.WriteLine("Introduce la cantidad de tareas pendientes");
int cantidad= EscribirYValidarI();
List<Tarea> tareasPendientes = crearTareasPendientes(cantidad);
List<Tarea> tareasRealizadas = new List<Tarea>();

while(true){
    Console.WriteLine("Ingrese una de las opciones:");
    Console.WriteLine("1. Mover tareas pendientes");
    Console.WriteLine("2. Buscar tareas pendiente por descripción.");
    Console.WriteLine("3. Salir");
    int opciones = EscribirYValidarI();
    if(opciones==3) break;
    switch(opciones){
        case 1:
            Console.WriteLine("Ingrese un id de tarea.");
            int idTarea = EscribirYValidarI();
            moverTarea(tareasPendientes,tareasRealizadas,idTarea);
            break;
        case 2:
            Console.WriteLine("Ingrese una descripción de la tarea:");
            string cadena = Console.ReadLine();
            buscarTarea(cadena,tareasPendientes);
            break;
        default:
            Console.WriteLine("La opción seleccionada no es válida.");
            break;
        }

}