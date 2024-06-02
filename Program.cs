// See https://aka.ms/new-console-template for more information
using CalculadoraNamespace;
Calculadora calculadora = new Calculadora();
//calculadora.Sumar(15.0d);
//Console.WriteLine(calculadora._dato);
int opciones;
string? entrada;
bool esNumeroValido;
do{
    Console.WriteLine("-- Seleccione una de las operaciones --");
    Console.WriteLine("1 - Sumar");
    Console.WriteLine("2 - Restar");
    Console.WriteLine("3 - Multiplicar");
    Console.WriteLine("4 - Dividir");
    Console.WriteLine("5 - Limpiar");
    Console.WriteLine("6 - Salir");

    entrada = Console.ReadLine();
    esNumeroValido = int.TryParse(entrada,out opciones);

    if(!esNumeroValido || opciones < 1 || opciones > 6)
        Console.WriteLine("Ingrese una entrada válida.");
    else if(opciones == 5){
        calculadora.Limpiar();
    }else if(opciones != 6){
        //Tomamos un parametro
        double termino;
        Console.WriteLine("Ingrese un numero: ");
        bool esTerminoValido = double.TryParse(Console.ReadLine(),out termino);
        if(esTerminoValido){
            switch(opciones){
                case 1:
                    calculadora.Sumar(termino);
                    break;
                case 2:
                    calculadora.Restar(termino);
                    break;
                case 3:
                    calculadora.Multiplicar(termino);
                    break;
                case 4:
                    calculadora.Dividir(termino);
                    break;
            }
            Console.WriteLine($"El resultado es: {calculadora.Resultado}");
        }else{
            Console.WriteLine("El termino ingresado no es válido");
        }
    }
}while(opciones != 6);
