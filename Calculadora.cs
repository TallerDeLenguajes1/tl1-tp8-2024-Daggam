namespace CalculadoraNamespace;
class Calculadora{
    private double _dato;
    public double Resultado{
        set{}
        get{ return _dato;}
    }
    public void Sumar(double termino){
        _dato+=termino;
    }
    public void Restar(double termino){
        _dato-=termino;
    }
    public void Multiplicar(double termino){
        _dato*=termino;
    }
    public void Dividir(double termino){
        _dato/=termino;
    }
    public void Limpiar(){
        _dato=0;
    }
}