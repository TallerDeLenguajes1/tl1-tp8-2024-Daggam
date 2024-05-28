using TareaNamespace;
//Funciones
List<Tarea> crearTareasPendientes(int cantidad){ 
    Random rnd = new();
    List<Tarea> tareasPendientes = new List<Tarea>();
    string[] descripciones = {
        "lorem1","lorem1","lorem1","lorem1","lorem1"
    };
    for (int i = 0; i < cantidad; i++)
    {
        Tarea nuevaTarea = new Tarea(descripciones.GetValue(rnd.Next(descripciones.Length)).ToString(),rnd.Next(100));
        tareasPendientes.Add(nuevaTarea);
    }
    return tareasPendientes;
}

void moverTarea(List<Tarea> tareasPendientes, List<Tarea> tareasRealizadas,int id){
    //Ver single.
    if(tareasPendientes.Count != 0 && tareasPendientes.Exists( e => e.TareaID == id)){
        
    }else{
        Console.WriteLine("La tarea ingresada no es válida");
    }
}



Console.WriteLine("Introduce la cantidad de tareas pendientes");
int cantidad;
while(!int.TryParse(Console.ReadLine(),out cantidad)){
    Console.WriteLine("El valor ingresado no es válido");
}
List<Tarea> tareasPendientes = crearTareasPendientes(cantidad);
List<Tarea> tareasRealizadas = new List<Tarea>();

while(true){
    Console.WriteLine("Ingrese una de las opciones:");
    Console.WriteLine("1. Mover tareas pendientes");
    Console.WriteLine("2. Buscar tareas pendiente por descripción.");
    int opciones;
    if(int.TryParse(Console.ReadLine(),out opciones)) {
        switch(opciones){
            case 1:
                Console.WriteLine("Ingrese un id de tarea.");
                int idTarea;
                if(int.TryParse(Console.ReadLine(),out idTarea)){
                    moverTarea(tareasPendientes,tareasRealizadas,idTarea);
                }else{
                    Console.WriteLine("La tarea no existe.");
                }
                break;
        }
    } else {
        Console.WriteLine("El valor ingresado no es válido.");
    }
}