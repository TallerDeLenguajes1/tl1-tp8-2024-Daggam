namespace TareaNamespace;

public class Tarea{
    static int cantidadDeTareas;
    int tareaID;
    string descripcion;
    int duracion;
    public Tarea(string descripcion,int duracion){
        tareaID = cantidadDeTareas;
        this.descripcion = descripcion;
        this.duracion = duracion;
        cantidadDeTareas++;
    
    }

    public int TareaID { get => tareaID; }
    public string Descripcion { get => descripcion; }
}