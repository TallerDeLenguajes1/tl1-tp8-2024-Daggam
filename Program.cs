using TareasNamespace;

List<Tarea> tareasPendientes = new List<Tarea>();
List<Tarea> tareasRealizadas = new List<Tarea>();

void transferirTareas(List<Tarea> tareaP, List<Tarea> tareaR){
    int id;
    Console.WriteLine("Ingrese el id que desea transferir: ");
    while(!(int.TryParse(Console.ReadLine(),out id))){
        Console.WriteLine("El dato ingresado no es válido. Intente de nuevo");
    }
    Tarea tareaEncontrada = tareaP.FirstOrDefault( tarea => tarea.TareaId == id);

    if(tareaEncontrada!=null){
        tareaP.Remove(tareaEncontrada);
        tareaR.Add(tareaEncontrada);
        Console.WriteLine("Tarea realizada con exito!");
    }else{
        Console.WriteLine("El id ingresado no corresponde a ninguna tarea pendiente.");
    }
}

void mostrarTarea(List<Tarea> tarea){
    tarea.ForEach(t => {
        Console.WriteLine(@"
                            -----------------------------------------------------------
                                                ID de la tarea: {0}
                                            Descripcion de la tarea: {1}
                                              Duracion de la tarea: {2}
                            -----------------------------------------------------------"
                            ,t.TareaId,t.Descripcion,t.Duracion);
    });
}

bool consultarTarea(List<Tarea> tarea,int id){
    return tarea.FirstOrDefault(t => t.TareaId == id) != null;
}
//Cargado de tareas.
while(true){
    int duracion;
    string descripcion;
    Console.WriteLine("Bienvenido al sistema de tareas.");
    Console.WriteLine("Ingrese una descripcion para la tarea.");
    descripcion = Console.ReadLine();
    Console.WriteLine("Ingresa la duración de la tarea (valor númerico entre 10 y 99): ");
    while(!(int.TryParse(Console.ReadLine(),out duracion)) || duracion < 10 || duracion > 99){
        Console.WriteLine("El valor ingresado no es el correcto. Intentelo de nuevo");
    }

    tareasPendientes.Add(new Tarea(descripcion,duracion));

    Console.WriteLine("¿Desea agregar otra tarea? (Presione S para confirmar)");
    if(Console.ReadLine().ToLower() != "s"){
        break;
    }
    Console.Clear();
}
bool continuar=true;
while(continuar){
    Console.WriteLine(@"-- Menú Tareas --
                        1. Marcar tarea realizada
                        2. Ver tareas.
                        3. Consultar tareas.
                        4. Salir.");
    switch(Console.ReadLine()){
        case "1":
            transferirTareas(tareasPendientes,tareasRealizadas);
            break;
        case "2":
            Console.WriteLine("- Tareas Pendientes -");
            mostrarTarea(tareasPendientes);
            Console.WriteLine("- Tareas Realizadas -");
            mostrarTarea(tareasRealizadas);
            break;
        case "3":
            int id;
            Console.WriteLine("Ingrese el id de la tarea que desea consultar: ");
            while(!int.TryParse(Console.ReadLine(),out id)){
                Console.WriteLine("El id ingresado no es válido.");
            }
            if(consultarTarea(tareasPendientes,id)){
                Console.WriteLine("ES TAREA PENDIENTE");
            }else if(consultarTarea(tareasRealizadas,id)){
                Console.WriteLine("ES TAREA REALIZADA");
            }else{
                Console.WriteLine("LA TAREA NO FUE ENCONTRADA");
            }
            break;
        case "4":
            continuar=false;
            break;
        default:
            Console.WriteLine("La opción elegida es incorrecta");
            break;
    }
}
