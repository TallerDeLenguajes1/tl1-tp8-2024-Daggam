// See https://aka.ms/new-console-template for more information
using System.Globalization;
using EmpleadoNamespace;

Empleado crearEmpleado(){
    //Nombre
    Console.WriteLine("Ingrese el nombre del empleado: ");
    string nombre = Console.ReadLine().Trim();
    //Apellido
    Console.WriteLine("Ingrese el apellido del empleado: ");
    string apellido = Console.ReadLine().Trim();
    //Fecha de nacimiento
    Console.WriteLine("Ingrese la fecha de nacimiento: (formato dd/MM/yyyy)");
    DateTime fecha_de_nacimiento;
    while(!DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy",null,System.Globalization.DateTimeStyles.None,out fecha_de_nacimiento)){
        Console.WriteLine("La fecha ingresada no es válida. Ingrese la fecha con el formato correcto. dd/MM/yyyy");
    }
    //Estado civil
    Console.WriteLine("Ingrese el estado civil: ('S':Soltero; 'C':Casado; 'V':Viudo; 'D': Divorciado)");
    char estado_civil;
    while(!char.TryParse(Console.ReadLine(),out estado_civil) || (estado_civil !='S' && estado_civil !='C' && estado_civil !='V' && estado_civil !='D')){
        Console.WriteLine("Ingrese una opción válida.");
    }
    //Fecha de ingreso a la empresa.
    Console.WriteLine("Ingrese la fecha de ingreso a la empresa: (formato dd/MM/yyyy)");
    DateTime fecha_de_ingreso;
    while(!DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy",null,System.Globalization.DateTimeStyles.None,out fecha_de_ingreso)){
        Console.WriteLine("La fecha ingresada no es válida. Ingrese la fecha con el formato correcto. dd/MM/yyyy");
    }
    //Sueldo básico
    double sueldo;
    Console.WriteLine("Ingrese el sueldo básico del empleado: ");
    while(!double.TryParse(Console.ReadLine(),out sueldo) || sueldo < 234315.12d){
        Console.WriteLine("Ingrese un sueldo básico válido");
    }
    //Cargo
    Cargos cargo;
    Console.WriteLine("Ingrese el cargo del Empleado: (Auxiliar, Administrativo, Ingeniero, Especialista, Investigador)");
    while(!Enum.TryParse<Cargos>(Console.ReadLine(),out cargo)){
        Console.WriteLine("Error. Ingrese una de las opciones válidas.");
    }

    return new Empleado(nombre,apellido,fecha_de_nacimiento,estado_civil,fecha_de_ingreso,sueldo,cargo);
}


//Creamos 3 empleados
var empleados = new Empleado[3];
for (int i = 0; i < 3; i++)
{
    empleados[i] = crearEmpleado();
}

double SalarioTotal = empleados[0].Salario();
Empleado proximoAJubilarse = empleados[0];
for (int i = 1; i < 3; i++)
{
    SalarioTotal+=empleados[i].Salario();
    if(proximoAJubilarse.JubilacionContador() > empleados[i].JubilacionContador()){
        proximoAJubilarse = empleados[i];
        
    }
}

Console.WriteLine("El total de salarios a pagar es " + SalarioTotal.ToString("N",CultureInfo.CreateSpecificCulture("es-ES")));
Console.WriteLine("Empleado proximo a jubilarse es: ");
proximoAJubilarse.MostrarDatos();