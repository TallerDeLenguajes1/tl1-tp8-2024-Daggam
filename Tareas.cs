namespace TareasNamespace;

public class Tarea{
    static int globalTareaId=1000;
    int tareaId;
    string descripcion;
    int duracion;
    
    public int TareaId { get => tareaId; }
    public string Descripcion { get => descripcion;}
    public int Duracion { get => duracion;}

    public Tarea(string descripcion, int duracion)
    {
        tareaId = globalTareaId;
        globalTareaId++;
        this.descripcion = descripcion;
        this.duracion = duracion;
    }

}