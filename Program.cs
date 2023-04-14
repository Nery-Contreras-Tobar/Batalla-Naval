// See https://aka.ms/new-console-template for more information

int[,] tablero = new int[5, 5];

void paso1_crear_tablero()
{
    for (int i = 0; i < tablero.GetLength(0); i++)
    {
        for (int j = 0; j < tablero.GetLength(1); j++)
        {
            tablero[i, j] = 0;
        }
    }
}


void paso2_colocar_barcos()
{
    Random random = new Random(); // Crear una instancia de la clase Random para generar números aleatorios
    int barcosColocados = 0; // Contador de barcos colocados

    while (barcosColocados < 5) // Colocar 5 barcos
    {
        int fila = random.Next(0, 5); // Generar una fila aleatoria
        int columna = random.Next(0, 5); // Generar una columna aleatoria

        if (tablero[fila, columna] == 0) // Verificar si la posición está disponible (valor 0 en el tablero)
        {
            tablero[fila, columna] = 1; // Colocar el barco en la posición
            barcosColocados++; // Incrementar el contador de barcos colocados
        }
    }

    //tablero[0, 0] = 1;
    //tablero[4, 4] = 1;
    //tablero[2, 2] = 1;
    //tablero[0, 4] = 1;
    //tablero[4, 0] = 1;


}


void paso3_imprimir_tablero()
{
    for (int i = 0; i < tablero.GetLength(0); i++)
    {
        for (int j = 0; j < tablero.GetLength(1); j++)
        {
            String caracter_imprimir; //= (tablero[i,j] == 0 ? "-" : "*");
            switch (tablero[i, j])
            {
                case 0: // agua
                    caracter_imprimir = "O";
                    break;
                case 1: //barcao en el tablero
                    caracter_imprimir = "O";
                    break;
                case 2: // explocion
                    caracter_imprimir = "*";
                    break;
                case -1: //fallo
                    caracter_imprimir = "-";
                    break;
                default: // agua 
                    caracter_imprimir = "O";
                    break;

            }
            Console.Write(caracter_imprimir + " ");
        }
        Console.WriteLine();
    }
}

void paso4_ingreso_coordenadas()
{
    int fila, columna = 0;
    int barcosRestantes = 5; // Inicialmente, hay 5 barcos en el tablero
    int intentos = 0; // Inicialmente, no se han realizado intentos
    int maxIntentos = 10; // Establecer el máximo de intentos permitidos
    Console.Clear();
    do
    {
        Console.Write("Ingrese la fila: ");
        if (int.TryParse(Console.ReadLine(), out fila) && fila >= 0 && fila <= 4)
        {
            Console.Write("Ingrese la columna: ");
            if (int.TryParse(Console.ReadLine(), out columna) && columna >= 0 && columna <= 4)
            {
                if (tablero[fila, columna] == 1)
                {
                    Console.Beep();
                    tablero[fila, columna] = 2; // le dio
                    barcosRestantes--; // Decrementar el número de barcos restantes
                }
                else
                {
                    tablero[fila, columna] = -1; // fallo
                }
                Console.Clear();
                paso3_imprimir_tablero();

                // Verificar si todos los barcos han sido impactados
                if (barcosRestantes == 0)
                {
                    Console.WriteLine("¡¡¡GAME OVER!!!");
                    Console.WriteLine("¡Ya no hay barcos por hundir!");
                    break; // Salir del bucle del juego
                }
                intentos++; // Incrementar el número de intentos realizados

                // Verificar si se ha alcanzado el límite de intentos permitidos
                if (intentos == maxIntentos)
                {
                    Console.WriteLine("¡¡¡GAME OVER!!!");
                    Console.WriteLine("Se alcanzó el límite de intentos permitidos");
                    break; // Salir del bucle del juego
                }

            }
            else
            {
                Console.WriteLine("Columna invalida, ingresa un numero menor a 5.");
            }
        }
        else
        {
            Console.WriteLine("Fila invalida, ingresa un numero menor a 5.");
        }
    } while (true);

    
    Console.WriteLine("¡¡¡¡Gracias por jugar!!!!");



}
paso1_crear_tablero();
paso2_colocar_barcos();
paso3_imprimir_tablero();
paso4_ingreso_coordenadas();



