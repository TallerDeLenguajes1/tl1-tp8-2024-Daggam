namespace TareaNamespace;

public class Tarea{
    static int tareaID;
    string descripcion;
    int duracion;
    public Tarea(string descripcion,int duracion){
        tareaID++;
        this.descripcion = descripcion;
        this.duracion = duracion;
    }

    public int TareaID { get => tareaID; }
}