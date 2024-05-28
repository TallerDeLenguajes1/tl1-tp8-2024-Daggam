using System.Globalization;

namespace EmpleadoNamespace;
public enum Cargos{
    Auxiliar,
    Administrativo,
    Ingeniero,
    Especialista,
    Investigador
}

public class Empleado{

    private string nombre;
    private string apellido;
    private DateTime fechaDeNacimiento;
    private char estadoCivil;
    private DateTime fechaDeIngreso; 
    private double sueldoBasico;
    private Cargos cargo;

    public Empleado(string nombre, string apellido, DateTime fecha_de_nacimiento, char estado_civil, DateTime fecha_de_ingreso,double sueldo_basico,Cargos cargo){
        this.nombre = nombre;
        this.apellido = apellido;
        fechaDeNacimiento = fecha_de_nacimiento;
        estadoCivil = estado_civil;
        fechaDeIngreso = fecha_de_ingreso;
        sueldoBasico = sueldo_basico;
        this.cargo = cargo;
    }

    public int Antiguedad(){
        return (DateTime.Now-fechaDeIngreso).Days / 365;
    }

    public int Edad(){
        return (DateTime.Now-fechaDeNacimiento).Days/365;
    }

    public int JubilacionContador(){
        int resultado = 65 - this.Edad();
        return (resultado >= 0) ? resultado:0;
    }

    public double Salario(){
        double adicional=0;
        int antiguedad = this.Antiguedad();
        if(antiguedad<20){
            adicional += 0.01*antiguedad* this.sueldoBasico;
        }else{
            adicional += 0.25 * this.sueldoBasico;
        }
        if(this.cargo == Cargos.Ingeniero || this.cargo == Cargos.Especialista){
            adicional*=1.5;
        }
        if(this.estadoCivil == 'C'){
            adicional+=150000;
        }
        return this.sueldoBasico + adicional;
    }
    public void MostrarDatos(){
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Apellido: " + apellido);
        Console.WriteLine("Fecha de nacimiento: " + fechaDeNacimiento.ToString("dd/MM/yyyy"));
        Console.WriteLine("Fecha de ingreso: " + fechaDeIngreso.ToString("dd/MM/yyyy"));
        Console.WriteLine("Estado civil: " + estadoCivil);
        Console.WriteLine("Sueldo: " + Salario().ToString("N",CultureInfo.CreateSpecificCulture("es-ES")));
        Console.WriteLine("Cargo: " +  cargo);
    }
}