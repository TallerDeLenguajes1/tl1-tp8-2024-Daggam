namespace CalculadoraNamespace;
public enum TipoOperacion{
    Suma,
    Resta,
    Multiplicacion,
    Division,
    Limpiar
}
public class Operacion{
    private double resultadoAnterior;
    private double nuevoValor;
    private TipoOperacion operacion;

    public Operacion(double resultadoAnterior, double nuevoValor, TipoOperacion operacion){
        this.resultadoAnterior = resultadoAnterior;
        this.nuevoValor = nuevoValor;
        this.operacion = operacion;
    }

    public double Resultado { get => resultadoAnterior;}
    public double NuevoValor { get => nuevoValor;}
}
class Calculadora{
    private double dato;
    private List<Operacion> historial = new List<Operacion>();
    public double Resultado{get => dato;}
    public List<Operacion> Historial { get => historial; }

    public void Sumar(double termino){
        double nuevoValor = dato + termino;
        Operacion op = new(dato,nuevoValor,TipoOperacion.Suma);
        historial.Add(op);
        dato = nuevoValor;
    }
    public void Restar(double termino){
        double nuevoValor = dato - termino;
        Operacion op = new(dato,nuevoValor,TipoOperacion.Resta);
        historial.Add(op);
        dato = nuevoValor;
    }
    public void Multiplicar(double termino){
        double nuevoValor = dato*termino;
        Operacion op = new(dato,nuevoValor,TipoOperacion.Multiplicacion);
        historial.Add(op);
        dato = nuevoValor;
    }
    public void Dividir(double termino){
        double nuevoValor = dato / termino;
        Operacion op = new(dato,nuevoValor,TipoOperacion.Division);
        historial.Add(op);
        dato = nuevoValor;
    }
    public void Limpiar(){
        Operacion op = new(dato,0,TipoOperacion.Limpiar);
        historial.Add(op);
        dato = 0;
    }

}